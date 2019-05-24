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
    public class VideoLecturesController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("VideoLecturesList")]
        public async Task<IActionResult> VideoLecturesList()
        {
            try
            {
                var VideoLecturesListModel = db.videoLectures.ToList().OrderByDescending(x => x.VideoID).Take(50);
                return Ok(VideoLecturesListModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("VideoLecturesDetails/{id}")]
        public async Task<IActionResult> VideoLecturesDetails(int id)
        {
            try
            {
                var VideoLecturesModel = db.videoLectures.SingleOrDefault(x => x.VideoID == id);
                return Ok(VideoLecturesModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateVideoLectures")]
        public async Task<IActionResult> CreateVideoLectures([FromBody] VideoLectures videoLectures)
        {
            try
            {
                //bannerMaster.EnquiryID = 0;
                videoLectures.CreatedBy = "Admin";
                videoLectures.CreatedDate = DateTime.Now;
                videoLectures.ModifiedBy = "Admin";
                videoLectures.ModifiedDate = DateTime.Now;
                videoLectures.Active = true;
                db.videoLectures.Add(videoLectures);
                db.SaveChanges();
                return Ok(videoLectures);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("UpdateVideoLectures")]
        public async Task<IActionResult> UpdateVideoLectures([FromBody] VideoLectures videoLectures)
        {
            try
            {
                videoLectures.ModifiedBy = "Admin";
                videoLectures.ModifiedDate = DateTime.Now;

                db.Entry(videoLectures).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(videoLectures);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteVideoLectures/{id}")]
        public async Task<IActionResult> DeleteVideoLectures(int id)
        {
            try
            {
                db.Remove(db.videoLectures.Find(id));
                db.SaveChanges();
                return Ok("Video Lectures ID : " + id + " has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}