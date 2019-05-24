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
    public class NotificationMasterController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("NotificationMasterList")]
        public async Task<IActionResult> NotificationMasterList()
        {
            try
            {
                var NotificationMasterListModel = db.notificationMaster.ToList().OrderByDescending(x => x.NotificationID).Take(50);
                return Ok(NotificationMasterListModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("NotificationMasterDetails/{id}")]
        public async Task<IActionResult> NotificationMasterDetails(int id)
        {
            try
            {
                var NotificationMasterModel = db.notificationMaster.SingleOrDefault(x => x.NotificationID == id);
                return Ok(NotificationMasterModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateNotificationMaster")]
        public async Task<IActionResult> CreateNotificationMaster([FromBody] NotificationMaster NotificationMasterModel)
        {
            try
            {
                //bannerMaster.EnquiryID = 0;
                NotificationMasterModel.CreatedBy = "Admin";
                NotificationMasterModel.CreatedDate = DateTime.Now;
                NotificationMasterModel.ModifiedBy = "Admin";
                NotificationMasterModel.ModifiedDate = DateTime.Now;
                NotificationMasterModel.Active = true;
                db.notificationMaster.Add(NotificationMasterModel);
                db.SaveChanges();
                return Ok(NotificationMasterModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("UpdateNotificationMaster")]
        public async Task<IActionResult> UpdateNotificationMaster([FromBody] NotificationMaster NotificationMasterModel)
        {
            try
            {
                NotificationMasterModel.ModifiedBy = "Admin";
                NotificationMasterModel.ModifiedDate = DateTime.Now;

                db.Entry(NotificationMasterModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(NotificationMasterModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteNotificationMaster/{id}")]
        public async Task<IActionResult> DeleteNotificationMaster(int id)
        {
            try
            {
                db.Remove(db.notificationMaster.Find(id));
                db.SaveChanges();
                return Ok("Notification Master ID : " + id + " has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}