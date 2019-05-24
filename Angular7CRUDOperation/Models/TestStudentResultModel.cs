using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular7CRUDOperation.Models
{
    [Table("T_TestStudentResult")]
    public class TestStudentResultModel
    {
        [Key]
        public int TestResultID { get; set; }
        public string StudentName { get; set; }
        public string ContactNo { get; set; }
        public string Email_ID { get; set; }
        public string TestTitle { get; set; }
        public string Rank { get; set; }
        public string ObtainNumber { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
