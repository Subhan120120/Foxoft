using Foxoft.Properties;
using Newtonsoft.Json;
using System;

namespace Foxoft.AppCode
{
    class UltramsgClass
    {
        //public UltramsgResponce SendWhatsapp(string number, string type, string body)
        //{
        //    if (String.IsNullOrEmpty(number))
        //        return new UltramsgResponce() { sent = false, message = "Nömrə qeyd olunmayıb." };

        //    number = number.Trim();
        //    if (number.Length < 13)
        //        number = "994" + number;

        //    string instanceId = Settings.Default.AppSetting.TwilioInstanceId;
        //    string token = Settings.Default.AppSetting.TwilioToken;
        //    string url = "https://api.ultramsg.com/" + instanceId + "/messages/";

        //    url += type == "image" ? "image" : "chat";

        //    RestClient client = new(url);
        //    RestRequest request = new(url, Method.Post);
        //    request.AddHeader("content-type", "application/x-www-form-urlencoded");
        //    request.AddParameter("token", token);
        //    request.AddParameter("to", number);

        //    if (type == "chat")
        //        request.AddParameter("body", body);
        //    else if (type == "image")
        //        request.AddParameter("image", body);

        //    RestResponse response = client.Execute(request);

        //    if (!string.IsNullOrEmpty(response.Content))
        //    {
        //        string output = response.Content;
        //        UltramsgResponce UltramsgResponce = JsonConvert.DeserializeObject<UltramsgResponce>(output);

        //        if (UltramsgResponce.message == "ok")
        //        {
        //            UltramsgCheck check = CheckNumber(number, instanceId, token);
        //            if (check.status == "valid")
        //                return JsonConvert.DeserializeObject<UltramsgResponce>(output);
        //            else return new UltramsgResponce() { message = "Bu nömrə üzrə whatsapp hesabı yoxdur" };
        //        }
        //        else return UltramsgResponce;
        //    }
        //    else
        //        return new() { sent = false, message = "Serverə qoşula bilmədi." };
        //}

        //public UltramsgCheck CheckNumber(string number, string instanceId, string token)
        //{
        //    RestResponse response = new();
        //    if (number.Contains("@g.us"))
        //    {
        //        string url = "https://api.ultramsg.com/" + instanceId + "/groups/group";
        //        var client = new RestClient(url);
        //        var request = new RestRequest(url, Method.Get);
        //        request.AddHeader("content-type", "application/x-www-form-urlencoded");
        //        request.AddParameter("token", token);
        //        request.AddParameter("groupId", number);
        //        request.AddParameter("priority", "");
        //        response = client.Execute(request);
        //        string output = response.Content;
        //        if (!output.Contains("error"))
        //            return new UltramsgCheck() { status = "valid" };
        //        else return new UltramsgCheck() { status = "invalid" };
        //    }
        //    else
        //    {
        //        string url = "https://api.ultramsg.com/" + instanceId + "/contacts/check"; var client = new RestClient(url);
        //        var request = new RestRequest(url, Method.Get);
        //        request.AddHeader("content-type", "application/x-www-form-urlencoded");
        //        request.AddParameter("token", token);
        //        request.AddParameter("chatId", number + "@c.us");
        //        request.AddParameter("nocache", "");
        //        response = client.Execute(request);
        //        string output = response.Content;
        //        return JsonConvert.DeserializeObject<UltramsgCheck>(output);
        //    }
        //}
    }

    class UltramsgResponce
    {
        public int id { get; set; }
        public bool sent { get; set; }
        public string message { get; set; }
        public string error { get; set; }
    }

    class UltramsgCheck
    {
        public string status { get; set; }
        public string chatId { get; set; }
    }

}
