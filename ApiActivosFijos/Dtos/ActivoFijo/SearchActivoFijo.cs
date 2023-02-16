namespace ApiActivosFijos.Dtos.ActivoFijo
{
    public class SearchActivoFijo
    {
        public int? id { get; set; }
        public int? tipo { get; set; }
        public string? serial { get; set; }
        public DateTime? fecha_compra { get; set; }
    }
}
