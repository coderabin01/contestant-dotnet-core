using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contestant.Models;
using contestant.Providers;

namespace contestant.Controllers
{
    [Route("api/contestant-rating")]
    [ApiController]
    public class ContestantRatingController: Controller
    {
        private ContestantContext _contestantContext;
        private ContestantProvider _contestantProvider;
        public ContestantRatingController(ContestantContext context, ContestantProvider provider)
        {
            _contestantContext = context;
            _contestantProvider = provider;
        }

        [HttpGet]
        public ActionResult<List<ContestantAverageRating>> GetContestantRating([FromQuery(Name="from_date")] string fromDate, [FromQuery(Name="to_date")] string toDate) {

            if (fromDate == null || toDate == null)
            {
                return _contestantProvider.PopulateContestantListWithRating();
            } else {
                return _contestantProvider.PopulateContestantListWithRatingByFromDateAndToDate(fromDate, toDate);
            }

        }

        [HttpPost]
        public async Task<ActionResult> AddContestantRating([FromBody] ContestantRating contestantRating) {
            _contestantContext.ContestantRating.Add(contestantRating);
            await _contestantContext.SaveChangesAsync();

            return Json("Contestant Rating added Successfully");
        }
    }
}