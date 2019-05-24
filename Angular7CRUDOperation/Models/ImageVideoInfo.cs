using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular7CRUDOperation.Models
{
    [Table("T_ImageVideoInfo")]
    public class ImageVideoInfo
    {
        [Key]
        public int FileID { get; set; }
        public int Category { get; set; }
        public string FileName { get; set; }
        public int FileType { get; set; }
        public int FileUploadForPage { get; set; }
        public string Title { get; set; }
        public string FileImagePath { get; set; }
        public string VideoFilePathOrLink { get; set; }
        public string Remarks { get; set; }
        public bool IsNew { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
