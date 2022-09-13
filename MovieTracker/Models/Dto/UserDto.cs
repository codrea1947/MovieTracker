namespace MovieTracker.Models.Dto
{
    public class UserLogIn
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }

    public class UserRegister
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }

    public class UserResponse
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}
