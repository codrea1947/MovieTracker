namespace MovieTracker.Models.Entities
{
    public class Actor: IEntity
    {
        public int Id { get ; set ; }
        public int CNP { get ; set ; }  
        public string Name { get ; set ; }
        public DateTime BirthDate { get ; set ; }
        public ICollection<Role> Roles { get ; set ; }
    }
}
