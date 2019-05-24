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
    public class CategoryMasterController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("CategoryMastersList")]
        public async Task<IActionResult> CategoryMastersList()
        {
            try
            {
                var categoryMastersList = db.categoryMasters.ToList().OrderByDescending(x=>x.CategoryID).Take(50);
                return Ok(categoryMastersList);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("CategoryMastersDetails/{id}")]
        public async Task<IActionResult> CategoryMastersDetails(int id)
        {
            try
            {
                var categoryMastersDetails = db.categoryMasters.SingleOrDefault(x => x.CategoryID == id);
                return Ok(categoryMastersDetails);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateCategoryMaster")]
        public async Task<IActionResult> CreateCategoryMaster([FromBody] CategoryMaster categoryMaster)
        {
            try
            {
                //enquiryModel.EnquiryID = 0;
                categoryMaster.CreatedBy = "Admin";
                categoryMaster.CreatedDate = DateTime.Now;
                categoryMaster.ModifiedBy = "Admin";
                categoryMaster.ModifiedDate = DateTime.Now;
                categoryMaster.Active = true;
                db.categoryMasters.Add(categoryMaster);
                db.SaveChanges();
                return Ok(categoryMaster);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("UpdateCategoryMaster")]
        public async Task<IActionResult> UpdateCategoryMaster([FromBody] CategoryMaster categoryMaster)
        {
            try
            {
                categoryMaster.ModifiedBy = "Admin";
                categoryMaster.ModifiedDate = DateTime.Now;
                db.Entry(categoryMaster).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(categoryMaster);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteCategoryMaster/{id}")]
        public async Task<IActionResult> DeleteCategoryMaster(int id)
        {
            try
            {
                db.Remove(db.categoryMasters.Find(id));
                db.SaveChanges();
                return Ok("CategoryMaster ID : "+ id +" has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}