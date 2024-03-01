using System.ComponentModel.DataAnnotations;

namespace AppMulte.Models
{
    public class Violazione
    {
        [Key]
        public int IDViolazione { get; set; }

        [Required]
        public string Descrizione { get; set; }
    }
}
