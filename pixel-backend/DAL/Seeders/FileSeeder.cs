using Infastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seeders
{
    public class FileSeeder
    {
        private HttpClient _client;
        private readonly ApplicationContext _applicationContext;
        public FileSeeder(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            _client = new HttpClient();
        }

        public async Task Seed()
        {
            if (!await _applicationContext.Files.AnyAsync())
            {
                try
                {
                    var response = await _client.GetAsync("https://api.unsplash.com/photos/random/?client_id=8jiK3ovEU6v2suI9-dEobshU0nZztk60N_6PHQPEa6c&count=30");
                    response.EnsureSuccessStatusCode();
                    List<Image> images = await response.Content.ReadFromJsonAsync<List<Image>>();

                    List<File> files = new List<File>();
                    foreach (Image image in images)
                    {
                        File file = new File()
                        {
                            Name = image.Id,
                            RawImageUrl = image.Urls.Raw,
                            Likes = image.Likes,
                            Views = image.Views
                        };

                        files.Add(file);
                    }

                    await _applicationContext.AddRangeAsync(files);
                    await _applicationContext.SaveChangesAsync();
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
        }

        private class Image
        {
            public string Id { get; set; }
            public Urls Urls { get; set; }
            public long Likes { get; set; }
            public long Views { get; set; }
        }

        private class Urls
        {
            public string Raw { get; set; }
        }
    }
}
