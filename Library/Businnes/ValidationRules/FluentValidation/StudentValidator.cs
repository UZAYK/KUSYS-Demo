using FluentValidation;
using KUSYSDemo.Models;

namespace KUSYSDemo.Business.ValidationRules.FluentValidation
{
    public class StudentValidator : AbstractValidator<StudentModel>
    {
        /// <summary>
        /// It is a discontinued operation.
        /// Purpose of use: The process of checking the request before it is received by the client with Fluent Validation
        /// </summary>
        public StudentValidator()
        {
            RuleFor(I => I.FirstName).NotNull().WithMessage("Please ensure you have entered your {FirstName}");
        }
    }
}
