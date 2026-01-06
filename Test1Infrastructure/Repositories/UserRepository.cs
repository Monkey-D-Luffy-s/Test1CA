
using Test1Core.DomainModels;
using Test1Core.RepositoryContracts;

namespace Test1Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();

        return user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string Email, string password)
    {
        return new ApplicationUser()
        {
            UserId = Guid.NewGuid(),
            UserName = "Test",
            Email = "test@gmail.com",
            Role = "Admin"
        };
    }
}

