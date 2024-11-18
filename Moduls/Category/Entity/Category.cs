public sealed class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public List<Video>? Videos { get; set; }
}