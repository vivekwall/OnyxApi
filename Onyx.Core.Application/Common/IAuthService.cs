namespace Onyx.Core.Application.Common
{
    public interface IAuthService
    {
        public string GetAuthToken(UserLogin userLogin);
    }
}
