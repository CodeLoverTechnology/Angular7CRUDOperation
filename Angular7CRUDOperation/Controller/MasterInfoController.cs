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
    public class MasterInfoController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("MasterInfoList")]
        public async Task<IActionResult> MasterInfoList()
        {
            try
            {
                var MasterInfoListModel = db.masterInfos.ToList().OrderByDescending(x=>x.MasterID).Take(50);
                return Ok(MasterInfoListModel);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("MasterDetails/{id}")]
        public async Task<IActionResult> MasterDetails(int id)
        {
            try
            {
                var MasterInfosModel = db.masterInfos.SingleOrDefault(x => x.MasterID == id);
                return Ok(MasterInfosModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateMasterInfo")]
        public async Task<IActionResult> CreateMasterInfo([FromBody] MasterInfo  masterInfo)
        {
            try
            {
                masterInfo.CreatedBy = "Admin";
                masterInfo.CreatedDate = DateTime.Now;
                masterInfo.ModifiedBy = "Admin";
                masterInfo.ModifiedDate = DateTime.Now;
                masterInfo.Active = true;
                db.masterInfos.Add(masterInfo);
                db.SaveChanges();
                return Ok(masterInfo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("UpdateMasterInfo")]
        public async Task<IActionResult> UpdateMasterInfo([FromBody] MasterInfo masterInfo)
        {
            try
            {
                masterInfo.ModifiedBy = "Admin";
                masterInfo.ModifiedDate = DateTime.Now;

                db.Entry(masterInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(masterInfo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteMasterInfo/{id}")]
        public async Task<IActionResult> DeleteMasterInfo(int id)
        {
            try
            {
                db.Remove(db.masterInfos.Find(id));
                db.SaveChanges();
                return Ok("MasterInfo ID : " + id +" has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}