using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular7CRUDOperation.Models
{
    [Table("M_CourseMaster")]
    public class CourseMaster
    {
        [Key]
        public int CourseID { get; set; }
        [ForeignKey("CourseType")]
        public int CourseType { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
