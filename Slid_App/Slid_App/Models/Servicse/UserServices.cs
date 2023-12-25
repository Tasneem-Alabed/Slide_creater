using Slid_App.Models.DTO;
using Slid_App.Models.Interfse;
using Microsoft.EntityFrameworkCore;

namespace Slid_App.Models.Servicse
{
    public class UserServices : IUser
    {
        private readonly SlideAppDbContext _context;

        public UserServices(SlideAppDbContext context)
        {
            _context = context;
        }

        public Task<UserDTO> AddFile(int UserId, UFileDTO uFile)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> AddSlid(int UserID, SlidDTO slid)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new User.
        /// </summary>
        /// <param name="UserDTO">User data.</param>
        public async Task<UserDTO> CreateUser(UserDTO user)
        {
            var newUser = new User()
            {
              UserId=user.UserId,
              Name=user.Name,
              Email=user.Email,
              Password=user.Password,
              DateOfBerth=user.DateOfBerth,
              PhoneNumber=user.PhoneNumber,
              ImageBase64=user.ImageBase64

            };
            _context.Entry<User>(newUser).State = EntityState.Added;
           
            await _context.SaveChangesAsync();
            var userDTO = await GetUserById(newUser.UserId);
            user.UserId = newUser.UserId;

            return userDTO;
        }

        public Task<UserDTO> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> UpdateUser(int id, UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
