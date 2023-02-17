using ApiActivosFijos.Models;
using ApiActivosFijos.MySqlContext;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;
using ApiActivosFijos.Dtos.ActivoFijo;
using ApiActivosFijos.Dtos.ActivoFijo.Querys;
using Microsoft.OpenApi.Expressions;
using System.Linq;
using ApiActivosFijos.Dtos.Area;
using ApiActivosFijos.Dtos;
using ApiActivosFijos.Dtos.Estado;

namespace ApiActivosFijos.Repository
{
    public class ActivoFijoRepository : IActivoFijoRepository
    {

        private readonly MySqlDbContext _connection;

        public ActivoFijoRepository (MySqlDbContext connection)
        {
            _connection = connection;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection.ConnectionString);
        }
        public async Task<IEnumerable<ActivoFijoView>> GetAllActivoFijo()
        {
            using (var db = dbConnection()) {

                var sql = new Query();
                   
            var result = await db.QueryAsync<ActivoFijoView>(sql.SelectAllActivoFijo, new { });

            return result.ToList();
            }
        }

        public async Task<IEnumerable<ActivoFijoView>> GetByFilter(SearchActivoFijo searchActivoFijo)
        {
            using (var db = dbConnection())
            {
                var sql = new Query();
                var parameters = new DynamicParameters();

                var query = sql.SelectAllActivoFijo;
                if (searchActivoFijo is not null)
                {
                    
                    List<String> conditional = new List<String>();
                    
                    //Establezco las parametros para la consulta
                    if (searchActivoFijo.id != null)
                    {
                        parameters.Add("id", searchActivoFijo.id, DbType.Int64);
                        conditional.Add(" afi.id = @id ");
                    }
                    if (searchActivoFijo.serial != null)
                    {
                        parameters.Add("serial", searchActivoFijo.serial, DbType.Int64);
                        conditional.Add(" afi.serial = @serial ");
                    }
                    if (searchActivoFijo.tipo != null)
                    {
                        parameters.Add("tipo", searchActivoFijo.tipo, DbType.Int64);
                        conditional.Add(" afi.tipo = @tipo ");
                    }
                    if (searchActivoFijo.fecha_compra != null)
                    {
                        parameters.Add("fecha_compra", searchActivoFijo.fecha_compra, DbType.Date);
                        conditional.Add(" afi.fecha_compra = @fecha_compra ");
                    }

                    //Agrego los parametros a la consulta
                    for (int i = 0; i <= conditional.Count-1; i++)
                    {
                        string condition ="";
                        if (i > 0) { condition = " and "; } else { query = query + " where "; }

                        query = query + condition + conditional[i];
                    }
                }

                var result = await db.QueryAsync<ActivoFijoView>(query, parameters);

                return result.ToList();
            }
        }

        public async Task<ActivoFijo> InsertActivoFijo(ActivoFijoCreate activoFijo)
        {
            var sql = new Query();
            var parameters = new DynamicParameters();
            parameters.Add("nombre", activoFijo.nombre, DbType.String);
            parameters.Add("descripcion", activoFijo.descripcion, DbType.String);
            parameters.Add("tipo", activoFijo.tipo, DbType.Int64);
            parameters.Add("serial", activoFijo.serial, DbType.String);
            parameters.Add("numero_inventario", activoFijo.numero_inventario, DbType.Int64);
            parameters.Add("peso", activoFijo.peso, DbType.Decimal);
            parameters.Add("alto", activoFijo.alto, DbType.Decimal);
            parameters.Add("ancho", activoFijo.ancho, DbType.Decimal);
            parameters.Add("largo", activoFijo.largo, DbType.Decimal);
            parameters.Add("valor_compra", activoFijo.valor_compra, DbType.Decimal);
            parameters.Add("fecha_compra", activoFijo.fecha_compra, DbType.Date);
            parameters.Add("fecha_baja", activoFijo.fecha_baja, DbType.Date);
            parameters.Add("estado_actual", activoFijo.estado_actual, DbType.Int64);

            using (var db = dbConnection())
           // using (var transaction = db.BeginTransaction())

            {
                //var result = await db.ExecuteAsync(sql,parameters);
                var id = await db.QuerySingleAsync<int>(sql.InsertActivoFijo, parameters);

                if ((activoFijo.idarea != null && activoFijo.idciudad != null) && (activoFijo.idarea != 0 && activoFijo.idciudad != 0))
                {
                    parameters.Add("idactivofijo", id, DbType.Int64);
                    parameters.Add("idarea", activoFijo.idarea, DbType.Int64);
                    parameters.Add("idciudad", activoFijo.idciudad, DbType.Int64);
                    //sql = "INSERT area_activofijo (idactivofijo, idarea, idciudad)" +
                    //    " VALUES " +
                    //    " (@idactivofijo,@idarea,@idciudad) ";
                    var result = await db.ExecuteAsync(sql.InsertAreaActivoFijo, parameters);
                }
                else
                {
                    parameters.Add("idactivofijo", id, DbType.Int64);
                    parameters.Add("idpersona", activoFijo.idpersona, DbType.Int64);
                    //sql = "INSERT persona_activofijo (idactivofijo,idpersona)" +
                    //                       " VALUES " +
                    //                       " (@idactivofijo,@idpersona) ";
                    var result = await db.ExecuteAsync(sql.InsertPersonaActivoFijo, parameters);
                }
                var insertedactivo = new ActivoFijo
                {
                    id = id,
                    nombre = activoFijo.nombre,
                    descripcion = activoFijo.descripcion,
                    tipo = activoFijo.tipo,
                    serial = activoFijo.serial,
                    numero_inventario = activoFijo.numero_inventario,
                    peso = activoFijo.peso,
                    alto = activoFijo.alto,
                    valor_compra = activoFijo.valor_compra,
                    fecha_compra = activoFijo.fecha_compra,
                    fecha_baja = activoFijo.fecha_baja,
                    estado_actual = activoFijo.estado_actual
                };
                //return result > 0;
                return insertedactivo;
            }
        }

        public async Task<bool> UpdateActivoFijo(int Id , ActivoFijoUpdate activoFijo)
        {

            var sql = @"UPDATE activofijo set  serial = @serial, fecha_baja = @fecha_baja
                        where id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", Id, DbType.Int64);
            parameters.Add("fecha_baja", activoFijo.fecha_baja, DbType.Date);
            parameters.Add("serial", activoFijo.serial, DbType.String);
            using (var db = dbConnection())
            {

                var result = await db.ExecuteAsync(sql, parameters);

                return result > 0;
            }

        }

        public async Task<IEnumerable<Area>> GetAllArea()
        {
            using (var db = dbConnection())
            {

                var sql = new Query();

                var result = await db.QueryAsync<Area>(sql.SelectAllArea, new { });

                return result.ToList();
            }
        }

        public async Task<IEnumerable<Persona>> GetAllPersona()
        {
            using (var db = dbConnection())
            {

                var sql = new Query();

                var result = await db.QueryAsync<Persona>(sql.SelectAllPersona, new { });

                return result.ToList();
            }
        }
        public async Task<IEnumerable<Estado>> GetAllEstado()
        {
            using (var db = dbConnection())
            {

                var sql = new Query();

                var result = await db.QueryAsync<Estado>(sql.SelectAllEstado, new { });

                return result.ToList();
            }
        }
        public async Task<IEnumerable<Ciudad>> GetAllCiudad()
        {
            using (var db = dbConnection())
            {

                var sql = new Query();

                var result = await db.QueryAsync<Ciudad>(sql.SelectAllCiudad, new { });

                return result.ToList();
            }
        }

        public async Task<IEnumerable<AreaCiudadView>> GetAllAreaCiudad(int? idarea)
        {
            using (var db = dbConnection())
            {

                var sql = new Query();
                var condition = "";

                if (idarea != null)
                {
                    condition = $" where idarea={idarea} ";
                }
                var result = await db.QueryAsync<AreaCiudadView>(sql.SelectAllAreaCiudad + condition, new { });

                return result.ToList();
            }
        }

        public async Task<Ciudad> InsertCiudad(CiudadCreate ciudadCreate)
        {
            var sql = new Query();
            var parameters = new DynamicParameters();
            parameters.Add("nombre", ciudadCreate.nombre, DbType.String);

            using (var db = dbConnection())
            // using (var transaction = db.BeginTransaction())

            {
               
                var id = await db.QuerySingleAsync<int>(sql.InsertCiudad, parameters);

              
                var insertedciudad = new Ciudad
                {
                    id = id,
                    nombre = ciudadCreate.nombre,
                    activo = "S"
                };
                //return result > 0;
                return insertedciudad;
            }
        }
        public async Task<Area> InsertArea(AreaCreate areaCreate)
        {
            var sql = new Query();
            var parameters = new DynamicParameters();
            parameters.Add("nombre", areaCreate.nombre, DbType.String);

            using (var db = dbConnection())
            // using (var transaction = db.BeginTransaction())

            {

                var id = await db.QuerySingleAsync<int>(sql.InsertArea, parameters);


                var inserted = new Area
                {
                    id = id,
                    nombre = areaCreate.nombre,
                    activo = "S"
                };
                //return result > 0;
                return inserted;
            }
        }
        public async Task<Persona> InsertPersona(PersonaCreate personaCreate)
        {
            var sql = new Query();
            var parameters = new DynamicParameters();
            parameters.Add("nombre", personaCreate.nombre, DbType.String);

            using (var db = dbConnection())
            // using (var transaction = db.BeginTransaction())

            {

                var id = await db.QuerySingleAsync<int>(sql.InsertPersona, parameters);


                var inserted = new Persona
                {
                    id = id,
                    nombre = personaCreate.nombre,
                    activo = "S"
                };
                //return result > 0;
                return inserted;
            }
        }

        public async Task<AreaCiudadView> InsertAreaCiudad(AreaCiudadCreate areaciudadCreate)
        {
            var sql = new Query();
            var parameters = new DynamicParameters();
            parameters.Add("idciudad", areaciudadCreate.idciudad, DbType.String);
            parameters.Add("idarea", areaciudadCreate.idarea, DbType.String);

            using (var db = dbConnection())
            // using (var transaction = db.BeginTransaction())

            {

                var id = await db.QuerySingleAsync<int>(sql.InsertAreaCiudad, parameters);


                var insertedareaciudad = new AreaCiudadView
                {
                    id = id,
                    idarea = areaciudadCreate.idarea,
                    idciudad = areaciudadCreate.idciudad,
                    activo = "S"
                };

                return insertedareaciudad;
               // return insertedciudad;
            }
        }
        public async Task<Estado> InsertEstado(EstadoCreate estadoCreate)
        {
            var sql = new Query();
            var parameters = new DynamicParameters();
            parameters.Add("nombre", estadoCreate.nombre, DbType.String);

            using (var db = dbConnection())

            {

                var id = await db.QuerySingleAsync<int>(sql.InsertEstado, parameters);


                var insertedciudad = new Estado
                {
                    id = id,
                    nombre = estadoCreate.nombre,
                    activo = "S"
                };
                //return result > 0;
                return insertedciudad;
            }
        }

    }
}
