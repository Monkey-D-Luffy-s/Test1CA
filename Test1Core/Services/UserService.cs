using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using Test1Core.DomainModels;
using Test1Core.DomainModels.Dtos;
using Test1Core.RepositoryContracts;
using Test1Core.ServiceContracts;

namespace Test1Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepo, IMapper mapper)
    {
        _userRepo = userRepo;
        _mapper = mapper;
    }
    public async Task<AuthenticationResponse?> LoginUser(LoginRequestDto loginRequest)
    {


        ApplicationUser user = await _userRepo.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
        if (user == null)
        { return null; }
         
        return _mapper.Map<AuthenticationResponse>(user) with { Token = "Token", Status = true};
    }

    public async Task<AuthenticationResponse?> RegisterUser(RegisterRequestDto registerRequest)
    {
        ApplicationUser newUser = _mapper.Map<ApplicationUser>(registerRequest);
        ApplicationUser user = await _userRepo.AddUser(newUser);
        if(user == null)  { return null; }
        return _mapper.Map<AuthenticationResponse>(user) with { Token = "Token", Status = true };

    }
}

