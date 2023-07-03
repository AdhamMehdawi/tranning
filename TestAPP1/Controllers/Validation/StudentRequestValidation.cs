using FluentValidation;

namespace TestAPP1.Controllers.Validation
{
    public class StudentRequestValidation : AbstractValidator<Student.StudentDto>
    {
        public StudentRequestValidation()   {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Name).MaximumLength(10).WithMessage("Name should not be more than 10 characters");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Name should not be less than 3 characters");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Age is required");
            RuleFor(x => x.Age).InclusiveBetween(18, 60).WithMessage("Age should be between 18 and 60");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.IsActive).NotNull().WithMessage("IsActive is required");
        }
    }
}
