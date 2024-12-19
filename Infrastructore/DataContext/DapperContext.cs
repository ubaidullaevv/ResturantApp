using Npgsql;

namespace Infrastructore.Context;

public class DapperContext
{
    private readonly string connectionString=$"Server=Localhost; Port=5432; Database=ResturantDB; User Id=postgres; password=12345;";
    
    public NpgsqlConnection Connection()
    {
     return new NpgsqlConnection(connectionString);
    }
}
