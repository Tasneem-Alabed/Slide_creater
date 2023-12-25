using Slid_App.Models.Interfse;

namespace Slid_App.Models.Servicse
{
    public class UserServices : IUser
    {
        public Task<User> AddFile(int UserId, UFile uFile)
        {
            throw new NotImplementedException();
        }

        public Task<User> AddSlid(int UserID, Slid slid)
        {
            throw new NotImplementedException();
        }

        public Task<User> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
