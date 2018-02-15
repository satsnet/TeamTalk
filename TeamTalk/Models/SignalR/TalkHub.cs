using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamTalk.Models.Entities;
using TeamTalk.Models.BAL;
using System.Threading.Tasks;

namespace TeamTalk.Models.SignalR
{
    [HubName("talkHub")]
    public class TalkHub : Hub
    {
        public void sendMessage(string username, string message, string receiver)
        {
            Clients.All.send(username, message, receiver);

            Messages messages = new Messages
            {
                FromUser =receiver ,
                MessageText = message,
                ToUser = username,

            };

            BMessages newMessage = new BMessages();
            Task.Run(() => newMessage.SendMessage(messages));
        }

        public void sendMessageAll(string username, string message)
        {
            Clients.All.receiveAll(username, message);
        }


        public void isTyping(string username,bool isT,string receiver)
        {
            Clients.All.typing(username, isT,receiver);
        }
    }
}