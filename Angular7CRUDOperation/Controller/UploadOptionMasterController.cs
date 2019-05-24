using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular7CRUDOperation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Angular7CRUDOperation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadOptionMasterController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("UploadOptionMasterList")]
        public async Task<IActionResult> UploadOptionMasterList()
        {
            try
            {
                var UploadOptionMasterListModel = db.uploadOptionMasters.ToList().OrderByDescending(x => x.UploadOptionID).Take(50);
                return Ok(UploadOptionMasterListModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("UploadOptionDetails/{id}")]
        public async Task<IActionResult> UploadOptionDetails(int id)
        {
            try
            {
                var UploadOptionModel = db.uploadOptionMasters.SingleOrDefault(x => x.UploadOptionID == id);
                return Ok(UploadOptionModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateUploadOption")]
        public async Task<IActionResult> CreateUploadOption([FromBody] UploadOptionMaster uploadOptionModel)
        {
            try
            {
                //bannerMaster.EnquiryID = 0;
                uploadOptionModel.CreatedBy = "Admin";
                uploadOptionModel.CreatedDate = DateTime.Now;
                uploadOptionModel.ModifiedBy = "Admin";
                uploadOptionModel.ModifiedDate = DateTime.Now;
                uploadOptionModel.Active = true;
                db.uploadOptionMasters.Add(uploadOptionModel);
                db.SaveChanges();
                return Ok(uploadOptionModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("UpdateUploadOption")]
        public async Task<IActionResult> UpdateUploadOption([FromBody] UploadOptionMaster uploadOptionMaster)
        {
            try
            {
                uploadOptionMaster.ModifiedBy = "Admin";
                uploadOptionMaster.ModifiedDate = DateTime.Now;
                db.Entry(uploadOptionMaster).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(uploadOptionMaster);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteUploadOption/{id}")]
        public async Task<IActionResult> DeleteUploadOption(int id)
        {
            try
            {
                db.Remove(db.uploadOptionMasters.Find(id));
                db.SaveChanges();
                return Ok("Upload Option ID : " + id + " has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}