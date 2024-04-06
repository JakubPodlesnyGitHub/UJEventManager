namespace Shop.API.CQRS.Commands.User
{
    public class AddedUserCommand : ICommandBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Picture { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public AddedUserCommand(string firstName, string lastName, DateTime birthDate, string? picture, string email, string phone, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Picture = picture;
            Email = email;
            Phone = phone;
            Password = password;
        }
    }
}