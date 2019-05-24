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
    public class FileUploadedMasterController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("FileUploadedMasterList")]
        public async Task<IActionResult> FileUploadedMasterList()
        {
            try
            {
                var FileUploadedMasterListModel = db.fileUploadedMasters.ToList().OrderByDescending(x => x.UploadID).Take(50);
                return Ok(FileUploadedMasterListModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("FileUploadedDetails/{id}")]
        public async Task<IActionResult> FileUploadedDetails(int id)
        {
            try
            {
                var FileUploadedModel = db.fileUploadedMasters.SingleOrDefault(x => x.UploadID == id);
                return Ok(FileUploadedModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateFileUploaded")]
        public async Task<IActionResult> CreateFileUploaded([FromBody] FileUploadedMaster fileUploaded)
        {
            try
            {
                //bannerMaster.EnquiryID = 0;
                fileUploaded.CreatedBy = "Admin";
                fileUploaded.CreatedDate = DateTime.Now;
                fileUploaded.ModifiedBy = "Admin";
                fileUploaded.ModifiedDate = DateTime.Now;
                fileUploaded.Active = true;
                db.fileUploadedMasters.Add(fileUploaded);
                db.SaveChanges();
                return Ok(fileUploaded);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("UpdateFileUploaded")]
        public async Task<IActionResult> UpdateFileUploaded([FromBody] FileUploadedMaster fileUploadedMaster)
        {
            try
            {
                fileUploadedMaster.ModifiedBy = "Admin";
                fileUploadedMaster.ModifiedDate = DateTime.Now;
                db.Entry(fileUploadedMaster).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(fileUploadedMaster);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteFileUploaded/{id}")]
        public async Task<IActionResult> DeleteFileUploaded(int id)
        {
            try
            {
                db.Remove(db.fileUploadedMasters.Find(id));
                db.SaveChanges();
                return Ok("File Uploaded ID : " + id + " has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}