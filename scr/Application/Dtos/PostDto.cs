namespace Application.Dtos;
public class PostDto
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime LastModified { get; set; }
}
