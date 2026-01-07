using AutoMapper;
using Test1Core.DomainModels;
using Test1Core.DomainModels.Dtos;

namespace Test1Core.Mappers;

public class RegisterUserMapper : Profile
{
	public RegisterUserMapper()
	{
		CreateMap<RegisterRequestDto, ApplicationUser>()
			.ForMember(dest => dest.UserId, opt => opt.Ignore())
			.ForMember(dest => dest.Password, opt => opt.Ignore());
    }
}

