using System.ComponentModel.DataAnnotations;

namespace PrimerParcial.Model
{
    public class Ingresos
    {
        [Key]
        public int IngresoId { get; set; }

        [Required(ErrorMessage = "Debe Contener una Fecha")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = " Debe Contener un Concepto")]
        public String? Concepto { get; set; }

        [Required(ErrorMessage = "* El campo Precio es Monto")]
        [Range(0.01, 1000, ErrorMessage = "* El campo Monto debe estar entre 0.01 y 1000")]
        public double Monto { get; set; }
    }
}
