using Onyx.Core.Application.Common;

namespace JwtApp.Models
{
    public class UsersDb
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username = "onyxuser", EmailAddress = "onyxuser@onyx.com", Password = "Password1", GivenName = "Vivek", Surname = "Lakshmi", Role = "Administrator" }
        };
    }
}
