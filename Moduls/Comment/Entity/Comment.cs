public sealed class Comment : BaseEntity
{
    public string Text { get; set; }=string.Empty;
    public int UserId { get; set; }
    public int VideoId { get; set; }
    public User? User { get; set; }
    public Video? Video { get; set; }
}