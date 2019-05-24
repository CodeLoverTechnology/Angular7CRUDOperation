using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular7CRUDOperation.Models
{
    [Table("T_CurrentAffairsMasters")]
    public class CurrentAffairsMasters
    {
        [Key]
        public int CurrentAffairsID { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string PDFPath { get; set; }
        public string CurrentAffairsImgPath { get; set; }
        public string VideoLink { get; set; }
        public bool IsNew { get; set; }
        public int NoOfView { get; set; }
        public string SpecialRemarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
