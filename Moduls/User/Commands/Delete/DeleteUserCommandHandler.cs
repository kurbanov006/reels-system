using MediatR;

public class DeleteUserCommandHandler(IUserRepository repository) : IRequestHandler<DeleteUserInfo, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteUserInfo request, CancellationToken cancellationToken)
    {
        User? user = await repository.GetByIdAsync(request.Id);
        if (user is null)
            return Result<bool>.Fail(Error.NotFound());

        user.ToDelete();
        int res = await repository.UpdateAsync(user);
        return res > 0
        ? Result<bool>.Success(true)
        : Result<bool>.Fail(Error.BadRequest());
    }
}