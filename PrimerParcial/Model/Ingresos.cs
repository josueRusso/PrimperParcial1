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

        [Required(ErrorMessage = " Debe Contener un Monto")]
        public String? Monto { get; set; }
    }
}
