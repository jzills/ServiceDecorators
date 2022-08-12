using Microsoft.EntityFrameworkCore;

namespace ServiceDecorators.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}