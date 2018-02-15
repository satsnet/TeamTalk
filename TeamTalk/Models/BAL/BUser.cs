using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using TeamTalk.Models.EFContext;
using TeamTalk.Models.Entities;
using TeamTalk.Models.ITeam;
using ValueAPI.ClassLibrary;

namespace TeamTalk.Models.BAL
{
    public  partial class BUser : IUsers
    {
        public virtual string ChangeStatus(string username, string curStatus)
        {
            using (var ctx = new TTContext())
            {
                IQueryable<User> user = ctx.Users.Where(c => c.Username == username);
                var dUser = user.FirstOrDefault();
                dUser.CurStatus = curStatus;
                ctx.Entry(dUser).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            return "Status Updated Successfully";
        }

        public virtual string DeleteUser(string username)
        {
            throw new NotImplementedException();
        }

        public virtual bool Login(string username, string password)
        {
            bool isValid = false;

            try
            {
                using (var ctx = new TTContext())
                {
                    IQueryable<User> user = ctx.Users.Where(c => c.Username == username);
                    var dUser = user.FirstOrDefault();
                    isValid = PwdEncrypt.VerifyHash(password, "SHA512", dUser.Password);

                    ChangeStatus(username, "1");
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return isValid;
        }

        public bool LogOut()
        {

            ChangeStatus(HttpContext.Current.User.Identity.Name, "0");
            FormsAuthentication.SignOut();
            return true;
        }

        public virtual string Register(User user)
        {
            string returnString = string.Empty;

            try
            {
                user.Password = PwdEncrypt.ComputeHash(user.Password, "SHA512", null);
                using (var ctx = new TTContext())
                {
                    ctx.Users.Add(user);
                    returnString = ctx.SaveChanges().ToString();
                }
            }
            catch (Exception ex)
            {
                throw;;
            }

            return returnString;
        }
    }


    public partial class BUser : IUserOperations
    {
        public List<User> GetOfflineUsers()
        {
            using (var ctx = new TTContext())
            {
                IQueryable<User> QIUser = ctx.Users.Where(c => c.CurStatus == "0");
                return QIUser.ToList();
            }
        }

        public List<User> GetOnlineUsers()
        {
            using (var ctx = new TTContext())
            {
                IQueryable<User> QIUser = ctx.Users.Where(c => c.CurStatus == "1");
                return QIUser.ToList();
            }
        }
    }
}