using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemondo_Web_API.Domain.Validator
{
    public class StatementValidator : AbstractValidator<Statement>
    {
        public StatementValidator()
        {

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("{PropertyName} is Empty");

            RuleFor(x => x.StatementDetail.PhoneNumber)
                .NotEmpty().WithMessage("{PropertyName} is Empty");

            RuleFor(x => x.StatementDetail.Description)
                .NotEmpty().WithMessage("{PropertyName} is Empty");
        }
    }
}
