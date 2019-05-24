using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular7CRUDOperation.Models
{
    public class LoginModel
    {
        public int ID { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string LoginAs { get; set; }
        public string ProfilePic { get; set; }
        public string UserName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
    }
}
