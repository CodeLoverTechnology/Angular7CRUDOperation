using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular7CRUDOperation.Models
{
    [Table("T_BatchDetails")]
    public class BatchDetails
    {
        [Key]
      public int BatchID{ get; set; }
      public string BatchFor{ get; set; }
      public string BatchCode{ get; set; }
      public string Subject{ get; set; }
      public string Time{ get; set; }
      public int Faculty{ get; set; }
      public string BatchStartDate{ get; set; }
      public string BatchEndDate{ get; set; }
      public int TotalStudents{ get; set; }
      public string Remarks{ get; set; }
      public string CreatedBy{ get; set; }
      public DateTime CreatedDate{ get; set; }
      public string ModifiedBy{ get; set; }
      public DateTime ModifiedDate { get; set; }
      public bool Active{ get; set; }
      public bool IsNew { get; set; }
    }
}
