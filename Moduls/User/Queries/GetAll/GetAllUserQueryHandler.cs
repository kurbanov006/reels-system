using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllUserQueryHandler(IUserRepository repository)
: IRequestHandler<UserFilter, Result<PaginationResponse<IQueryable<ReadUserInfo>>>>
{
    public async Task<Result<PaginationResponse<IQueryable<ReadUserInfo>>>> Handle(UserFilter request, CancellationToken cancellationToken)
    {
        IQueryable<User> users = await repository.GetAllAsync();

        if (users is null)
            return Result<PaginationResponse<IQueryable<ReadUserInfo>>>.Fail(Error.NotFound());

        IQueryable<ReadUserInfo> readUsers = users
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Where(x => !x.IsDeleted)
            .Select(x => x.ToRead());

        int count = await readUsers.CountAsync();

        PaginationResponse<IQueryable<ReadUserInfo>> response =
        PaginationResponse<IQueryable<ReadUserInfo>>.Create(request.PageNumber, request.PageSize, count, readUsers);

        return Result<PaginationResponse<IQueryable<ReadUserInfo>>>.Success(response);
    }
}