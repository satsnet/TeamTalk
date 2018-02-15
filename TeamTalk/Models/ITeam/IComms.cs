using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTalk.Models.Entities;

namespace TeamTalk.Models.ITeam
{
    interface IComms
    {
         string SendMessage(Messages msg);
        List<Messages> LoadMessages(string FromUserName,string ToUser,DateTime StartDate);
        bool DeleteMessage(string Username, int msgId);
        bool FavoriteMessage(string Username, int msgId);
    }
}
