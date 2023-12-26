using Microsoft.AspNetCore.Mvc.ModelBinding;
using Slid_App.Models.DTO;

using System.Security.Claims;


namespace Slid_App.Models.Interfse
{
    public interface IUser
    {
     Task <UserDTO> GetUserById(int id);

     Task <UserDTO> UpdateUser(int id ,UserDTO user);

     Task <UserDTO> CreateUser(UserDTO user);

    


    }
}
