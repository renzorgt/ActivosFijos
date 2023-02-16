namespace ApiActivosFijos.Dtos.ActivoFijo.Querys
{
    public class Query
    {
        public readonly string SelectAllActivoFijo = 
            @"select afi.id, afi.nombre, afi.tipo,t.nombre ntipo, afi.serial, afi.numero_inventario," +
            "afi.peso, afi.alto, afi.ancho, afi.largo, afi.valor_compra, afi.fecha_compra," +
            "afi.fecha_baja, afi.estado_actual,es.nombre nestado_actual , IFNULL(af.idarea,\"N/A\") idarea, " +
            "IFNULL(af.narea,\"N/A\") narea, IFNULL(af.idciudad,\"N/A\") idciudad, IFNULL(af.nciudad,\"N/A\") " +
            "nciudad, IFNULL(per.idpersona,\"N/A\") idpersona , IFNULL(per.npersona,\"N/A\") npersona " +
            "from activofijo afi " +
            "inner join estado_activofijo es on es.id = afi.estado_actual " +
            "inner join tipo t on t.id = afi.tipo " +
            "left join " +
            "(select a.id idarea, a.nombre narea ,c.id idciudad,c.nombre nciudad , " +
            "aaf.idactivofijo from area_activofijo aaf inner join area a on a.id = aaf.idarea " +
            "inner join ciudad c on c.id = aaf.idciudad) af on af.idactivofijo = afi.id " +
            "left join (select paf.idpersona, pe.nombre npersona, paf.idactivofijo " +
            "from persona_activofijo paf " +
            "inner join persona pe on paf.idpersona = pe.id) per on per.idactivofijo = afi.id ";
        public readonly string SelectAllTipo =
             @"select id,nombre,activo from tipo ";
    
    }
}
