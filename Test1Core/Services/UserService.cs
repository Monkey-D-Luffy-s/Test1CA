using System;
using System.Collections.Generic;
using System.Text;
using Test1Core.DomainModels;
using Test1Core.DomainModels.Dtos;
using Test1Core.RepositoryContracts;
using Test1Core.ServiceContracts;

namespace Test1Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;
    public UserService(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }
    public async Task<AuthenticationResponse?> LoginUser(LoginRequestDto loginRequest)
    {


        ApplicationUser user = await _userRepo.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
        if (user == null)
        { return null; }
        return new AuthenticationResponse(user.UserId, user.UserName, user.Email, user.Role, "Token", true);

    }

    public async Task<AuthenticationResponse?> RegisterUser(RegisterRequestDto registerRequest)
    {
        ApplicationUser newUser = new ApplicationUser()
        {
            UserName = registerRequest.UserName,
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            Role = registerRequest.Role,
        };
        ApplicationUser user = await _userRepo.AddUser(newUser);
        if(user == null)  { return null; }

        return new AuthenticationResponse(user.UserId, user.UserName, user.Email, user.Role, "Token", true);
    }
}

