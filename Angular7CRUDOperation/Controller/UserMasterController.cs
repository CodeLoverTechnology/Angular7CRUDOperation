using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Angular7CRUDOperation.Models;

namespace Angular7CRUDOperation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMasterController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("UserMasterList")]
        public async Task<IActionResult> UserMasterList()
        {
            try
            {
                var UserMasterListModel = db.userMaster.ToList().OrderByDescending(x => x.UserID).Take(50);
                return Ok(UserMasterListModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("UserLogin")]
        public async Task<IActionResult> UserLogin([FromBody] UserMaster UserMasterModel)
        {
            try
            {
                var UserMasterListModel = db.userMaster.Where(x=>x.UserEmailID== UserMasterModel.UserEmailID && x.Password== UserMasterModel.Password).ToList();
                return Ok(UserMasterListModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Produces("application/json")]
        [HttpGet("UserMasterDetails/{id}")]
        public async Task<IActionResult> UserMasterDetails(int id)
        {
            try
            {
                var UserMasterModel = db.userMaster.SingleOrDefault(x => x.UserID == id);
                return Ok(UserMasterModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateUserMaster")]
        public async Task<IActionResult> CreateUserMaster([FromBody] UserMaster UserMasterModel)
        {
            try
            {
                UserMasterModel.CreatedBy = "Admin";
                UserMasterModel.CreatedDate = DateTime.Now;
                UserMasterModel.ModifiedBy = "Admin";
                UserMasterModel.ModifiedDate = DateTime.Now;
                UserMasterModel.Active = true;
                db.userMaster.Add(UserMasterModel);
                db.SaveChanges();
                return Ok(UserMasterModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("UpdateUserMaster")]
        public async Task<IActionResult> UpdateUserMaster([FromBody] UserMaster UserMasterModel)
        {
            try
            {
                UserMasterModel.ModifiedBy = "Admin";
                UserMasterModel.ModifiedDate = DateTime.Now;

                db.Entry(UserMasterModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(UserMasterModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteUserMaster/{id}")]
        public async Task<IActionResult> DeleteUserMaster(int id)
        {
            try
            {
                db.Remove(db.userMaster.Find(id));
                db.SaveChanges();
                return Ok("User Master ID : " + id + " has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}