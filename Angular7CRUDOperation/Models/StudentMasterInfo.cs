using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Angular7CRUDOperation.Models
{
    [Table("M_StudentMasterInfo")]
    public class StudentMasterInfo
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }
        public int Course { get; set; }
        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        public string AdmissionDate { get; set; }
        public string ValidityStartDate { get; set; }
        public string ValidityEndDate { get; set; }
        public string Branch { get; set; }
        public string Password { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
