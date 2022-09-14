using System.ComponentModel.DataAnnotations;

namespace Videoteka.DataModel
{
    public class Film
    {
        public int IDFilm { get; set; }
        [MaxLength(255, ErrorMessage = "Název filmu je příliš dlouhý")]
        [Display(Name = "Název filmu")]
        public string Nazev { get; set; }

        [Display(Name = "Rok vydání")]
        public int RokVydani { get; set; }

        [MaxLength(255, ErrorMessage = "Název žánru je příliš dlouhý")]
        [Display(Name = "Žánr")]
        public string Zanr { get; set; }

        [Range(1,5, ErrorMessage = "Zadávejt hodnoty 1 - 5 (5 nejlepší hodnocení)")]
        [Display(Name = "Hodnocení")]
        public int Hodnoceni { get; set; }
    }
}
