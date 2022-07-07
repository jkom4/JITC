using System.ComponentModel.DataAnnotations;
namespace JITC.Models
{
    public class Appareil
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Nom { get; set; }
        [MaxLength(50)]
        public string? Description { get; set; }

        [Required]
        public int Capacite_Cab { get; set; }

        [Required]
        public float Vitesse { get; set; }

            
        [MaxLength(50)]
        public string? Moteur { get; set; }
        public bool Statut { get; set; }

    }
}
