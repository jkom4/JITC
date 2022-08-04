namespace JITC.Models.ViewModels
{
    public class VolViewModel
    {

        public int IdVol { get; set; }
        public string Vol { 
            get 
            {
                return Depart.Nom + " - " + Arrive.Nom;
            } 
        }
        public Aeroport Depart { get; set; }
        public Aeroport Arrive { get; set; }
        public DateTime DepartPrevue { get; set; } 
        public DateTime ArrivePrevue { get; set; }
        public DateTime? DepartReelle { get; set; }
        public DateTime? ArriveReelle { get; set; }
        public int NombrePlace { get; set; } 
        public int NombrePlaceDispo { get; set; } 
        public ApplicationUser Pilote { get; set; } 
        public Appareil Appareil { get; set; } 
        public string[] Recurrence { get; set; } 
        public Reservation? Reservation { get; set; }

        public List<Reservation>? Reservations { get; set; }
        public List<Vol>? vols { get; set; }
    }
}
