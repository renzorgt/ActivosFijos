namespace ApiActivosFijos.Dtos.ActivoFijo.Querys
{
    public class Query
    {
        public readonly string SelectAllActivoFijo =
            @"select afi.id, afi.nombre, afi.descripcion,afi.tipo,t.nombre ntipo, afi.serial, afi.numero_inventario," +
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
            "inner join persona pe on paf.idpersona = pe.id) per on per.idactivofijo = afi.id  order by afi.id desc ";
        public readonly string SelectAllTipo =
             @"select id,nombre,activo from tipo ";

        public readonly string SelectAllArea =
            @"select id,nombre,activo from area ";
        public readonly string SelectAllPersona =
            @"select id,nombre,activo from persona ";
        public readonly string SelectAllCiudad =
            @"select id,nombre,activo from ciudad ";
        public readonly string SelectAllEstado =
            @"select id,nombre,activo from estado_activofijo ";
        
        public readonly string SelectAllAreaCiudad =
            @"	select ac.id,ac.idarea, ar.nombre narea, ac.idciudad,ci.nombre nciudad, ac.activo 
	            from area_ciudad ac 
	            inner join  area ar on  ar.id = ac.idarea
	            inner join ciudad ci on ci.id = ac.idciudad
                ";
        public readonly string InsertActivoFijo =
             @"INSERT INTO activofijo
                (nombre,descripcion,tipo,serial,numero_inventario,peso,
                alto,ancho,largo,valor_compra,fecha_compra,fecha_baja,estado_actual) 
                VALUES 
                (@nombre,@descripcion,@tipo,serial,@numero_inventario,@peso,
                @alto,@ancho,@largo,@valor_compra,@fecha_compra,@fecha_baja,@estado_actual); 
                SELECT LAST_INSERT_ID();";

        public readonly string InsertAreaActivoFijo =
            @"INSERT area_activofijo (idactivofijo, idarea, idciudad)" +
                        " VALUES " +
                        " (@idactivofijo,@idarea,@idciudad); ";
        public readonly string InsertPersonaActivoFijo =
           @"INSERT persona_activofijo (idactivofijo,idpersona)" +
                                           " VALUES " +
                                           " (@idactivofijo,@idpersona); ";
        public readonly string InsertCiudad =
            @" insert into ciudad (nombre) values (@nombre); SELECT LAST_INSERT_ID(); ";
        public readonly string InsertArea =
            @" insert into area (nombre) values (@nombre); SELECT LAST_INSERT_ID(); ";
        public readonly string InsertPersona =
            @" insert into persona (nombre) values (@nombre); SELECT LAST_INSERT_ID(); ";
        public readonly string InsertEstado =
            @" insert into estado_activofijo (nombre) values (@nombre); SELECT LAST_INSERT_ID(); ";
        public readonly string InsertTipo =
            @" insert into tipo (nombre) values (@nombre); SELECT LAST_INSERT_ID(); ";
            
        public readonly string InsertAreaCiudad =
            @" insert into area_ciudad (idarea,idciudad) values (@idarea,@idciudad); SELECT LAST_INSERT_ID(); ";



    }
}
