using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using contestant.Models;

namespace contestant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContestantController: Controller
    {
        private ContestantContext _contestantContext;        
        public ContestantController(ContestantContext context)
        {
            _contestantContext = context;
        }

        [HttpGet]
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
                District =  _contestantContext.District.Where(y => y.Id == x.DistrictId).FirstOrDefault()
            }).ToList();

            return contestantList;
        }

        [HttpPost]
        public async Task<ActionResult> AddContestant([FromBody] Contestant contestant)
        {
            if (contestant == null) {
                return NotFound("Contestant data is not supplied");
            }

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _contestantContext.Add(contestant);
            await _contestantContext.SaveChangesAsync();
            return Ok("Contestent added successfully");
        }   

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContestant(int id, [FromBody] Contestant contestant)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            contestant.Id = id;
            _contestantContext.Update(contestant);
            await _contestantContext.SaveChangesAsync();

            return Ok("Contestent updated successfully");
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

            return Ok("Contestant deleted Successfully");
        }


        ~ContestantController() 
        {
            _contestantContext.Dispose();
        }
    }
}