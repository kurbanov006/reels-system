public interface IFileService
{
    Task<string> CreateFile(IFormFile formFile, string folder);
    bool DeleteFile(string file, string folder);
}