using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Linq;

namespace MovieTracker.Models.Entities.Configuration
{
    public class MovieTypeFillIn : IEntityTypeConfiguration<MovieType>
    {
        public void Configure(EntityTypeBuilder<MovieType> builder)
        {
            builder.HasData(
                new MovieType
                { 
                    Id = 1,
                    Name = "SF"
                },
                new MovieType
                {
                Id = 2,
                    Name = "Action"
                },
                new MovieType
                {
                Id = 3,
                    Name = "Comedy"
                },
                new MovieType
                {
                Id = 4,
                    Name = "Horror"
                });

        }
    }
}
