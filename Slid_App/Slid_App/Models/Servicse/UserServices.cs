using Slid_App.Models.DTO;
using Slid_App.Models.Interfse;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace Slid_App.Models.Servicse
{
    public class UserServices : IUser
    {
        private readonly SlideAppDbContext _context;

        public UserServices(SlideAppDbContext context)
        {
            _context = context;
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

        /// <summary>
        /// Get User data by ID.
        /// </summary>
        /// <param name="id">ID of the User.</param>
        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await _context.Users
             .Where(u => u.UserId == id)
                .FirstOrDefaultAsync();

            if (user == null)
            {
               
                return null;
            }
            var userDto = new UserDTO
            {

                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                DateOfBerth = user.DateOfBerth,
                PhoneNumber = user.PhoneNumber,
                ImageBase64 = user.ImageBase64

            };

            return userDto;
        }
        /// <summary>
        /// Update User data by ID.
        /// </summary>
        /// <param name="User">Updated User data.</param>
        /// <param name="id">ID of the User to be updated.</param>
        public async Task<UserDTO> UpdateUser(int id, UserDTO user)
        {
            var update_user = await _context.Users.FindAsync(id);

            if (update_user != null)
            {
                update_user.UserId = id;
                update_user.Name = user.Name;
                update_user.Email = user.Email;
                update_user.Password = user.Password;
                update_user.DateOfBerth = user.DateOfBerth;
                update_user.PhoneNumber = user.PhoneNumber;
                update_user.ImageBase64 = user.ImageBase64;

                _context.Entry(update_user).State = EntityState.Modified;
               

                await _context.SaveChangesAsync();
            }
            user.UserId = id;
            var user1 = await GetUserById(user.UserId);
            return user1;
        }
    }
}
