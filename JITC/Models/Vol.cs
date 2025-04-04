﻿using JITC.Validations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JITC.Models
{   

    public class Vol
    {
     
        private DateTime heureDepartPrevue;
        private DateTime heureArrivePrevue;

        [Key]
        public int Id { get; set; }

        [ForeignKey("AeroportDepartId")]
        [DisplayName("Départ")]
        public int? AeroportDepartId { get; set; }
        [DisplayName("Départ")]
        public virtual Aeroport? AeroportDepart { get; set; }
        [DisplayName("Arrivé")]
        [ForeignKey("AeroportArriveId")]
        [NotSameAirport("AeroportDepartId")]
        public int? AeroportArriveId { get; set; }
        [DisplayName("Arrivé")]
        public virtual Aeroport? AeroportArrive { get; set; }

        [DisplayName("Nombre de Place")]
        public int NombrePlace { get; set; }
        
        [DisplayName(" Date et Heure de départ")]
        public DateTime HeureDepartPrevue { get { return heureDepartPrevue ; } set { heureDepartPrevue = value; ModifDate = true; } }

       
        [DisplayName("Date et Heure arrivée")]
        [NotSameDate("HeureDepartPrevue")]
        public DateTime HeureArrivePrevue { get { return heureArrivePrevue; } set { heureArrivePrevue = value; ModifDate = true; } }

        [DisplayName("Date et Heure de départ reelle")]
        
        public DateTime? HeureDepartReelle { get; set; }

        [DisplayName("Date et Heure de arrivée reelle")]
        public DateTime? HeureArriveReelle { get; set; }
        [Pilote]
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

        public string? Recurrence { get; set; }
        [NotMapped]
        public int NombreMois { get; set; }
        [DefaultValue(false)]
        public bool Retard { get; set; }
        public string? Raison { get; set; }
        public int? ModifVolId { get; set; }
        public virtual ModifVol? ModifVol { get; set; }

        [NotMapped]
        public int NbrePersonnes {
            get 
            {
                int nbre = 0;
                foreach(var item in Reservations) 
                {
                    nbre += item.place;
                }
                return nbre;
            }
        }
        public bool ModifDate { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }



}
