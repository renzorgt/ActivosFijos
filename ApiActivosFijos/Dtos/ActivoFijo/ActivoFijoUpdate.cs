using System.ComponentModel.DataAnnotations;

namespace ApiActivosFijos.Dtos.ActivoFijo
{
    public class ActivoFijoUpdate
    {

        [Required(ErrorMessage = " serial es requerido")]
        public string serial { get; set; }
       
        [Required(ErrorMessage = " Fecha es requerido")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
      
        public DateTime fecha_baja { get; set; }
    }
}
