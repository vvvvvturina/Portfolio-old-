using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
        :base(options)
    {
    }

    public DbSet<Request> Requests { get; set; }
}