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
    public class SocialMediaMastersController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("SocialMediaMastersList")]
        public async Task<IActionResult> SocialMediaMastersList()
        {
            try
            {
                var SocialMediaMastersListModel = db.socialMediaMasters.ToList().OrderByDescending(x=>x.SocialMediaID).Take(50);
                return Ok(SocialMediaMastersListModel);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("SocialMediaMastersDetails/{id}")]
        public async Task<IActionResult> SocialMediaMastersDetails(int id)
        {
            try
            {
                var SocialMediaMastersModel = db.socialMediaMasters.SingleOrDefault(x => x.SocialMediaID == id);
                return Ok(SocialMediaMastersModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateSocialMediaMasters")]
        public async Task<IActionResult> CreateSocialMediaMasters([FromBody] SocialMediaMasters socialMediaMasters)
        {
            try
            {
                //enquiryModel.EnquiryID = 0;
                socialMediaMasters.CreatedBy = "Admin";
                socialMediaMasters.CreatedDate = DateTime.Now;
                socialMediaMasters.ModifiedBy = "Admin";
                socialMediaMasters.ModifiedDate = DateTime.Now;
                socialMediaMasters.Active = true;
                db.socialMediaMasters.Add(socialMediaMasters);
                db.SaveChanges();
                return Ok(socialMediaMasters);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("UpdateSocialMediaMasters")]
        public async Task<IActionResult> UpdateSocialMediaMasters([FromBody] SocialMediaMasters socialMediaMasters)
        {
            try
            {
                socialMediaMasters.ModifiedBy = "Admin";
                socialMediaMasters.ModifiedDate = DateTime.Now;

                db.Entry(socialMediaMasters).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(socialMediaMasters);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteSocialMediaMasters/{id}")]
        public async Task<IActionResult> DeleteSocialMediaMasters(int id)
        {
            try
            {
                db.Remove(db.socialMediaMasters.Find(id));
                db.SaveChanges();
                return Ok("Social Media ID : "+ id +" has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}