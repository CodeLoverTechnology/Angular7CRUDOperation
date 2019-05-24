using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular7CRUDOperation.Models
{
    [Table("M_MasterInfo")]
    public class MasterInfo
    {
       [Key]
        public int MasterID { get; set; }
        public string MasterValue { get; set; }
        public string MasterTable { get; set; }
        public int Sequence { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
