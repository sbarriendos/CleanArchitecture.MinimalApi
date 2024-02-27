using System.ComponentModel.DataAnnotations;

namespace Domain.Entites;
public class PostEntity
{
    [Key]
    public int Id { get; set; }
    public string? Content { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime LastModified { get; set; }
}
