using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieTracker.Models.Entities
{
    public class Role : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }  
        public int MovieId { get; set; }
        public Movie Movie { get; set; }    
        public int Money { get; set; }
        public string RoleDescription { get; set; }
    }
}
