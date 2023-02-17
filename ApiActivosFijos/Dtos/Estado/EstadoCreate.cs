using System.ComponentModel.DataAnnotations;

namespace ApiActivosFijos.Dtos.Estado
{
    public class EstadoCreate
    {
        [Required(ErrorMessage = " nombre Es requerido")]

        public string nombre { get; set; }

    }
}
