using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllQueryVideo(IVideoRepository repository) : IRequestHandler<VideoFilter, Result<PaginationResponse<IQueryable<ReadVideoInfo>>>>
{
    public async Task<Result<PaginationResponse<IQueryable<ReadVideoInfo>>>> Handle(VideoFilter request, CancellationToken cancellationToken)
    {
        IQueryable<Video> videos = await repository.GetAllAsync();
        if (videos is null)
            return Result<PaginationResponse<IQueryable<ReadVideoInfo>>>.Fail(Error.NotFound());

        IQueryable<ReadVideoInfo> readUsers = videos
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Where(x => !x.IsDeleted)
            .Select(x => x.ToRead());

        int count = await readUsers.CountAsync();

        PaginationResponse<IQueryable<ReadVideoInfo>> response =
        PaginationResponse<IQueryable<ReadVideoInfo>>.Create(request.PageNumber, request.PageSize, count, readUsers);

        return Result<PaginationResponse<IQueryable<ReadVideoInfo>>>.Success(response);
    }
}