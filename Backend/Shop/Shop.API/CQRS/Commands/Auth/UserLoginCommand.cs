namespace Shop.API.CQRS.Commands.Auth
{
    public class UserLoginCommand : ICommandBase
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public UserLoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
