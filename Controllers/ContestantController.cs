using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;  
using System.Linq;
using contestant.Models;
using contestant.Providers;

namespace contestant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContestantController: Controller
    {
        private ContestantContext _contestantContext;
        private ContestantProvider _contestantProvider;
        public ContestantController(ContestantContext context, ContestantProvider provider)
        {
            _contestantContext = context;
            _contestantProvider = provider;
        }

        /**
            API to get the list of all candidates
         */
        [HttpGet]
        // [SwaggerOperation(Summary = "List all contestant", Description = "Retrives all the contestant with their district")]
        public ActionResult<List<Contestant>> GetContestantList()
        {
            List<Contestant> contestantList = _contestantContext.Contestant.Select(x => new Contestant(){
                Id = x.Id,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                DateOfBirth = x.DateOfBirth,
                IsActive = x.IsActive,
                Gender = x.Gender,
                PhotoUrl = x.PhotoUrl,
                Address = x.Address,
                DistrictId = x.DistrictId,
                District =  _contestantContext.District.Where(y => y.Id == x.DistrictId).FirstOrDefault()
            }).ToList();

            return Ok(contestantList);
        }

        /**
            API to get photo list of active contestant
         */
        [HttpGet]
        [Route("photos")]
        public ActionResult<List<Contestant>> GetContestantPhotoList()
        {
            List<Contestant> contestantList = _contestantContext.Contestant.Where(x => x.IsActive == true).Where(x => x.PhotoUrl != null).ToList();

            return contestantList;
        }

        /**
            API to get list of contestant from a particular district
         */
        [HttpGet]
        [Route("district")]
        public ActionResult<List<Contestant>> GetContestantListByDistrict([FromQuery(Name="address")] string address)
        {
            int districtId = _contestantContext.District.Where(x=> x.Name == address).Select(x => x.Id).FirstOrDefault();
            if (districtId > 0) {
                List<Contestant> contestantList = _contestantContext.Contestant.Where(x => x.DistrictId == 1).Select(x => new Contestant(){
                    Id = x.Id,
                    Firstname = x.Firstname,
                    Lastname = x.Lastname,
                    DateOfBirth = x.DateOfBirth,
                    IsActive = x.IsActive,
                    Gender = x.Gender,
                    PhotoUrl = x.PhotoUrl,
                    Address = x.Address,
                    DistrictId = x.DistrictId,
                    District =  _contestantContext.District.Where(y => y.Id == x.DistrictId).FirstOrDefault()
                }).ToList();
                return contestantList;
            } else {
                return NotFound(new {status = false, message = "No Contestant"});
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddContestant([FromForm]Contestant contestant)
        {
            string photoName = "";

            if (contestant == null) {
                return NotFound("Contestant data is not supplied");
            }

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            // photo is uploaded
            if (contestant.Photo != null) {
                photoName = _contestantProvider.UploadFile(contestant); 
                contestant.PhotoUrl = photoName;
            }

            _contestantContext.Add(contestant);
            await _contestantContext.SaveChangesAsync();

            return Ok(new { status = true, message = "Contestent added successfully"});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContestant(int id, [FromForm]Contestant contestant)
        {
            string photoName = "";

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            // photo is uploaded
            if (contestant.Photo != null) {
                photoName = _contestantProvider.UploadFile(contestant); 
                contestant.PhotoUrl = photoName;
            }

            contestant.Id = id;
            _contestantContext.Update(contestant);
            await _contestantContext.SaveChangesAsync();

            return Ok(new { status = true, message = "Contestent updated successfully"});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContestant(int? id)
        {
            var contestant = await _contestantContext.Contestant.FindAsync(id);
            if (contestant == null)
            {
                return NotFound("Contestant not found");
            }

            _contestantContext.Contestant.Remove(contestant);
            await _contestantContext.SaveChangesAsync();

            return Ok(new { status = true, message = "Contestant deleted Successfully"});
        }


        ~ContestantController() 
        {
            _contestantContext.Dispose();
        }
    }
}