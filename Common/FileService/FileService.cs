
public class FileService(IWebHostEnvironment hostEnvironment) : IFileService
{
    private const long MaxFileSize = 10 * 1024 * 1024;
    private readonly HashSet<string> _allowedExtentions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".mp4"
    };
    public async Task<string> CreateFile(IFormFile formFile, string folder)
    {
        if (_allowedExtentions.Contains(Path.GetExtension(formFile.FileName).ToLower()) == false)
            throw new InvalidOperationException("Invalid file type.");

        if (formFile.Length > MaxFileSize)
            throw new InvalidOperationException("File size exceeds the maximum allowed size.");

        string fileName = $"{Guid.NewGuid()}{Path.GetExtension(formFile.FileName)}";
        string folderPath = Path.Combine(hostEnvironment.WebRootPath, folder);

        if (Directory.Exists(folderPath) == false)
        {
            Directory.CreateDirectory(folderPath);
        }

        string fullPath = Path.Combine(folderPath, fileName);

        try
        {
            await using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            return fileName;
        }
        catch (Exception ex)
        {
            await Console.Error.WriteLineAsync(ex.Message);
            throw new InvalidOperationException("An error occurred while saving the file.");
        }
    }

    public bool DeleteFile(string file, string folder)
    {
        string folderPath = Path.Combine(hostEnvironment.WebRootPath, folder);
        string fullPath = Path.Combine(folderPath, file);

        try
        {
            if (Directory.Exists(folderPath) == false) return false;

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            throw new InvalidOperationException("An error occurred while delete the file.");
        }
    }
}