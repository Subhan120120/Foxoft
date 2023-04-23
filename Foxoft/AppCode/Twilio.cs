using Foxoft.Properties;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace Foxoft.AppCode
{
    class TwilioClass
    {
        public TwilioResponce SendWhatsapp(string number, string type, string body)
        {
            if (String.IsNullOrEmpty(number))
                return new TwilioResponce() { sent = false, message = "Nömrə qeyd olunmayıb." };

            number = number.Trim();
            if (number.Length < 13)
                number = "+994" + number;

            string instanceId = Settings.Default.AppSetting.TwilioInstanceId;
            string token = Settings.Default.AppSetting.TwilioToken;
            string url = "https://api.ultramsg.com/" + instanceId + "/messages/";

            url += type == "image" ? "image" : "chat";

            RestClient client = new(url);
            RestRequest request = new(url, Method.Post);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("token", token);
            request.AddParameter("to", number);

            if (type == "chat")
                request.AddParameter("body", body);
            else if (type == "image")
                request.AddParameter("image", body);

            RestResponse response = client.Execute(request);

            if (!string.IsNullOrEmpty(response.Content))
            {
                string output = response.Content;
                return JsonConvert.DeserializeObject<TwilioResponce>(output);
            }
            else
                return new() { sent = false, message = "Serverə qoşula bilmədi." };
        }
    }

    class TwilioResponce
    {
        public int id { get; set; }
        public bool sent { get; set; }
        public string message { get; set; }
    }

}
