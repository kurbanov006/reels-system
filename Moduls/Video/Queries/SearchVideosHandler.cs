using MediatR;

public class SearchVideosHandler(IVideoRepository repository) : IRequestHandler<SearchVideo, Result<IQueryable<VideoSearch>>>
{
    public async Task<Result<IQueryable<VideoSearch>>> Handle(SearchVideo request, CancellationToken cancellationToken)
    {
        IQueryable<Video> videos = await repository.GetAllAsync();
        IQueryable<VideoSearch> res = videos.Where(v => !v.IsDeleted && v.VideoName.Contains(request.Name))
        .Select(x => new VideoSearch()
        {
            VideoName = x.VideoName
        });

        return res is null
        ? Result<IQueryable<VideoSearch>>.Fail(Error.NotFound())
        : Result<IQueryable<VideoSearch>>.Success(res);
    }
}

public record SearchVideo(string Name) : IRequest<Result<IQueryable<VideoSearch>>>;