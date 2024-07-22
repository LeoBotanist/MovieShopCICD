
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Data;

public class MovieShopDbContext: DbContext
{
    public DbSet<Cast> Casts { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieCast> MovieCasts { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Trailer> Trailers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options)
        : base(options)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost; Database=MovieShop; User=sa; Password=bigStrongPwd126; TrustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovieGenre>(ConfigureMovieGenres);
        modelBuilder.Entity<MovieCast>(ConfigureMovieCasts);
        modelBuilder.Entity<Favorite>(ConfigureFavorites);
        modelBuilder.Entity<Review>(ConfigureReviews);
        modelBuilder.Entity<Purchase>(ConfigurePurchases);
        modelBuilder.Entity<UserRole>(ConfigureUserRoles);
        modelBuilder.Entity<Movie>(ConfigureMovies);
        modelBuilder.Entity<User>(ConfigureUsers);
    }

    private void ConfigureMovieGenres(EntityTypeBuilder<MovieGenre> builder)
    {
        builder.HasKey(mg => new { mg.MovieId, mg.GenreId });
    }

    private void ConfigureMovieCasts(EntityTypeBuilder<MovieCast> builder)
    {
        builder.HasKey(mc => new { mc.CastId, mc.MovieId });
        builder.HasOne(mc => mc.Movie)
            .WithMany(m => m.MovieCasts)
            .HasForeignKey(mc => mc.MovieId);
        builder.HasOne(mc => mc.Cast)
            .WithMany(c => c.MovieCasts)
            .HasForeignKey(mc => mc.CastId);
    }

    private void ConfigureFavorites(EntityTypeBuilder<Favorite> builder)
    {
        builder.HasKey(f => new { f.MovieId, f.UserId });
    }
    private void ConfigureReviews(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => new { r.MovieId, r.UserId });
        builder.Property(r => r.CreatedDate).IsRequired().HasColumnType("datetime2");
        builder.Property(r => r.Rating).IsRequired().HasColumnType("decimal(3,2)");
    }

    private void ConfigurePurchases(EntityTypeBuilder<Purchase> builder)
    {
        builder.HasKey(p => new { p.MovieId, p.UserId });
        builder.Property(p => p.PurchaseDateTime).IsRequired().HasColumnType("datetime2");
        builder.Property(p => p.TotalPrice).IsRequired().HasColumnType("decimal(5,2)");
        builder.Property(p => p.PurchaseNumber).IsRequired().HasColumnType("uniqueidentifier");
    }

    private void ConfigureUserRoles(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(ur => new { ur.RoleId, ur.UserId });
    }

    private void ConfigureMovies(EntityTypeBuilder<Movie> builder)
    {
        builder.Property(m => m.Budget).HasColumnType("decimal(18,4)");
        builder.Property(m => m.CreatedDate).HasColumnType("datetime2");
        builder.Property(m => m.Price).HasColumnType("decimal(5,2)");
        builder.Property(m => m.ReleaseDate).HasColumnType("datetime2");
        builder.Property(m => m.Revenue).HasColumnType("decimal(18,4)");
        builder.Property(m => m.UpdatedDate).HasColumnType("datetime2");

        builder.HasMany(m => m.Casts)
            .WithMany(c => c.Movies)
            .UsingEntity<MovieCast>(
                j => j
                    .HasOne(mc => mc.Cast)
                    .WithMany(c => c.MovieCasts)
                    .HasForeignKey(mc => mc.CastId),
                j => j.HasOne(mc => mc.Movie)
                    .WithMany(m => m.MovieCasts)
                    .HasForeignKey(mc => mc.MovieId));
    }

    private void ConfigureUsers(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.IsLocked).HasColumnType("bit");
    }
    
}