namespace OnlineEdu.WebUI.Services.TokenServices
{
    public interface ITokenService
    {
        public string GetUserToken { get; }
        public string GetUserRole { get; }
        public int GetUserId { get; }
        public string GetUserNameSurname { get; }
    }
}
