
using MediatR;

public class UpdateUserCommandHandler(IUserRepository repository) : IRequestHandler<UpdateUserInfo, Result<bool>>
{
    public async Task<Result<bool>> Handle(UpdateUserInfo request, CancellationToken cancellationToken)
    {
        User? user = await repository.GetByIdAsync(request.Id);
        if (user is null)
            return Result<bool>.Fail(Error.NotFound());

        if (user.IsDeleted)
            return Result<bool>.Fail(Error.NotFound());

        user.ToUpdate(request);
        int res = await repository.UpdateAsync(user); 
        return res > 0
        ? Result<bool>.Success(true)
        : Result<bool>.Fail(Error.BadRequest());
    }
}