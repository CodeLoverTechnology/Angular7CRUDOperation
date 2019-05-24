using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular7CRUDOperation.Models
{
    public class EmailModel
    {
        public string ToEmailID { get; set; }
        public string FromEmailID { get; set; }
        public string CcEmailID { get; set; }
        public string BccEmailID { get; set; }
        public string MailBody { get; set; }
        public bool IsHtml { get; set; }
        public string EmailSubject { get; set; }  
        
        public string UserName { get; set; }
        public string ContactNo { get; set; }
    }
}
