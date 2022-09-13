using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTracker.Models.Entities
{
    public class MovieType : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MinLength(1)]
        public string Name { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
