using System;
using System.Collections.Generic;
using System.Text;

namespace Test1Core.DomainModels.Dtos;

public record ResponseDto(bool IsSuccess, string? Message, object? Data);

