using DAL.Interfaces;
using Infastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Service
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        private HttpClient _client;

        public FileService(IFileRepository fileRepository)
        {
            Console.WriteLine("here");
            _fileRepository = fileRepository;
            _client = new HttpClient();
        }

        public async Task<File> GetFileById(int id)
        {
            return await _fileRepository.GetById(id);
        }

        public async Task<File> GetImageFileFromUnsplashById(string id)
        {
            try
            {
                string url = $"https://api.unsplash.com/photos/{id}/?client_id=8jiK3ovEU6v2suI9-dEobshU0nZztk60N_6PHQPEa6c";
                var response = await _client.GetAsync(url);
                Console.WriteLine("Url = " + url);
                response.EnsureSuccessStatusCode();
                Image image = await response.Content.ReadFromJsonAsync<Image>();

                File newFile = new File()
                {
                    Name = image.Id,
                    RawImageUrl = image.Urls.Raw,
                    Likes = image.Likes,
                    Views = image.Views
                };

                await _fileRepository.Add(newFile);
                await _fileRepository.SaveChanges();
                return newFile;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return new File();
        }

        private class Image
        {
            public string Id { get; set; }
            public Urls Urls { get; set; }
            public long Likes { get; set; }
            public long Views { get; set; }
            public void Print()
            {
                Console.WriteLine($"Printing the image\nId = {Id}\n Raw image url = {Urls.Raw}\n Likes = {Likes}\n Views = {Views}");
            }
        }

        private class Urls
        {
            public string Raw { get; set; }
        }
    }


}
