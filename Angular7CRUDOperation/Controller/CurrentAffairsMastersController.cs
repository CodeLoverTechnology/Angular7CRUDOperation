using Angular7CRUDOperation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Angular7CRUDOperation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentAffairsMastersController : ControllerBase
    {
        private NIASDbContext db = new NIASDbContext();
        [Produces("application/json")]
        [HttpGet("CurrentAffairsMastersList")]
        public async Task<IActionResult> CurrentAffairsMastersList(string SubCategory = null, string Category = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(SubCategory) && SubCategory!= "undefined" && !string.IsNullOrEmpty(Category) && Category != "undefined")
                {
                    var CurrentAffairsMastersListModel = db.currentAffairsMasters.ToList().Where(x => x.Category == Category.ToString() && x.SubCategory == SubCategory.ToString()).OrderByDescending(x => x.CurrentAffairsID).Take(50);
                    return Ok(CurrentAffairsMastersListModel);
                }
                else if (!string.IsNullOrEmpty(SubCategory) && SubCategory != "undefined")
                {
                    var CurrentAffairsMastersListModel = db.currentAffairsMasters.ToList().Where(x => x.SubCategory == SubCategory.ToString()).OrderByDescending(x => x.CurrentAffairsID).Take(50);
                    return Ok(CurrentAffairsMastersListModel);
                }

                else if (!string.IsNullOrEmpty(Category) && Category != "undefined")
                {
                    var CurrentAffairsMastersListModel = db.currentAffairsMasters.ToList().Where(x => x.Category == Category.ToString()).OrderByDescending(x => x.CurrentAffairsID).Take(50);
                    return Ok(CurrentAffairsMastersListModel);
                }
                else
                {
                    var CurrentAffairsMastersListModel = db.currentAffairsMasters.ToList().OrderByDescending(x => x.CurrentAffairsID).Take(50);
                    return Ok(CurrentAffairsMastersListModel);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Produces("application/json")]
        [HttpGet("CurrentAffairsMastersDetails/{id}")]
        public async Task<IActionResult> CurrentAffairsMastersDetails(int id)
        {
            try
            {
                var CurrentAffairsMastersModel = db.currentAffairsMasters.SingleOrDefault(x => x.CurrentAffairsID == id);
                return Ok(CurrentAffairsMastersModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateCurrentAffairsMasters")]
        public async Task<IActionResult> CreateCurrentAffairsMasters([FromBody] CurrentAffairsMasters ObjcurrentAffairsMasters)
        {
            try
            {
                //bannerMaster.EnquiryID = 0;
                ObjcurrentAffairsMasters.CreatedBy = "Admin";
                ObjcurrentAffairsMasters.CreatedDate = DateTime.Now;
                ObjcurrentAffairsMasters.ModifiedBy = "Admin";
                ObjcurrentAffairsMasters.ModifiedDate = DateTime.Now;
                ObjcurrentAffairsMasters.Active = true;
                db.currentAffairsMasters.Add(ObjcurrentAffairsMasters);
                db.SaveChanges();
                return Ok(ObjcurrentAffairsMasters);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("UpdateCurrentAffairsMasters")]
        public async Task<IActionResult> UpdateCurrentAffairsMasters([FromBody] CurrentAffairsMasters currentAffairsMasters)
        {
            try
            {
                currentAffairsMasters.ModifiedBy = "Admin";
                currentAffairsMasters.ModifiedDate = DateTime.Now;

                db.Entry(currentAffairsMasters).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(currentAffairsMasters);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteCurrentAffairsMasters/{id}")]
        public async Task<IActionResult> DeleteCurrentAffairsMasters(int id)
        {
            try
            {
                db.Remove(db.currentAffairsMasters.Find(id));
                db.SaveChanges();
                return Ok("CurrentAffairsMasters ID : " + id + " has Deleted By Admin.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}