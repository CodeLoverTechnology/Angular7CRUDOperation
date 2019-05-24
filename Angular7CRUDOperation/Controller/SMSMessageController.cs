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
    public class SMSMessageController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("SMSMessageList")]
        public async Task<IActionResult> SMSMessageList()
        {
            try
            {
                var SMSMessageListModel = db.sMSMessageMasters.ToList().OrderByDescending(x => x.SMSID).Take(50);
                return Ok(SMSMessageListModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("SMSMessageDetails/{id}")]
        public async Task<IActionResult> SMSMessageDetails(int id)
        {
            try
            {
                var BannerModel = db.sMSMessageMasters.SingleOrDefault(x => x.SMSID == id);
                return Ok(BannerModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateSMSMessage")]
        public async Task<IActionResult> CreateSMSMessage([FromBody] SMSMessageMaster sMSMessage)
        {
            try
            {
                BalCommonCode.CommonFunctionNIAS.SendSMS(sMSMessage.ContactNo, sMSMessage.Message);
                sMSMessage.CreatedBy = "Admin";
                sMSMessage.CreatedDate = DateTime.Now;
                sMSMessage.ModifiedBy = "Admin";
                sMSMessage.ModifiedDate = DateTime.Now;
                sMSMessage.Active = true;
                db.sMSMessageMasters.Add(sMSMessage);
                db.SaveChanges();
                return Ok(sMSMessage);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("UpdateSMSMessage")]
        public async Task<IActionResult> UpdateSMSMessage([FromBody] SMSMessageMaster sMSMessage)
        {
            try
            {
                sMSMessage.ModifiedBy = "Admin";
                sMSMessage.ModifiedDate = DateTime.Now;

                db.Entry(sMSMessage).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(sMSMessage);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteSMSMessage/{id}")]
        public async Task<IActionResult> DeleteSMSMessage(int id)
        {
            try
            {
                db.Remove(db.sMSMessageMasters.Find(id));
                db.SaveChanges();
                return Ok("SMS Message ID : " + id + " has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}