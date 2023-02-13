namespace Zanobia.Helper.Dtos.Account
{
    public class ResetPasswordDTO
    {
        public string AdminUserName { get; set; }
        public string UserId { get; set; }
        public string AdminPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
