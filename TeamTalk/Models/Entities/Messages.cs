using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeamTalk.Models.Entities
{
    [Table("tblMessages")]
    public class Messages
    {
        [Key]
        public int MsgId { get; set; }
        public string MessageText { get; set; }
        public string MessageType { get; set; }
        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}