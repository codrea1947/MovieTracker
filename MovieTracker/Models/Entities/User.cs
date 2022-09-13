using Microsoft.AspNetCore.Identity;

namespace MovieTracker.Models.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime? InsertDate { get; set; }

    }
}
