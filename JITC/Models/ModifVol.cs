using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JITC.Models
{
    public class ModifVol
    {
        [Key]
        public int Id { get; set; }
        public List<Vol> Vols { get; set; } = new List<Vol>();
        
        public List<string> VolModifs { get; set; } = new List<string>();

    }
}
