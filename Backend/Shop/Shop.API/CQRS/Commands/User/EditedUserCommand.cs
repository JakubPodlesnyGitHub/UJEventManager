namespace Shop.API.CQRS.Commands.User
{
    public class EditedUserCommand : ICommandBase
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Picture { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public EditedUserCommand(Guid id, string firstName, string lastName, DateTime birthDate, string? picture, string email, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Picture = picture;
            Email = email;
            Phone = phone;
        }
    }
}