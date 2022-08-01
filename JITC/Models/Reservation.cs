using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JITC.Models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public int? volId { get; set; }
        public virtual Vol? vol { get; set; }

        [DisplayName("Nombre de personne")]
        public  int place { get; set; }
    }
}
