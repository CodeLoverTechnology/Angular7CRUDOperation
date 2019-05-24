using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular7CRUDOperation.BalCommonCode;
using Angular7CRUDOperation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Angular7CRUDOperation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnquiryController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("EnquiryList")]
        public async Task<IActionResult> EnquiryList()
        {
            try
            {
                var EnquiryListModel = db.enquiryList.ToList().OrderByDescending(x=>x.EnquiryID).Take(50);
                return Ok(EnquiryListModel);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("EnquiryDetails/{id}")]
        public async Task<IActionResult> EnquiryDetails(int id)
        {
            try
            {
                var EnquiryModel = db.enquiryList.SingleOrDefault(x => x.EnquiryID == id);
                return Ok(EnquiryModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateEnquiry")]
        public async Task<IActionResult> CreateEnquiry([FromBody] EnquiryModel enquiryModel)
        {
            try
            {
                //enquiryModel.EnquiryID = 0;
                enquiryModel.ReplyMessage = null;
                enquiryModel.CreatedBy = "Admin";
                enquiryModel.CreatedDate = DateTime.Now;
                enquiryModel.ModifiedBy = "Admin";
                enquiryModel.ModifiedDate = DateTime.Now;
                enquiryModel.Active = true;
                db.enquiryList.Add(enquiryModel);
                db.SaveChanges();
                EmailModel emailModel = new EmailModel();
                emailModel.ToEmailID = enquiryModel.EmailID;
                emailModel.UserName = enquiryModel.Name;
                emailModel.ContactNo = enquiryModel.ContactNo;
                emailModel.MailBody = enquiryModel.EnquiryMessage;
                emailModel.UserName = enquiryModel.Name;

                CommonFunctionNIAS.SendEmail(emailModel);
                return Ok(enquiryModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("UpdateEnquiry")]
        public async Task<IActionResult> UpdateEnquiry([FromBody] EnquiryModel enquiryModel)
        {
            try
            {
                enquiryModel.ModifiedBy = "Admin";
                enquiryModel.ModifiedDate = DateTime.Now;

                db.Entry(enquiryModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(enquiryModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteEnquiry/{id}")]
        public async Task<IActionResult> DeleteEnquiry(int id)
        {
            try
            {
                db.Remove(db.enquiryList.Find(id));
                db.SaveChanges();
                return Ok("Enquiry ID : "+ id +" has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}