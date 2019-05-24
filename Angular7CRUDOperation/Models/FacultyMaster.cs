using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular7CRUDOperation.Models
{
    [Table("M_FacultyMaster")]
    public class FacultyMaster
    {
        [Key]
        public int FacultyID { get; set; }
        public string FacultyName { get; set; }
        public string Subject { get; set; }
        public string RefeenceName { get; set; }
        public string Address { get; set; }
        public string EmailID { get; set; }
        public string ContactNo { get; set; }
        public string Remarks { get; set; }
        public string Password { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
