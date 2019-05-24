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
    public class TestStudentResultController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("TestStudentResultList")]
        public async Task<IActionResult> TestStudentResultList()
        {
            try
            {
                var testStudentResultListModel = db.testStudentResult.ToList().OrderByDescending(x => x.TestResultID).Take(50);
                return Ok(testStudentResultListModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("TestStudentResultDetails/{id}")]
        public async Task<IActionResult> TestStudentResultDetails(int id)
        {
            try
            {
                var TestStudentResultModel = db.testStudentResult.SingleOrDefault(x => x.TestResultID == id);
                return Ok(TestStudentResultModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateTestStudentResult")]
        public async Task<IActionResult> CreateTestStudentResult([FromBody] TestStudentResultModel testStudentResultModel)
        {
            try
            {
                //bannerMaster.EnquiryID = 0;
                testStudentResultModel.CreatedBy = "Admin";
                testStudentResultModel.CreatedDate = DateTime.Now;
                testStudentResultModel.ModifiedBy = "Admin";
                testStudentResultModel.ModifiedDate = DateTime.Now;
                testStudentResultModel.Active = true;
                db.testStudentResult.Add(testStudentResultModel);
                db.SaveChanges();
                return Ok(testStudentResultModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("UpdateTestStudentResult")]
        public async Task<IActionResult> UpdateTestStudentResult([FromBody] TestStudentResultModel testStudentResultModel)
        {
            try
            {
                testStudentResultModel.ModifiedBy = "Admin";
                testStudentResultModel.ModifiedDate = DateTime.Now;

                db.Entry(testStudentResultModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(testStudentResultModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteTestStudentResult/{id}")]
        public async Task<IActionResult> DeleteTestStudentResult(int id)
        {
            try
            {
                db.Remove(db.testStudentResult.Find(id));
                db.SaveChanges();
                return Ok("Test Student Result : " + id + " has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}