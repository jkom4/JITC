namespace JITC.Models.ViewModels
{
    public class VolViewModel
    {

        public int IdVol { get; set; }
        public Aeroport Depart { get; set; }
        public Aeroport Arrive { get; set; }
        public DateTime DepartPrevue { get; set; } 
        public DateTime ArrivePrevue { get; set; } 
        public int NombrePlace { get; set; } 
        public ApplicationUser Pilote { get; set; } 
        public Appareil Appareil { get; set; } 
        public int Recurrence { get; set; } 
    }
}
