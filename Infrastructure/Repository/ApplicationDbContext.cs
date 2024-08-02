using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Contato> Contato { get; set; }
    }
}
