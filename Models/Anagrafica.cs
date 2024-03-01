using System.ComponentModel.DataAnnotations;

namespace AppMulte.Models
{
    public class Anagrafica
    {
        [Key]
        public int IDAnagrafica { get; set; }

        [Required]
        public string Cognome { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Indirizzo { get; set; }

        [Required]
        public string Citta { get; set; }

        [Required]
        public int CAP { get; set; }

        [Required]
        public string Cod_Fisc { get; set; }
    }
}
