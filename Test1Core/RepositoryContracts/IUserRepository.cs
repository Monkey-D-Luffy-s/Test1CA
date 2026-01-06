
using Test1Core.DomainModels;

namespace Test1Core.RepositoryContracts;

public interface IUserRepository
{
    Task<ApplicationUser?> AddUser(ApplicationUser user);
    Task<ApplicationUser?> GetUserByEmailAndPassword(string Email, string password);
}

