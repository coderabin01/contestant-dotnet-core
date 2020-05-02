using System.ComponentModel.DataAnnotations;
using System;

namespace contestant.Models
{
    public class ContestantRating
    {
        [Key]
        public int Id {get; set;}

        public int ContestantId {get; set;}

        public int Rating {get; set;}

        public DateTime RatedDate {get; set;}

        public Contestant Contestant {get; set;}

        public ContestantRating() {
            RatedDate = DateTime.Now;
        }
    }
}