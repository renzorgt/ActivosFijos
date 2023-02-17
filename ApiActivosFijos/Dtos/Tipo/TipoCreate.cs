using System.ComponentModel.DataAnnotations;

namespace ApiActivosFijos.Dtos.Tipo
{
    public class TipoCreate
    {
        [Required(ErrorMessage = " nombre Es requerido")]

        public string nombre { get; set; }
    }
}
