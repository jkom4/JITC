using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JITC.Models
{
    public class Vol
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AeroportDepartId")]
        [DisplayName("Départ")]
        public int? AeroportDepartId { get; set; }
        [DisplayName("Départ")]
        public virtual Aeroport? AeroportDepart { get; set; }
        [DisplayName("Arrivé")]
        [ForeignKey("AeroportArriveId")]
        public int? AeroportArriveId { get; set; }
        [DisplayName("Arrivé")]
        public virtual Aeroport? AeroportArrive { get; set; }

        [DisplayName("Nombre de Place")]
        public int NombrePlace { get; set; }
        //[DisplayFormat(DataFormatString = "{0:HH-mm}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Time)]
        [DisplayName(" Date et Heure de départ")]
        public DateTime HeureDepartPrevue { get; set; }

       // [DisplayFormat(DataFormatString = "{0:HH-mm}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Time)]
        [DisplayName("Date et Heure arrivée")]
        public DateTime HeureArrivePrevue { get; set; }

        //[DisplayFormat(DataFormatString = "{0:HH-mm}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Time)]
        [DisplayName("Date et Heure de départ reelle")]
        public DateTime? HeureDepartReelle { get; set; }

        //[DisplayFormat(DataFormatString = "{0:HH-mm}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Time)]
        [DisplayName("Date et Heure de arrivée reelle")]
        public DateTime? HeureArriveReelle { get; set; }

        [ForeignKey("PiloteId")]
        [DisplayName("Pilote")]
        public string? PiloteId { get; set; }
        public virtual ApplicationUser? Pilote { get; set; }
        [DisplayName("Distance en Km")]
        public double? Distance { get; set; }
        [ForeignKey("AppareilId")]
        [DisplayName("Appareil")]
        public int AppareilId { get; set; }
        public virtual Appareil? Appareil { get; set; }

        public string Recurrence { get; set; }
        [NotMapped]
        public int NombreMois { get; set; }
        [DefaultValue(false)]
        public bool Retard { get; set; }
        public string? Raison { get; set; }
        public int? ModifVolId { get; set; }
        public virtual ModifVol? ModifVol { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
