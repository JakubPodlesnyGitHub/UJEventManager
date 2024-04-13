using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.Auth
{
    public class UserRegisterCommand : IRequest<AuthDTO>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Picture { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public UserRegisterCommand(string firstName, string lastName, DateTime birthDate, string? picture, string email, string phoneNumber, string password, bool isAdmin)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Picture = picture;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}