namespace ApiActivosFijos.MySqlContext
{
    public class MySqlDbContext 
        
    {
        public MySqlDbContext(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public string ConnectionString { get; set; }

    }
}
