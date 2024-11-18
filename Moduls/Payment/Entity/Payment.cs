public sealed class Payment : BaseEntity
{
    public int UserId { get; set; } 
    public int VideoId { get; set; }
    public decimal Amount { get; set; }
    public Video? Video { get; set; }
    public User? User { get; set; }
}