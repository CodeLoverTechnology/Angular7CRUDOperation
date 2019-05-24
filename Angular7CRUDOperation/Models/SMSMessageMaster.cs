using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular7CRUDOperation.Models
{
    [Table("T_SMSMessageMaster")]
    public class SMSMessageMaster
    {
        [Key]
        public int SMSID { get; set; }
        public string ContactNo { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
