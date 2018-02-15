using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTalk.Models.Entities;

namespace TeamTalk.Models.ITeam
{
    interface IUsers
    {
        bool Login(string username, string password);
        bool LogOut();

        string Register(User user);
        string DeleteUser(string username);
        string ChangeStatus(string username, string curStatus);

    }
}
