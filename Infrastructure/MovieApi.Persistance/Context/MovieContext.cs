using Microsoft.EntityFrameworkCore;
using MovieApi.Domain.Entities;

namespace MovieApi.Persistance.Context;

public class MovieContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "server=localhost;user=SA;password=reallyStrongPwd123;database=MovieApiDb;TrustServerCertificate=true;Integrated Security=false;");
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Cast> Casts { get; set; }
    public DbSet<Tag> Tags { get; set; }


}