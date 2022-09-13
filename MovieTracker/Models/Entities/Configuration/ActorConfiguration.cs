using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieTracker.Models.Entities.Configuration
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(actor => actor.Name).IsRequired().HasMaxLength(50);
            builder.Property(actor => actor.BirthDate).IsRequired(); 
            builder.Property(actor => actor.CNP).IsRequired().IsUnicode();  
        }
    }
}
