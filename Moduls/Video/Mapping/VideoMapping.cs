public static class VideoMapping
{
    public static async Task<Video> ToCreate(this CreateVideoInfo video, IFileService fileService)
    {
        return new Video()
        {
            Title = video.Title,
            Description = video.Description,
            VideoName = await fileService.CreateFile(video.File!, "videos"),
            IsPaid = video.IsPaid,
            UserId = video.UserId,
            CategoryId = video.CategoryId
        };
    }

    public static Video ToUpdate(this Video video, UpdateVideoInfo updateVideo)
    {
        video.Title = updateVideo.Title;
        video.Description = updateVideo.Description;
        video.IsPaid = updateVideo.IsPaid;
        video.UserId = updateVideo.UserId;
        video.CategoryId = updateVideo.CategoryId;
        video.UpdatedAt = DateTime.UtcNow;
        return video;
    }

    public static ReadVideoInfo ToRead(this Video video)
    {
        return new ReadVideoInfo()
        {
            Id = video.Id,
            FileName = video.VideoName,
            BaseVideoInfo = new BaseVideoInfo()
            {
                Title = video.Title,
                Description = video.Description,
                IsPaid = video.IsPaid,
                UserId = video.UserId,
                CategoryId = video.CategoryId
            }
        };
    }

    public static Video ToDelete(this Video video)
    {
        video.IsDeleted = true;
        video.DeletedAt = DateTime.UtcNow;
        return video;
    }
}
