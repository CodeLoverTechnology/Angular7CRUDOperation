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
    public class FacultyMasterController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("FacultyMasterList")]
        public async Task<IActionResult> FacultyMasterList()
        {
            try
            {
                var FacultyMasterListModel = db.facultyMaster.ToList().OrderByDescending(x => x.FacultyID).Take(50);
                return Ok(FacultyMasterListModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("FacultyMasterDetails/{id}")]
        public async Task<IActionResult> FacultyMasterDetails(int id)
        {
            try
            {
                var FacultyMasterModel = db.facultyMaster.SingleOrDefault(x => x.FacultyID == id);
                return Ok(FacultyMasterModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateFacultyMaster")]
        public async Task<IActionResult> CreateFacultyMaster([FromBody] FacultyMaster facultyMaster)
        {
            try
            {
                //bannerMaster.EnquiryID = 0;
                facultyMaster.CreatedBy = "Admin";
                facultyMaster.CreatedDate = DateTime.Now;
                facultyMaster.ModifiedBy = "Admin";
                facultyMaster.ModifiedDate = DateTime.Now;
                facultyMaster.Active = true;
                db.facultyMaster.Add(facultyMaster);
                db.SaveChanges();
                return Ok(facultyMaster);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("UpdateFacultyMaster")]
        public async Task<IActionResult> UpdateFacultyMaster([FromBody] FacultyMaster facultyMaster)
        {
            try
            {
                facultyMaster.ModifiedBy = "Admin";
                facultyMaster.ModifiedDate = DateTime.Now;

                db.Entry(facultyMaster).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(facultyMaster);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteFacultyMaster/{id}")]
        public async Task<IActionResult> DeleteFacultyMaster(int id)
        {
            try
            {
                db.Remove(db.facultyMaster.Find(id));
                db.SaveChanges();
                return Ok("Faculty Master ID : " + id + " has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}