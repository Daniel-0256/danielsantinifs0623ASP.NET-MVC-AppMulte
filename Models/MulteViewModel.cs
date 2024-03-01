namespace AppMulte.Models
{
    public class MulteViewModel
    {
        public IEnumerable<Multa> Multe { get; set; }
        public IEnumerable<Anagrafica> Anagrafica { get; set; }
        public IEnumerable<Verbale> Verbali { get; set; }
        public IEnumerable<Violazione> Violazioni { get; set; }

    }
}
