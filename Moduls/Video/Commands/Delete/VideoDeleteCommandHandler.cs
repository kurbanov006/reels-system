using MediatR;

public class VideoDeleteCommandHandler(IVideoRepository repository, IFileService fileService) : IRequestHandler<DeleteVideo, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteVideo request, CancellationToken cancellationToken)
    {
        Video? user = await repository.GetByIdAsync(request.Id);
        if (user is null)
            return Result<bool>.Fail(Error.NotFound());

        fileService.DeleteFile(user.VideoName, "videos");
        user.ToDelete();
        int res = await repository.UpdateAsync(user);
        return res > 0
        ? Result<bool>.Success(true)
        : Result<bool>.Fail(Error.BadRequest());
    }
}


public record DeleteVideo(int Id) : IRequest<Result<bool>>;