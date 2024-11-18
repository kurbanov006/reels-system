using MediatR;
using Microsoft.EntityFrameworkCore;

public class VideoCreateCommandHandler(IVideoRepository repository
, IFileService fileService, IUserRepository userRepository) : IRequestHandler<CreateVideoInfo, Result<bool>>
{
    public async Task<Result<bool>> Handle(CreateVideoInfo request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId);
        if (user is not null)
            if (!user.IsAdmin)
                return Result<bool>.Fail(Error.BadRequest("Only adnim can post videos"));

        var video = await request.ToCreate(fileService);

        int res = await repository.CreateAsync(video);
        return res > 0
        ? Result<bool>.Success(true)
        : Result<bool>.Fail(Error.BadRequest());
    }
}