using MediatR;

public class GetByIdQueryHandler(IUserRepository repository) : IRequestHandler<GetById, Result<ReadUserInfo>>
{
    public async Task<Result<ReadUserInfo>> Handle(GetById request, CancellationToken cancellationToken)
    {
        User? user = await repository.GetByIdAsync(request.Id);
        if (user is null)
            return Result<ReadUserInfo>.Fail(Error.NotFound());

        if (user.IsDeleted)
            return Result<ReadUserInfo>.Fail(Error.NotFound());

        return Result<ReadUserInfo>.Success(user.ToRead());

    }
}

public readonly record struct GetById(int Id) : IRequest<Result<ReadUserInfo>>;