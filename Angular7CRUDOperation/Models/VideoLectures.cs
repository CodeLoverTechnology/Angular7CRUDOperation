using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular7CRUDOperation.Models
{
    [Table("T_VideoLectures")]
    public class VideoLectures
    {
        [Key]
        public int VideoID { get; set; }
        public int VideoType { get; set; }
        public string VideoTitle { get; set; }
        public int VideoCategory { get; set; }
        public string VideoPath { get; set; }
        public int Faculty { get; set; }
        public int NoOfViews { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
