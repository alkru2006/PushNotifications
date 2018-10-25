using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Net;

namespace PushNotifications.Models
{
    public class Message
    {
        private static Message _message = new Message() 
        {
            Id = 1,
            Msg = "Put your message here",
            Status = "Message has not been sent yet"
        };
    
        //private Message() { }
        static public Message GetMessage() { return _message; }
        private string sPushoverUserKey = "u2ow6opbt9j6xz98fjhx4tj3o6dx3u";
        private string sPushoverToken = "a8qw7n5ayz7dtk29ooe5senr4o7xtd";
        private string sPushoverEmail = "fzssru7j1t@pomail.net";

        public int Id { get; set; }
        public string Msg { get; set; }
        public string Status { get; set; }

        internal void PushMessage()
        {
            var parameters = new NameValueCollection {
                { "token", sPushoverToken },
                { "user", sPushoverUserKey },
                { "message", Msg }
            };

            try
            {
                using (var client = new WebClient())
                {
                    client.UploadValues("https://api.pushover.net/1/messages.json", parameters);
                }
                Status = $"'{Msg}' has been sent at {DateTime.Now.ToShortTimeString()}";
            }
            catch (Exception e)
            {
                Status = $"'{Msg}' has been sent. Error: '{e.Message}'";
            }
        }
    }
}
