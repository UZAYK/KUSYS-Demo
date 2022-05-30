using FluentValidation;
using KUSYSDemo.Models;

namespace KUSYSDemo.Business.ValidationRules.FluentValidation
{
    public class StudentValidator : AbstractValidator<StudentModel>
    {
        public StudentValidator()
        {
            RuleFor(I => I.FirstName).NotNull().WithMessage("Please ensure you have entered your {FirstName}");
        }
    }
}
