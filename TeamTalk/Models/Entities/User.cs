using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeamTalk.Models.Entities
{
    [Table("tblUser")]
   public partial class User
    {
        [Key]
        public int Uid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DispName { get; set; }
        public string DispImg { get; set; }

        public string CurStatus { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }

}
