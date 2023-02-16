using System.ComponentModel.DataAnnotations;

namespace ApiActivosFijos.Models
{
    public class PersonaActivoFijo
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string activo { get; set; }
    }
}
