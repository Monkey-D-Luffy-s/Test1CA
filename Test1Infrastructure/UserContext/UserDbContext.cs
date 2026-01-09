using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Test1Infrastructure.UserContext;

public class UserDbContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _connection;

    public UserDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        string _connecctionstring = _configuration.GetConnectionString("DefaultConnection") 
                            ?? throw new InvalidOperationException("Connection string 'UserDbConnectionString' not found.");
        _connection = new NpgsqlConnection(_connecctionstring);

    }

    public IDbConnection DbConnection => _connection;
}

