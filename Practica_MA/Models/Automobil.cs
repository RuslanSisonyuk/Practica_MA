using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica_MA.Models
{
    public class Automobil
    {
        [Key]
        [Required]
        public string id { get; set; }

        [Required]
        [Display(Name = "Denumire")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Detalii")]
        public string details { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public string marca { get; set; }

        [Required]
        [Display(Name = "Culoare")]
        public string color { get; set; }

        [Required]
        [Display(Name = "Preț")]
        [Range(0, 100000, ErrorMessage = "Prețul admisibil este între 0 și 100000")]
        public float price { get; set; }

        public string imgURL { get; set; }
    }
}
