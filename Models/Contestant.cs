using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.AspNetCore.Http;

namespace contestant.Models
{
    public class Contestant
    {
        [Key]
        public int Id {get; set;}

        [MaxLength(50)]
        [Required]
        public string Firstname {get;set;}

        [MaxLength(50)]
        [Required]       
        public string Lastname {get;set;}
        
        public DateTime? DateOfBirth {get;set;}
        public bool? IsActive {get; set;}
        public int? DistrictId {get; set;}
        
        [MaxLength(50)]        
        public string Gender {get; set;}
        public string PhotoUrl {get; set;}

        [MaxLength(100)]
        public string Address {get; set;}

        [NotMapped]
        public IFormFile Photo {get; set;}
        public District District {get; set;}
    }
}