using System.ComponentModel.DataAnnotations;

namespace AppMulte.Models
{
    public class Verbale
    {
        [Key]
        public int IDVerbale { get; set; }

        [Required]
        public DateTime DataViolazione { get; set; }

        [Required]
        public string IndirizzoViolazione { get; set; }

        [Required]
        public int IDAgente { get; set; }

        [Required]
        public DateTime DataTrascrizioneVerbale { get; set; }

        [Required]
        public decimal Importo { get; set; }

        [Required]
        public int DecurtamentoPunti { get; set; }
    }
}
