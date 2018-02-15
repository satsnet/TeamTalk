using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TeamTalk.Models.Entities;

namespace TeamTalk.Models.EFContext
{
    public class TTContext:DbContext
    {
        public TTContext():base("TTConstr")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Messages> Messages { get; set; }
    }
}