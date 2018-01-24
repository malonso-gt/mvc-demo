using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTest.Models
{
    public class Persona
    {
        public int PersonaID { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Display(Name ="Edad actual")]
        public int edad { get; set; }
    }
}