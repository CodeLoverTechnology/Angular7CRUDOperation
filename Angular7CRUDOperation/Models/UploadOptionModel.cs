using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular7CRUDOperation.Models
{
    [Table("M_UploadOptionMaster")]
    public class UploadOptionMaster
    {
        [Key]
        public int UploadOptionID { get; set; }
     public string UploadName { get; set; }
     public string UploadingPath { get; set; }
     public string Remarks { get; set; }
     public bool IsNew { get; set; }
     public string CreatedBy { get; set; }
     public DateTime CreatedDate { get; set; }
     public string ModifiedBy { get; set; }
     public DateTime ModifiedDate { get; set; }
     public bool Active { get; set; }
    }
}
