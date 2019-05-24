using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular7CRUDOperation.Models
{
    [Table("T_BatchTopicDetails")]
    public class BatchTopicDetails
    {
        [Key]
       public int BatchTopicID{ get; set; }
     public int BatchID{ get; set; }
     public string TopicDate{ get; set; }
     public string Topic{ get; set; }
     public string TopicSummary{ get; set; }
     public string Location{ get; set; }
     public int FacultyID{ get; set; }
     public string TpoicPicPath{ get; set; }
     public bool IsNew{ get; set; }
     public string Remarks{ get; set; }
     public string CreatedBy{ get; set; }
     public DateTime CreatedDate{ get; set; }
     public string ModifiedBy{ get; set; }
     public DateTime ModifiedDate{ get; set; }
     public bool Active{ get; set; }


    }
}
