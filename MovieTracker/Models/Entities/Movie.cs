using System.ComponentModel.DataAnnotations;

namespace MovieTracker.Models.Entities
{
    public class Movie : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<MovieType> MovieTypes { get; set; }  
    }
}
