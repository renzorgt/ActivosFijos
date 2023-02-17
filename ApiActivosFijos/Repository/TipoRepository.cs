using ApiActivosFijos.Dtos;
using ApiActivosFijos.Dtos.ActivoFijo.Querys;
using ApiActivosFijos.Dtos.Tipo;
using ApiActivosFijos.Models;
using ApiActivosFijos.MySqlContext;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace ApiActivosFijos.Repository
{

    public class TipoRepository : ITipoRepository
    {
        private readonly MySqlDbContext _connection;

        public TipoRepository(MySqlDbContext connection)
        {
            _connection = connection;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection.ConnectionString);
        }
        public async Task<IEnumerable<TipoView>> GetAllTipo()
        {
           using (var db = dbConnection())
            {
                var sql = new Query();
                var result = await db.QueryAsync<TipoView>(sql.SelectAllTipo, new {});
            return result.ToList();
            }
        }

        public Task<IEnumerable<TipoView>> GetByFilterTipo(TipoSearch tipoSearch)
        {
            throw new NotImplementedException();
        }

        public async Task<Tipo> InsertTipo(TipoCreate tipoCreate)
        {
            var sql = new Query();
            var parameters = new DynamicParameters();
            parameters.Add("nombre", tipoCreate.nombre, DbType.String);

            using (var db = dbConnection())
            // using (var transaction = db.BeginTransaction())

            {

                var id = await db.QuerySingleAsync<int>(sql.InsertTipo, parameters);


                var inserted = new Tipo
                {
                    id = id,
                    nombre = tipoCreate.nombre,
                    activo = "S"
                };
                //return result > 0;
                return inserted;
            }
        }
    }
}
