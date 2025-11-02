using LivroManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LivroManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Livro> Livros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=LivroManagerDB;Trusted_Connection=True;");
        }
    }
}
