using System.ComponentModel.DataAnnotations;
namespace JITC.Models
{
    public class Aeroport
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nom { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
