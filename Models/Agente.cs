using System.ComponentModel.DataAnnotations;

namespace AppMulte.Models
{
    public class Agente
    {
        [Key]
        public int IDAgente { get; set; }

        [Required]
        public string NomeAgente { get; set; }

        [Required]
        public string CognomeAgente { get; set; }
    }
}
