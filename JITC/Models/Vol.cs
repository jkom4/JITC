using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JITC.Models
{
    public class Vol
    {
        public int Id { get; set; }
        public Aeroport AeroportDepart { get; set; }
        public Aeroport AeroportArrive { get; set; }
        public int NombrePlace { get; set; }
        public DateTime HeureDepartPrevue { get; set; }
        public DateTime HeureArrivePrevue { get; set; }
        public DateTime HeureDepartReelle { get; set; }
        public DateTime HeureArriveReelle { get; set; }
        public ApplicationUser Pilote { get; set; }
        public float Distance { get; set; }
        public Appareil Appareil { get; set; }
        public int Recurrence { get; set; }
        public bool Retard { get; set; }
        public string? Raison { get; set; }
    }
}
