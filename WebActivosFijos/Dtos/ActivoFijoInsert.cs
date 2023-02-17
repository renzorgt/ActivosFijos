using System.ComponentModel.DataAnnotations;

namespace WebActivosFijos.Dtos
{
    public class ActivoFijoInsert
    {
        [Required(ErrorMessage = " nombre is requerido")]
        public string nombre { get; set; }

        [Required(ErrorMessage = " descripcion is requerido")]
        public string descripcion { get; set; }
        public int tipo { get; set; }
        public string serial { get; set; }
        public int numero_inventario { get; set; }
        public decimal peso { get; set; }
        public decimal alto { get; set; }
        public decimal ancho { get; set; }
        public decimal largo { get; set; }
        public int valor_compra { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_compra { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime? fecha_baja { get; set; }
        public int estado_actual { get; set; }

        public int? idarea { get; set; }
        public int? idpersona { get; set; }
        public int? idciudad { get; set; }
    }
}
