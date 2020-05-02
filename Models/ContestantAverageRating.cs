using System; 

namespace contestant.Models
{
    public class ContestantAverageRating
    {
        public int Id {get; set;}

        public string Firstname {get;set;}

        public string Lastname {get;set;}

        public DateTime? DateOfBirth {get;set;}

        public District District {get; set;}

        public double? AverageRating {get; set;}
    }
}