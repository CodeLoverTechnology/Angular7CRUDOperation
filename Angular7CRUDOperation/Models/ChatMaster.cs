using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular7CRUDOperation.Models
{
    [Table("T_NirmanChatMaster")]
    public class ChatMaster
    {
        [Key]
        public int UserChatID { get; set; }
        public string ChatMessage { get; set; }
        public string UserIP { get; set; }
        public string ReplyMessage { get; set; }
        public string ReplyBy { get; set; }
        public string Remarks { get; set; }
        public bool IsRead { get; set; }
        public string CraatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
