using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular7CRUDOperation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Angular7CRUDOperation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("UserLogin")]
        public async Task<IActionResult> UserLogin(string UserLoginID, string Password)
        {
            try
            {                
                var StudentMasterModel = db.studentMasterInfo.Where(x =>x.StudentCode == UserLoginID && x.Password==Password);
                
                if(StudentMasterModel !=null)
                {
                    var UserMasterModel = db.userMaster.Where(x => x.UserEmailID == UserLoginID && x.Password == Password);
                    if(UserMasterModel!=null)
                    {
                        var FacultyMasterModel = db.facultyMaster.Where(x => x.EmailID == UserLoginID && x.Password == Password);
                        return Ok(FacultyMasterModel);
                    }
                    return Ok(UserMasterModel);
                }
                return Ok(StudentMasterModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}