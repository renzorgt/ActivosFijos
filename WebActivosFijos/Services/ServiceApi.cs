using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using WebActivosFijos.Dtos;
using WebActivosFijos.Models;

namespace WebActivosFijos.Services
{
    public class ServiceApi : IServiceApi
    {

        private static string _baseUrl;

        public ServiceApi()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory
                .GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        public async Task<ActivoFijo> Get(int id)
        {
            ActivoFijo list = new ActivoFijo();

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            var resp = await client.GetAsync("ActivoFijo");

            if (resp.IsSuccessStatusCode)
            {
                var json = await resp.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ActivoFijo>(json);

                list = result;
            }

            return list;
        }

        public async Task<List<ActivoFijo>> GetAll()
        {
            List<ActivoFijo> list = new List<ActivoFijo>();

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            var resp = await client.GetAsync("ActivoFijo");

            if (resp.IsSuccessStatusCode)
            {
                var json = await resp.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ActivoFijo>>(json);

                list = result;
            }

            return list;
        }

        public async Task<List<ActivoFijo>> Insert(ActivoFijoInsert activoFijoInsert)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            List<ActivoFijo> list = new List<ActivoFijo>();
            var content =  new StringContent(JsonConvert.SerializeObject(activoFijoInsert),Encoding.UTF8,"application/json");


            var resp = await client.PostAsync($"ActivoFijo",content);

            if (resp.IsSuccessStatusCode)
            {
                var resp2 = await client.GetAsync("ActivoFijo");
                var json = await resp2.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ActivoFijo>>(json);

                list = result;
            }

            return list;
        }

        public async Task<bool> Update(int Id, ActivoFijoPut activoFijoPut)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(activoFijoPut), Encoding.UTF8, "application/json");


            var resp = await client.PutAsync($"ActivoFijo?id={Id}", content);

            if (resp.IsSuccessStatusCode)
            {

                return true;
            }

            return false;
        }
    }
}
