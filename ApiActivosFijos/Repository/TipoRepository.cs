using ApiActivosFijos.Dtos.ActivoFijo.Querys;
using ApiActivosFijos.Dtos.Tipo;
using ApiActivosFijos.MySqlContext;
using Dapper;
using MySql.Data.MySqlClient;

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
    }
}
