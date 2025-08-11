using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AppBlazor.Entities
{
    public class LibroFormCLS
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El Id del libro es requerido.")]
        public int idLibro { get; set; }
        [Required (ErrorMessage = "El titulo es requerido.")]
        [MaxLength (100, ErrorMessage = "La longitud maxima del titulo es de 100 caracteres.")]
        public string titulo { get; set; } = null!;//distinto de null
        [Required(ErrorMessage = "El resumen es requerido.")]
        [MinLength (20, ErrorMessage = "La longitud minima del resumen es de minimo 20 caracteres.")]
        public string resumen { get; set; } = null!;
        


    }
}
