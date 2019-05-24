using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular7CRUDOperation.Models
{
    [Table("T_FileUploadedMaster")]
    public class FileUploadedMaster
    {
        [Key]
        public int UploadID { get; set; }
     public string UploadedFileName { get; set; }
     public string UploadedFilePath { get; set; }
     public string Description { get; set; }
     public string CreatedBy { get; set; }
     public DateTime CreatedDate { get; set; }
     public string ModifiedBy { get; set; }
     public DateTime ModifiedDate { get; set; }
     public bool Active { get; set; }
    }
}
