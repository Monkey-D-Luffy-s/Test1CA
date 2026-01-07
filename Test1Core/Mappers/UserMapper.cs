using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Test1Core.DomainModels;
using Test1Core.DomainModels.Dtos;

namespace Test1Core.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(dest => dest.Token, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.Ignore());


    }
}

