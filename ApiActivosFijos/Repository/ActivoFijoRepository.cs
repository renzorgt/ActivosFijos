using ApiActivosFijos.Models;
using ApiActivosFijos.MySqlContext;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;
using ApiActivosFijos.Dtos.ActivoFijo;
using ApiActivosFijos.Dtos.ActivoFijo.Querys;
using Microsoft.OpenApi.Expressions;
using System.Linq;

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
                var sql = @"INSERT INTO activofijo
                (nombre,descripcion,tipo,serial,numero_inventario,peso,
                alto,ancho,largo,valor_compra,fecha_compra,fecha_baja,estado_actual) 
                VALUES 
                (@nombre,@descripcion,@tipo,serial,@numero_inventario,@peso,
                @alto,@ancho,@largo,@valor_compra,@fecha_compra,@fecha_baja,@estado_actual); 
                SELECT LAST_INSERT_ID();";
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
                var id = await db.QuerySingleAsync<int>(sql, parameters);

                if (activoFijo.idarea != null && activoFijo.idciudad != null)
                {
                    parameters.Add("idactivofijo", id, DbType.Int64);
                    parameters.Add("idarea", activoFijo.idarea, DbType.Int64);
                    parameters.Add("idciudad", activoFijo.idciudad, DbType.Int64);
                    sql = "INSERT area_activofijo (idactivofijo, idarea, idciudad)" +
                        " VALUES " +
                        " (@idactivofijo,@idarea,@idciudad) ";
                    var result = await db.ExecuteAsync(sql, parameters);
                }
                else
                {
                    sql = "INSERT persona_activofijo (idactivofijo,idpersona)" +
                                           " VALUES " +
                                           " (@idactivofijo,@idpersona) ";
                    var result = await db.ExecuteAsync(sql, parameters);
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

        public async Task<bool> UpdateActivoFijo(int Id ,ActivoFijo activoFijo)
        {

            var sql = @"UPDATE activofijo set  serial = @serial, fecha_baja = @fecha_baja
                        where id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("id", activoFijo.id, DbType.Int64);
            parameters.Add("fecha_baja", activoFijo.fecha_baja, DbType.Date);
            parameters.Add("serial", activoFijo.serial, DbType.String);
            using (var db = dbConnection())
            {

                var result = await db.ExecuteAsync(sql, parameters);

                return result > 0;
            }

        }
    }
}
