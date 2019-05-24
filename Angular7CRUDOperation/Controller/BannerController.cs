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
    public class BannerController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("BannerList")]
        public async Task<IActionResult> BannerList()
        {
            try
            {
                var BannerListModel = db.bannerMasters.ToList().OrderByDescending(x=>x.BannerID).Take(50);
                return Ok(BannerListModel);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("BannerDetails/{id}")]
        public async Task<IActionResult> BannerDetails(int id)
        {
            try
            {
                var BannerModel = db.bannerMasters.SingleOrDefault(x => x.BannerID == id);
                return Ok(BannerModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateBanner")]
        public async Task<IActionResult> CreateBanner([FromBody] BannerMaster BannerModel)
        {
            try
            {
                //bannerMaster.EnquiryID = 0;
                BannerModel.CreatedBy = "Admin";
                BannerModel.CreatedDate = DateTime.Now;
                BannerModel.ModifiedBy = "Admin";
                BannerModel.ModifiedDate = DateTime.Now;
                BannerModel.Active = true;
                db.bannerMasters.Add(BannerModel);
                db.SaveChanges();
                return Ok(BannerModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("UpdateBanner")]
        public async Task<IActionResult> UpdateBanner([FromBody] BannerMaster bannerMaster)
        {
            try
            {
                bannerMaster.ModifiedBy = "Admin";
                bannerMaster.ModifiedDate = DateTime.Now;

                db.Entry(bannerMaster).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(bannerMaster);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteBanner/{id}")]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            try
            {
                db.Remove(db.bannerMasters.Find(id));
                db.SaveChanges();
                return Ok("Banner ID : "+ id +" has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}