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
    public class BatchTopicDetailsController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("BatchTopicDetailsList")]
        public async Task<IActionResult> BatchTopicDetailsList()
        {
            try
            {
                var BatchTopicDetailsListModel = db.batchTopicDetails.ToList().OrderByDescending(x => x.BatchTopicID).Take(50);
                return Ok(BatchTopicDetailsListModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("BatchTopicInfoDetails/{id}")]
        public async Task<IActionResult> BatchTopicInfoDetails(int id)
        {
            try
            {
                var BatchTopicDetailsModel = db.batchTopicDetails.SingleOrDefault(x => x.BatchTopicID == id);
                return Ok(BatchTopicDetailsModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateBatchTopicDetails")]
        public async Task<IActionResult> CreateBatchTopicDetails([FromBody] BatchTopicDetails ObjBatchTopicDetails)
        {
            try
            {
                //bannerMaster.EnquiryID = 0;
                ObjBatchTopicDetails.CreatedBy = "Admin";
                ObjBatchTopicDetails.CreatedDate = DateTime.Now;
                ObjBatchTopicDetails.ModifiedBy = "Admin";
                ObjBatchTopicDetails.ModifiedDate = DateTime.Now;
                ObjBatchTopicDetails.Active = true;
                db.batchTopicDetails.Add(ObjBatchTopicDetails);
                db.SaveChanges();
                return Ok(ObjBatchTopicDetails);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("UpdateBatchTopicDetails")]
        public async Task<IActionResult> UpdateBatchTopicDetails([FromBody] BatchTopicDetails batchTopicDetails)
        {
            try
            {
                batchTopicDetails.ModifiedBy = "Admin";
                batchTopicDetails.ModifiedDate = DateTime.Now;
                db.Entry(batchTopicDetails).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(batchTopicDetails);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteBatchTopicDetails/{id}")]
        public async Task<IActionResult> DeleteBatchTopicDetails(int id)
        {
            try
            {
                db.Remove(db.batchTopicDetails.Find(id));
                db.SaveChanges();
                return Ok("Batch Topic Details ID : " + id + " has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}