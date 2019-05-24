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
    public class BatchDetailsController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("BatchDetailsList")]
        public async Task<IActionResult> BatchDetailsList()
        {
            try
            {
                var BatchDetailsListModel = db.batchDetails.ToList().OrderByDescending(x => x.BatchID).Take(50);
                return Ok(BatchDetailsListModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("BatchInfoDetails/{id}")]
        public async Task<IActionResult> BatchInfoDetails(int id)
        {
            try
            {
                var BatchModel = db.batchDetails.SingleOrDefault(x => x.BatchID == id);
                return Ok(BatchModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateBatchDetails")]
        public async Task<IActionResult> CreateBatchDetails([FromBody] BatchDetails objbatchDetails)
        {
            try
            {
                //bannerMaster.EnquiryID = 0;
                objbatchDetails.CreatedBy = "Admin";
                objbatchDetails.CreatedDate = DateTime.Now;
                objbatchDetails.ModifiedBy = "Admin";
                objbatchDetails.ModifiedDate = DateTime.Now;
                objbatchDetails.Active = true;
                db.batchDetails.Add(objbatchDetails);
                db.SaveChanges();
                return Ok(objbatchDetails);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("UpdateBatchDetails")]
        public async Task<IActionResult> UpdateBatchDetails([FromBody] BatchDetails objbatchDetails)
        {
            try
            {
                objbatchDetails.ModifiedBy = "Admin";
                objbatchDetails.ModifiedDate = DateTime.Now;

                db.Entry(objbatchDetails).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(objbatchDetails);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteBatchDetails/{id}")]
        public async Task<IActionResult> DeleteBatchDetails(int id)
        {
            try
            {
                db.Remove(db.batchDetails.Find(id));
                db.SaveChanges();
                return Ok("BatchDetails ID : " + id + " has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}