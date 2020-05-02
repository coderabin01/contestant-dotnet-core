using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using contestant.Models;

namespace contestant.Providers
{
    public class ContestantProvider
    {
        private ContestantContext _contestantContext;        
        public ContestantProvider(ContestantContext context)
        {
            _contestantContext = context;
        }

        /**
            Returns all contestant rating for all contestant
         */
        public List<ContestantAverageRating> PopulateContestantListWithRating()
        {
            List<ContestantAverageRating> contestantList = _contestantContext.Contestant.Where(x => x.IsActive == true).Select(x => new ContestantAverageRating() {
                Id = x.Id,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                DateOfBirth = x.DateOfBirth,
                AverageRating = _contestantContext.ContestantRating.Where(cr => cr.ContestantId == x.Id).Select(cr => cr.Rating).DefaultIfEmpty(0).Average(),
                District =  _contestantContext.District.Where(district => district.Id == x.DistrictId).FirstOrDefault()
            }).ToList();

            return contestantList;
        }

        /**
            Returns contestant rating for all contestant from provided from_date to provided to_date
         */
        public List<ContestantAverageRating> PopulateContestantListWithRatingByFromDateAndToDate(string fromDate, string toDate)
        {
            List<ContestantAverageRating> contestantList = _contestantContext.Contestant.Where(x => x.IsActive == true).Select(x => new ContestantAverageRating() {
                Id = x.Id,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                DateOfBirth = x.DateOfBirth,
                AverageRating = _contestantContext.ContestantRating.Where(cr => cr.ContestantId == x.Id).Where(cr => cr.RatedDate >= Convert.ToDateTime(fromDate)).Where(cr => cr.RatedDate <= Convert.ToDateTime(toDate)).Select(cr => cr.Rating).DefaultIfEmpty(0).Average(),
                District =  _contestantContext.District.Where(district => district.Id == x.DistrictId).FirstOrDefault()
            }).ToList();

            return contestantList;
        }

        ~ContestantProvider() 
        {
            _contestantContext.Dispose();
        }
    }
}