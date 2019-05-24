using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Angular7CRUDOperation.Models
{
    [Table("T_NotificationMaster")]
    public class NotificationMaster
    {
        [Key]
        public int NotificationID { get; set; }
        public int Category { get; set; }
        public string NotificationTitle { get; set; }
        public string Description { get; set; }
        public string ImagesPath { get; set; }
        public string MoreDetailsFilePath { get; set; }
        public bool IsNew { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
