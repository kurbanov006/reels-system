using System.Security.Cryptography.X509Certificates;
using MediatR;

public record CreateVideoInfo : IRequest<Result<bool>>
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool IsPaid { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public IFormFile? File { get; set; }
}


public record UpdateVideoInfo : IRequest<Result<bool>>
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool IsPaid { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public IFormFile? File { get; set; }
}

public readonly record struct ReadVideoInfo(
    int Id,
    BaseVideoInfo BaseVideoInfo,
    string FileName
) : IRequest<Result<bool>>;