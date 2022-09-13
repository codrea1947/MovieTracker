using MovieTracker.Models.Entities;

namespace MovieTracker.Models.Dto
{
    public class RoleRequst
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }
        public int Money { get; set; }
        public string RoleDescription { get; set; }
    }

    public class RoleResonse
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
        public ActorForRoleResponse Actor { get; set; }
        public int MovieId { get; set; }
        public MovieResponse Movie { get; set; }
        public int Money { get; set; }
        public string RoleDescription { get; set; }
    }
}
