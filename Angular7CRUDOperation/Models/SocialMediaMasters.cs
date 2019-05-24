using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular7CRUDOperation.Models
{
    [Table("M_SocialMediaMasters")]
    public class SocialMediaMasters
    {
        [Key]
        public int SocialMediaID { get; set; }
        public string SocialMediaName { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public int Sequence { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
