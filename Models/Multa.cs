using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMulte.Models
{
    public class Multa
    {
        [Key]
        public int IDMulta { get; set; }

        [Required]
        [ForeignKey("Anagrafica")]
        public int IDAnagrafica { get; set; }

        [Required]
        [ForeignKey("Verbale")]
        public int IDVerbale { get; set; }

        [Required]
        [ForeignKey("Violazione")]
        public int IDViolazione { get; set; }

        public Anagrafica Anagrafica { get; set; }
        public Verbale Verbale { get; set; }
        public Violazione Violazione { get; set; }
    }
}
