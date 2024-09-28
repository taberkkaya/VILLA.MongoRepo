using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
	public class QuestionValidator : AbstractValidator<Quest>
	{
        public QuestionValidator()
        {
            RuleFor(x => x.Question).NotEmpty();
            RuleFor(x => x.Question).MinimumLength(5);
            RuleFor(x => x.Answer).NotEmpty();
            RuleFor(x => x.Answer).MinimumLength(3);
        }
    }
}
