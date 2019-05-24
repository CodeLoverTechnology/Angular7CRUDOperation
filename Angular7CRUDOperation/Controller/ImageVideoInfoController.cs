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
    public class ImageVideoInfoController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("ImageVideoInfoList")]
        public async Task<IActionResult> ImageVideoInfoList()
        {
            try
            {
                var ImageVideoInfoListModel = db.imageVideoInfo.ToList().OrderByDescending(x => x.FileID).Take(50);
                return Ok(ImageVideoInfoListModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("ImageVideoInfoDetails/{id}")]
        public async Task<IActionResult> ImageVideoInfoDetails(int id)
        {
            try
            {
                var ImageVideoInfoModel = db.imageVideoInfo.SingleOrDefault(x => x.FileID == id);
                return Ok(ImageVideoInfoModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateImageVideoInfo")]
        public async Task<IActionResult> CreateImageVideoInfo([FromBody] ImageVideoInfo ImageVideoInfoModel)
        {
            try
            {
                //bannerMaster.EnquiryID = 0;
                ImageVideoInfoModel.CreatedBy = "Admin";
                ImageVideoInfoModel.CreatedDate = DateTime.Now;
                ImageVideoInfoModel.ModifiedBy = "Admin";
                ImageVideoInfoModel.ModifiedDate = DateTime.Now;
                ImageVideoInfoModel.Active = true;
                db.imageVideoInfo.Add(ImageVideoInfoModel);
                db.SaveChanges();
                return Ok(ImageVideoInfoModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("UpdateImageVideoInfo")]
        public async Task<IActionResult> UpdateImageVideoInfo([FromBody] ImageVideoInfo ImageVideoInfoModel)
        {
            try
            {
                ImageVideoInfoModel.ModifiedBy = "Admin";
                ImageVideoInfoModel.ModifiedDate = DateTime.Now;

                db.Entry(ImageVideoInfoModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(ImageVideoInfoModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteImageVideoInfo/{id}")]
        public async Task<IActionResult> DeleteImageVideoInfo(int id)
        {
            try
            {
                db.Remove(db.imageVideoInfo.Find(id));
                db.SaveChanges();
                return Ok("Image/Video Info ID : " + id + " has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}