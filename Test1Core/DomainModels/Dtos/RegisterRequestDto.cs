
using System;
using System.Collections.Generic;
using System.Text;

namespace Test1Core.DomainModels.Dtos;

public record RegisterRequestDto(string? UserName, string? Email, string? Password, string? Role);
