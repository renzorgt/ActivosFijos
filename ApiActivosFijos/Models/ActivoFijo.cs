using System.ComponentModel.DataAnnotations;

namespace ApiActivosFijos.Models
{
    public class ActivoFijo
    {
        [Key]
        public int id { get; set; }
        
        public string nombre { get; set; }
       
        public string descripcion { get; set; }
        public int tipo { get; set; }
       
        public string serial { get; set; }
        public int numero_inventario { get; set; }
        public decimal peso { get; set; }
        public decimal alto { get; set; }
        public decimal ancho { get; set; }
        public decimal largo { get; set; }
        public int valor_compra { get; set; }
        public DateTime? fecha_compra { get; set; }
        public DateTime? fecha_baja { get; set; }
        public int estado_actual { get; set; }

    }
}
