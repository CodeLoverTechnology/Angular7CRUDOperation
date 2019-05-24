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
    public class CourseMasterController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("CourseMasterList")]
        public async Task<IActionResult> CourseMasterList()
        {
            try
            {
                var CourseMasterModel = db.courseMasters.ToList().OrderByDescending(x=>x.CourseID).Take(50);
                return Ok(CourseMasterModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("CourseMasterDetails/{id}")]
        public async Task<IActionResult> CourseMasterDetails(int id)
        {
            try
            {
                var CourseMasterModel = db.courseMasters.SingleOrDefault(x => x.CourseID == id);
                return Ok(CourseMasterModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CourseMasterCreate")]
        public async Task<IActionResult> CourseMasterCreate([FromBody] CourseMaster courseMaster)
        {
            try
            {
                //CourseMaster.EnquiryID = 0;
                courseMaster.CreatedBy = "Admin";
                courseMaster.CreatedDate = DateTime.Now;
                courseMaster.ModifiedBy = "Admin";
                courseMaster.ModifiedDate = DateTime.Now;
                courseMaster.Active = true;
                db.courseMasters.Add(courseMaster);
                db.SaveChanges();
                return Ok(courseMaster);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("CourseMasterUpdate")]
        public async Task<IActionResult> CourseMasterUpdate([FromBody] CourseMaster courseMaster)
        {
            try
            {
                courseMaster.ModifiedBy = "Admin";
                courseMaster.ModifiedDate = DateTime.Now;
                db.Entry(courseMaster).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(courseMaster);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteCourseMaster/{id}")]
        public async Task<IActionResult> DeleteCourseMaster(int id)
        {
            try
            {
                db.Remove(db.courseMasters.Find(id));
                db.SaveChanges();
                return Ok("Course ID : " + id + " has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}