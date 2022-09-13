using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieTracker.Models.Entities.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasKey(ma => new {ma.MovieId, ma.ActorId});
            builder.HasOne(m => m.Movie).WithMany(r => r.Roles).HasForeignKey(r => r.MovieId);  
            builder.HasOne(a => a.Actor).WithMany(r => r.Roles).HasForeignKey(r => r.ActorId);      
            builder.Property(r => r.RoleDescription).IsRequired().HasMaxLength(50);
            builder.Navigation(r => r.Movie).AutoInclude();
            builder.Navigation(r => r.Actor).AutoInclude();
        }
    }
}
