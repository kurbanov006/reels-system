using FluentValidation;
using MediatR;

public class CreateUserCommandHadler(IUserRepository repository, IValidator<CreateUserInfo> validator) : IRequestHandler<CreateUserInfo, Result<bool>>
{
    public async Task<Result<bool>> Handle(CreateUserInfo request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return Result<bool>.Fail(Error.BadRequest(validationResult.Errors.First().ErrorMessage));
        }
        IQueryable<User> users = await repository.GetAllAsync();
        bool conflict = users.Any(x => x.Email == request.BaseUserInfo.Email ||
        x.UserName == request.BaseUserInfo.UserName);

        if (conflict)
            return Result<bool>.Fail(Error.Conflict());

        int res = await repository.CreateAsync(request.ToCreate());
        return res > 0
        ? Result<bool>.Success(true)
        : Result<bool>.Fail(Error.BadRequest());
    }
}