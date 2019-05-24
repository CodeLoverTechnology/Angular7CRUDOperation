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
    public class BranchMasterController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("BranchMasterList")]
        public async Task<IActionResult> BranchMasterList()
        {
            try
            {
                var branchMastersList = db.branchMasters.ToList().OrderByDescending(x=>x.BranchCode).Take(50);
                return Ok(branchMastersList);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("BranchDetails/{BranchCode}")]
        public async Task<IActionResult> BranchDetails(string BranchCode)
        {
            try
            {
                var BranchMaster = db.branchMasters.SingleOrDefault(x => x.BranchCode == BranchCode);
                return Ok(BranchMaster);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateBranch")]
        public async Task<IActionResult> CreateBranch([FromBody] BranchMaster BranchMaster)
        {
            try
            {
                //BranchMaster.EnquiryID = 0;
                BranchMaster.CreatedBy = "Admin";
                BranchMaster.CreatedDate = DateTime.Now;
                BranchMaster.ModifiedBy = "Admin";
                BranchMaster.ModifiedDate = DateTime.Now;
                BranchMaster.Active = true;
                db.branchMasters.Add(BranchMaster);
                db.SaveChanges();
                return Ok(BranchMaster);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("UpdateBranchMaster")]
        public async Task<IActionResult> UpdateBranchMaster([FromBody] BranchMaster BranchMaster)
        {
            try
            {
                BranchMaster.ModifiedBy = "Admin";
                BranchMaster.ModifiedDate = DateTime.Now;
                db.Entry(BranchMaster).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(BranchMaster);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteBranch/{BranchCode}")]
        public async Task<IActionResult> DeleteBranch(string BranchCode)
        {
            try
            {
                db.Remove(db.bannerMasters.Find(BranchCode));
                db.SaveChanges();
                return Ok("BranchMaster Code : "+ BranchCode + " has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}