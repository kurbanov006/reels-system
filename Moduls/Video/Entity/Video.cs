public sealed class Video : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string VideoName { get; set; } = string.Empty;
    public bool IsPaid { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public User? User { get; set; }
    public List<Comment>? Comments { get; set; }
}