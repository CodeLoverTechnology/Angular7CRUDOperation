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
    public class SubCategoryMasterController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("SubCategoryMasterList")]
        public async Task<IActionResult> SubCategoryMasterList()
        {
            try
            {
                var SubCategoryMasterListModel = db.subCategoryMasters.ToList().OrderByDescending(x=>x.SubCategoryID).Take(50);
                return Ok(SubCategoryMasterListModel);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("SubCategoryMasterDetails/{id}")]
        public async Task<IActionResult> SubCategoryMasterDetails(int id)
        {
            try
            {
                var SubCategoryMasterModel = db.subCategoryMasters.SingleOrDefault(x => x.SubCategoryID == id);
                return Ok(SubCategoryMasterModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateSubCategoryMaster")]
        public async Task<IActionResult> CreateSubCategoryMaster([FromBody] SubCategoryMaster subCategoryMaster)
        {
            try
            {
                subCategoryMaster.CreatedBy = "Admin";
                subCategoryMaster.CreatedDate = DateTime.Now;
                subCategoryMaster.ModifiedBy = "Admin";
                subCategoryMaster.ModifiedDate = DateTime.Now;
                subCategoryMaster.Active = true;
                db.subCategoryMasters.Add(subCategoryMaster);
                db.SaveChanges();
                return Ok(subCategoryMaster);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("UpdateSubCategoryMaster")]
        public async Task<IActionResult> UpdateSubCategoryMaster([FromBody] SubCategoryMaster subCategoryMaster)
        {
            try
            {
                subCategoryMaster.ModifiedBy = "Admin";
                subCategoryMaster.ModifiedDate = DateTime.Now;

                db.Entry(subCategoryMaster).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(subCategoryMaster);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeletesubCategoryMaster/{id}")]
        public async Task<IActionResult> DeletesubCategoryMaster(int id)
        {
            try
            {
                db.Remove(db.subCategoryMasters.Find(id));
                db.SaveChanges();
                return Ok("Sub-Category ID : " + id +" has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}