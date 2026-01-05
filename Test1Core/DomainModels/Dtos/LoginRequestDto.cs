using System;
using System.Collections.Generic;
using System.Text;

namespace Test1Core.DomainModels.Dtos;

public record LoginRequestDto(string? Email, string? Password);

