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
    public class StudentMasterInfoController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("StudentMasterList")]
        public async Task<IActionResult> StudentMasterList()
        {
            try
            {
                var StudentMasterModel = db.studentMasterInfo.ToList().OrderByDescending(x => x.StudentID).Take(50);
                return Ok(StudentMasterModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("StudentMasterDetails/{id}")]
        public async Task<IActionResult> StudentMasterDetails(int id)
        {
            try
            {
                var StudentMasterModel = db.studentMasterInfo.SingleOrDefault(x => x.StudentID == id);
                return Ok(StudentMasterModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateStudentMaster")]
        public async Task<IActionResult> CreateStudentMaster([FromBody] StudentMasterInfo StudentMasterModel)
        {
            try
            {
                //bannerMaster.EnquiryID = 0;
                StudentMasterModel.CreatedBy = "Admin";
                StudentMasterModel.CreatedDate = DateTime.Now;
                StudentMasterModel.ModifiedBy = "Admin";
                StudentMasterModel.ModifiedDate = DateTime.Now;
                StudentMasterModel.Active = true;
                db.studentMasterInfo.Add(StudentMasterModel);
                db.SaveChanges();
                return Ok(StudentMasterModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("UpdateStudentMaster")]
        public async Task<IActionResult> UpdateStudentMaster([FromBody] StudentMasterInfo StudentMasterModel)
        {
            try
            {
                StudentMasterModel.ModifiedBy = "Admin";
                StudentMasterModel.ModifiedDate = DateTime.Now;

                db.Entry(StudentMasterModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(StudentMasterModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteStudentMaster/{id}")]
        public async Task<IActionResult> DeleteStudentMaster(int id)
        {
            try
            {
                db.Remove(db.studentMasterInfo.Find(id));
                db.SaveChanges();
                return Ok("Student Master ID : " + id + " has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}