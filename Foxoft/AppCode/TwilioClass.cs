//using System;
//using Twilio;
//using Twilio.Rest.Api.V2010.Account;
//using Twilio.Types;

//namespace Foxoft.AppCode
//{
//    class TwilioClass
//    {
//        public void AlmaDolmasi()
//        {
//            var accountSid = "AC3975230c878fd8f23210d643a30a94b6";
//            var authToken = "33203b63185389e3f8e995fc245fd788";
//            TwilioClient.Init(accountSid, authToken);

//            var messageOptions = new CreateMessageOptions(
//              new PhoneNumber("whatsapp:+994102160610"));
//            messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
//            messageOptions.Body = "Your appointment is coming up on July 21 at 3PM";


//            var message = MessageResource.Create(messageOptions);

//            System.Windows.Forms.MessageBox.Show(message.Sid);

//        }


//    }
//}
