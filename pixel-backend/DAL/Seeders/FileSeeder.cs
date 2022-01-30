using Infastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly HttpClient _client;
        private readonly ApplicationContext _applicationContext;
        private readonly string _apiKey;
        public FileSeeder(ApplicationContext applicationContext, IConfiguration configuration)
        {
            _applicationContext = applicationContext;
            _client = new HttpClient();
            _apiKey = configuration["unsplashApiKey"];
        }

        public async Task Seed()
        {
            try
            {
                Console.WriteLine("Seeding Database");
                var response = await _client.GetAsync($"https://api.unsplash.com/photos/random/?client_id={_apiKey}&count=30");
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
