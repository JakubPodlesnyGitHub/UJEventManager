namespace Shop.API.CQRS.Commands.Auth
{
    public class UserPasswordChangedCommand : ICommandBase
    {
        public Guid Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        public UserPasswordChangedCommand(Guid id, string oldPassword, string newPassword)
        {
            Id = id;
            OldPassword = oldPassword;
            NewPassword = newPassword;
        }
    }
}
