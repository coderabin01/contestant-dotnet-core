using System.ComponentModel.DataAnnotations;

namespace contestant.Models
{
    public class District
    {
        [Key]
        public int Id {get; set;}

        [MaxLength(50)]
        public string Name {get; set;}
    }
}