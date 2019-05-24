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
    public class ChatMasterController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("ChatMasterList")]
        public async Task<IActionResult> ChatMasterList()
        {
            try
            {
                var ChatMasterModel = db.chatMasters.ToList().OrderByDescending(x=>x.UserChatID).Take(50);
                return Ok(ChatMasterModel);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("ChatMasterDetails/{id}")]
        public async Task<IActionResult> ChatMasterDetails(int id)
        {
            try
            {
                var ChatMasterModel = db.chatMasters.SingleOrDefault(x => x.UserChatID == id);
                return Ok(ChatMasterModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("ChatMasterCreate")]
        public async Task<IActionResult> ChatMasterCreate([FromBody] ChatMaster chatMaster)
        {
            try
            {
                //chatMaster.EnquiryID = 0;
                chatMaster.ReplyMessage = null;
                chatMaster.CraatedBy = "Admin";
                chatMaster.CreatedDate = DateTime.Now;
                chatMaster.ModifiedBy = "Admin";
                chatMaster.ModifiedDate = DateTime.Now;
                chatMaster.Active = true;
                db.chatMasters.Add(chatMaster);
                db.SaveChanges();
                return Ok(chatMaster);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("ChatMasterUpdate")]
        public async Task<IActionResult> ChatMasterUpdate([FromBody] ChatMaster chatMaster)
        {
            try
            {
                chatMaster.ModifiedBy = "Admin";
                chatMaster.ModifiedDate = DateTime.Now;

                db.Entry(chatMaster).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(chatMaster);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteChatMaster/{id}")]
        public async Task<IActionResult> DeleteChatMaster(int id)
        {
            try
            {
                db.Remove(db.chatMasters.Find(id));
                db.SaveChanges();
                return Ok("Chat ID : " + id +" has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}