using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular7CRUDOperation.Models
{
    [Table("M_UserMaster")]
    public class UserMaster
    {
        [Key]
        public int UserID { get; set; }
        public string UserEmailID { get; set; }
        public string UserName { get; set; }
        public string ContactNo { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Password { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
