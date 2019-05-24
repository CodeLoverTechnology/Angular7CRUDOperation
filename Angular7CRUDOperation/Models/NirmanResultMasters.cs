using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular7CRUDOperation.Models
{
    [Table("T_NirmanResultMasters")]
    public class NirmanResultMasters
    {
        [Key]
        public int ResultID{ get; set; }
      public string ExamName{ get; set; }
      public string ExamYear{ get; set; }
      public string CandidateName{ get; set; }
      public string CandidateRank{ get; set; }
      public string CandiatePicPath{ get; set; }
      public string CandiateReview{ get; set; }
      public string Remarks{ get; set; }
      public string CreatedBy{ get; set; }
      public DateTime CreatedDate{ get; set; }
      public string ModifiedBy{ get; set; }
      public DateTime ModifiedDate{ get; set; }
      public bool Active{ get; set; }
      public bool IsNew{ get; set; }
    }
}
