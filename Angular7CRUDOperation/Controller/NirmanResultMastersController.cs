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
    public class NirmanResultMastersController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("NirmanResultMastersList")]
        public async Task<IActionResult> NirmanResultMastersList()
        {
            try
            {
                var NirmanResultMastersListModel = db.nirmanResultMasters.ToList().OrderByDescending(x => x.ResultID).Take(50);
                return Ok(NirmanResultMastersListModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("NirmanResultMastersDetails/{id}")]
        public async Task<IActionResult> NirmanResultMastersDetails(int id)
        {
            try
            {
                var NirmanResultMastersModel = db.nirmanResultMasters.SingleOrDefault(x => x.ResultID == id);
                return Ok(NirmanResultMastersModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateNirmanResultMasters")]
        public async Task<IActionResult> CreateNirmanResultMasters([FromBody] NirmanResultMasters nirmanResultMasters)
        {
            try
            {
                //bannerMaster.EnquiryID = 0;
                nirmanResultMasters.CreatedBy = "Admin";
                nirmanResultMasters.CreatedDate = DateTime.Now;
                nirmanResultMasters.ModifiedBy = "Admin";
                nirmanResultMasters.ModifiedDate = DateTime.Now;
                nirmanResultMasters.Active = true;
                db.nirmanResultMasters.Add(nirmanResultMasters);
                db.SaveChanges();
                return Ok(nirmanResultMasters);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("UpdateNirmanResultMasters")]
        public async Task<IActionResult> UpdateNirmanResultMasters([FromBody] NirmanResultMasters nirmanResultMasters)
        {
            try
            {
                nirmanResultMasters.ModifiedBy = "Admin";
                nirmanResultMasters.ModifiedDate = DateTime.Now;

                db.Entry(nirmanResultMasters).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(nirmanResultMasters);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteNirmanResultMasters/{id}")]
        public async Task<IActionResult> DeleteNirmanResultMasters(int id)
        {
            try
            {
                db.Remove(db.nirmanResultMasters.Find(id));
                db.SaveChanges();
                return Ok("Nirman Result Masters ID : " + id + " has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}