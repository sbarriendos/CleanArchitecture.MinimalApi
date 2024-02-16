using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure;
public class SocialDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Post> Posts { get; set; }
}
