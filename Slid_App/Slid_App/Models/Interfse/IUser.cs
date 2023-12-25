using Microsoft.AspNetCore.Mvc.ModelBinding;

using System.Security.Claims;


namespace Slid_App.Models.Interfse
{
    public interface IUser
    {
     Task <User> GetUserById(int id);

     Task <User> UpdateUser(int id ,User user);

     Task <User> CreateUser(User user);

     Task <User> AddSlid(int UserID,Slid slid);

     Task<User> AddFile(int UserId, UFile uFile);


    }
}
