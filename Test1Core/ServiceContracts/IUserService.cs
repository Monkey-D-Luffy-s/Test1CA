using System;
using System.Collections.Generic;
using System.Text;
using Test1Core.DomainModels.Dtos;

namespace Test1Core.ServiceContracts;

public interface IUserService
{
    Task<AuthenticationResponse> LoginUser(LoginRequestDto loginRequest);

    Task<AuthenticationResponse> RegisterUser(RegisterRequestDto? registerRequest);
}

