using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using contestant.Models;

namespace contestant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController
    {
        private ContestantContext _contestantContext;

        public DistrictController(ContestantContext context)
        {
            _contestantContext = context;
        }


        [HttpGet]
        public ActionResult<List<District>> GetDistrictList()
        {
            return _contestantContext.District.ToList();
        }
    }
}