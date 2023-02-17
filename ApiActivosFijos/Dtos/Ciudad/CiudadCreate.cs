using System.ComponentModel.DataAnnotations;

namespace ApiActivosFijos.Dtos
{
    public class CiudadCreate
    {
        [Required(ErrorMessage = " nombre Es requerido")]

        public string nombre { get; set; }
    }
}
