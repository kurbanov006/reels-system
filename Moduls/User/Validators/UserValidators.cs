using FluentValidation;

public class UserValidators : AbstractValidator<CreateUserInfo>
{
    public UserValidators()
    {
        RuleFor(x => x.BaseUserInfo.UserName)
            .NotEmpty().WithMessage("Username is required")
            .MinimumLength(3).WithMessage("Username should be at least 3 characters");

        RuleFor(x => x.BaseUserInfo.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");

        RuleFor(x => x.BaseUserInfo.Age)
            .NotEmpty().WithMessage("Age is required")
            .ExclusiveBetween(10, 75).WithMessage("Age must be between 10 and 75, exclusive");
    }
}