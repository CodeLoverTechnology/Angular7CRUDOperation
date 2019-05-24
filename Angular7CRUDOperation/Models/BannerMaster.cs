using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular7CRUDOperation.Models
{
    [Table("M_BannerMaster")]
    public class BannerMaster
    {
        [Key]
        public int BannerID { get; set; }
        public string BannerTitle { get; set; }
        public string BannerImagesPath { get; set; }
        public string SubTitle { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
