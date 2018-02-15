using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTalk.Models.Entities;

namespace TeamTalk.Models.ITeam
{
    interface IUserOperations
    {
        List<User> GetOnlineUsers();
        List<User> GetOfflineUsers();
    }
}
