using FluentValidation;
using Infrastructure.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ValidationService.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
        }
    }
}
