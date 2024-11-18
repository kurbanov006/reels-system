using MediatR;

public class GetVideoAndComments(IVideoRepository videoRepository) : IRequestHandler<IdVideoAndComments, Result<VideoAndComments>>
{
    public async Task<Result<VideoAndComments>> Handle(IdVideoAndComments request, CancellationToken cancellationToken)
    {
        Video? video = await videoRepository.GetByIdAsync(request.Id);
        if (video is null)
            return Result<VideoAndComments>.Fail(Error.NotFound("Not found"));

        VideoAndComments videoAndComments = new VideoAndComments()
        {
            VideoName = video.VideoName,
            Comments = video.Comments!.Select(c => new Comment
            {
                Id = c.Id,
                CreatedAt = c.CreatedAt,
                Text = c.Text
            }).ToList()
        };

        return Result<VideoAndComments>.Success(videoAndComments);
    }
}

public record IdVideoAndComments(int Id) : IRequest<Result<VideoAndComments>>;