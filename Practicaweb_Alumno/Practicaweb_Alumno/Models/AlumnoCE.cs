using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practicaweb_Alumno.Models
{
    public class AlumnoCE
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Ingrese Nombres")]
        public string Nombres { get; set; }
        [Required]
        [Display(Name = "Ingrese Apelidos")]
        public string Apellidos { get; set; }
        [Required]
        [Display(Name = "Ingrese Edad")]
        public int Edad { get; set; }
        [Required]
        [Display(Name = "Sexo del Alumno")]
        public string Sexo { get; set; }        
    }

    [MetadataType(typeof(AlumnoCE))]

    public partial class Alumno
    {       
        public string NombreCompleto { get { return Nombres + " " + Apellidos; } }
    }
}