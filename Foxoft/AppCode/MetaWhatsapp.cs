using Foxoft.Properties;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Foxoft.AppCode
{
    class MetaWhatsapp
    {
        public MetaResponce SendWhatsapp(string number, string message)
        {
            string url = "https://graph.facebook.com/v16.0/103654376062877/messages";
            string token = @"EABjvhqB7L30BAO8vXAt3Pdhz7ZC62yvKoL7n0fxL4XnZALjNBooAyJ3AgStPPOnAzQVz5XABGMX9TRlZC0uM7D89O6iJDRk0U5m1In8NjEOmLsIHdMBuI5c7ssw6g9vhz4uRtYVe1kkZC4YwqzQG3C5HgwulVU48ZBYb1GZB0OgKxkHKoQnkjSEhJ7IYKGFjYElhTWpmXIhAZDZD";

            var entity = new MetaEntity()
            {
                messaging_product = "whatsapp",
                recipient_type = "individual",
                type = "text",
                to = number,
                text = new text() { body = message, preview_url = false }
            };

            var clientRest = new RestClient(url);
            var requestRest = new RestRequest(url, Method.Post);
            requestRest.AddHeader("Authorization", "Bearer " + token);
            requestRest.AddBody(entity);
            var responseRest = clientRest.ExecutePost(requestRest);
            string outputRest = responseRest.Content;

            return JsonConvert.DeserializeObject<MetaResponce>(outputRest);

            //var json = JsonConvert.SerializeObject(entity);
            //var data = new StringContent(json, Encoding.UTF8, "application/json");
            //using var client = new HttpClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //var response = await client.PostAsync(url, data);
            //var result = await response.Content.ReadAsStringAsync();
            //var output = response.Content;
        }
    }

    class MetaEntity
    {
        public string messaging_product { get; set; }
        public string recipient_type { get; set; }
        public string to { get; set; }
        public string type { get; set; }
        public text text { get; set; }
    }

    class text
    {
        public string body { get; set; }
        public bool preview_url { get; set; }
    }

    class MetaResponce
    {
        public error error { get; set; }
        public string messaging_product { get; set; }
        public IEnumerable<messages> messages { get; set; }
        public IEnumerable<contacts> contacts { get; set; }
    }

    class messages
    {
        public string id { get; set; }
    }

    class contacts
    {
        public string id { get; set; }
    }

    class error
    {
        public string message { get; set; }
        public string type { get; set; }
        public string code { get; set; }
        public string fbtrace_id { get; set; }
    }

}
