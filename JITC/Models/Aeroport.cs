using System.ComponentModel.DataAnnotations;
namespace JITC.Models
{
    public class Aeroport
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nom { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public List<Vol> Vols { get; set; }
    }
}
