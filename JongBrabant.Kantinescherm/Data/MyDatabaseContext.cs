using JongBrabant.Kantinescherm.Models;
using Microsoft.EntityFrameworkCore;

namespace JongBrabant.Kantinescherm.Data
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext (DbContextOptions<MyDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> Todo { get; set; }
    }
}
