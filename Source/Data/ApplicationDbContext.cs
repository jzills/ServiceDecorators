using Microsoft.EntityFrameworkCore;

namespace Source.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}