using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Test1Core.DomainModels.Dtos;

namespace Test1Core.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequestDto>
{
	public LoginRequestValidator()
	{
		RuleFor(x => x.Email)
			.NotEmpty().WithMessage("Email is required.")
			.EmailAddress().WithMessage("Enter valid email address");

		RuleFor(x => x.Password)
			.NotEmpty().WithMessage("Password is required.")
			.MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
			.MaximumLength(20).WithMessage("Password must be less then 20 characters long.")
			.Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter.")
			.Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter.")
			.Matches(@"[0-9]+").WithMessage("Password must contain at least one digit.")
            .Matches(@"[^\da-zA-Z]").WithMessage("Password must contain at least one special character (!? * .).");

    }
}

