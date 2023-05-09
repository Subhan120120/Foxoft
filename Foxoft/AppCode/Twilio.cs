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
                number = "994" + number;

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
                TwilioResponce twilioResponce = JsonConvert.DeserializeObject<TwilioResponce>(output);

                if (twilioResponce.message == "ok")
                {
                    TwilioCheck check = CheckNumber(number, instanceId, token);
                    if (check.status == "valid")
                        return JsonConvert.DeserializeObject<TwilioResponce>(output);
                    else return new TwilioResponce() { message = "Bu nömrə üzrə whatsapp hesabı yoxdur" };
                }
                else return twilioResponce;
            }
            else
                return new() { sent = false, message = "Serverə qoşula bilmədi." };
        }

        public TwilioCheck CheckNumber(string number, string instanceId, string token)
        {
            RestResponse response = new();
            if (number.Contains("@g.us"))
            {
                string url = "https://api.ultramsg.com/" + instanceId + "/groups/group";
                var client = new RestClient(url);
                var request = new RestRequest(url, Method.Get);
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddParameter("token", token);
                request.AddParameter("groupId", number);
                request.AddParameter("priority", "");
                response = client.Execute(request);
                string output = response.Content;
                if (!output.Contains("error"))
                    return new TwilioCheck() { status = "valid" };
                else return new TwilioCheck() { status = "invalid" };
            }
            else
            {
                string url = "https://api.ultramsg.com/" + instanceId + "/contacts/check"; var client = new RestClient(url);
                var request = new RestRequest(url, Method.Get);
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddParameter("token", token);
                request.AddParameter("chatId", number + "@c.us");
                request.AddParameter("nocache", "");
                response = client.Execute(request);
                string output = response.Content;
                return JsonConvert.DeserializeObject<TwilioCheck>(output);
            }
        }
    }

    class TwilioResponce
    {
        public int id { get; set; }
        public bool sent { get; set; }
        public string message { get; set; }
        public string error { get; set; }
    }

    class TwilioCheck
    {
        public string status { get; set; }
        public string chatId { get; set; }
    }

}
