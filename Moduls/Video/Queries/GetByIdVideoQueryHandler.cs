using MediatR;

public class GetByIdVideoQueryHandler(IVideoRepository repository) : IRequestHandler<GetByIdVideo, Result<ReadVideoInfo>>
{
    public async Task<Result<ReadVideoInfo>> Handle(GetByIdVideo request, CancellationToken cancellationToken)
    {
        Video? video = await repository.GetByIdAsync(request.Id);
        if (video is null)
            return Result<ReadVideoInfo>.Fail(Error.NotFound());

        if (video.IsDeleted)
            return Result<ReadVideoInfo>.Fail(Error.NotFound());

        return Result<ReadVideoInfo>.Success(video.ToRead());
    }
}

public record GetByIdVideo(int Id) : IRequest<Result<ReadVideoInfo>>;