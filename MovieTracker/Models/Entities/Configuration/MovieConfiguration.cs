using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieTracker.Models.Entities.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(movie => movie.Title).IsRequired().HasMaxLength(50);
            builder.Property(movie => movie.Description).IsRequired().HasMaxLength(50);
            builder.Navigation(movie => movie.MovieTypes).AutoInclude();
        }
    }
}
