using System.ComponentModel.DataAnnotations;

namespace JITC.Models.ViewModels
{
    public class SearchViewModel
    {
        [Required]
        public int DepartId { get; set; }
        [Required]
        public int ArriveId { get; set; }
        [Required]
        public DateOnly DepartDate { get; set; }
    }
}
