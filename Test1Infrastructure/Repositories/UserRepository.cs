
using Dapper;
using System.Data;
using Test1Core.DomainModels;
using Test1Core.RepositoryContracts;
using Test1Infrastructure.UserContext;

namespace Test1Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _dbContext;
    public UserRepository(UserDbContext dbContext)
    {
        _dbContext = dbContext;
    }   
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        string sql1 = "SELECT * FROM public.testuser2 WHERE Email = @Email";
        var existinguser = await _dbContext.DbConnection.QuerySingleOrDefaultAsync<dynamic>(sql1, new { Email = user.Email, Password = user.Password });


        if (existinguser == null)
        {
            return null;
        }

        user.UserId = Guid.NewGuid();
        string sql2 = "INSERT INTO public.testuser2 (UserId, UserName, Email, Password, Role) " +
                     "VALUES (@UserId, @UserName, @Email, @Password, @Role)";
        
        int rowCount = await _dbContext.DbConnection.ExecuteAsync(sql2, new { user.UserId, user.UserName, user.Email, user.Password, user.Role });

        if(rowCount > 0)
        {
            return user;
        }
        else
        {
            return null;
        }
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string Email, string password)
    {
        string sql = "SELECT * FROM public.testuser2 WHERE Email = @Email AND Password = @Password";
        var user = await _dbContext.DbConnection.QuerySingleOrDefaultAsync<dynamic>(sql, new { Email = Email, Password = password });

       
        if (user == null)
        {
            return null;
        }
        else
        {
            ApplicationUser? appUser = new ApplicationUser()
            {
                UserId = Guid.Parse(user?.userid),
                UserName = user?.username,
                Email = user?.email,
                Password = user?.password,
                Role = user?.role
            };
            return appUser;
        }
    }
}

