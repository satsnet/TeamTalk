using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TeamTalk.Models.EFContext;
using TeamTalk.Models.Entities;
using TeamTalk.Models.ITeam;

namespace TeamTalk.Models.BAL
{
    public class BMessages : IComms
    {
        public bool DeleteMessage(string Username, int msgId)
        {
            throw new NotImplementedException();
        }

        public bool FavoriteMessage(string Username, int msgId)
        {
            throw new NotImplementedException();
        }

        public List<Messages> LoadMessages(string FromUserName,string ToUserName,DateTime startDate)
        {
            List<Messages> msgs = new List<Messages>();

            try
            {
                using (var ctx = new TTContext())
                {
                    IQueryable<Messages> msg = ctx.Messages.Where(c => (c.FromUser == FromUserName && c.ToUser == ToUserName) || (c.FromUser == ToUserName && c.ToUser == FromUserName) && (c.CreateDate <= startDate && c.CreateDate >= EntityFunctions.AddDays(startDate,-1)));
                     msgs = msg.ToList();

                }

            }
            catch (Exception)
            {
                throw;
            }


            return msgs;
        }

        public string SendMessage(Messages msg)
        {
            string returnString = string.Empty;

            try
            {

                using (var ctx = new TTContext())
                {
                    ctx.Messages.Add(msg);
                    returnString = ctx.SaveChanges().ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return returnString;
        }
    }
}