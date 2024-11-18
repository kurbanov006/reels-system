public class VideoRepository : GenericRepository<Video>, IVideoRepository
{
    public VideoRepository(AppDbContext context) : base(context)
    {
    }
}