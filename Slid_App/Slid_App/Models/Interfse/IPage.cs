using Slid_App.Models.DTO;

namespace Slid_App.Models.Interfse
{
    public interface IPage
    {
        Task<PageDTO> UpdatePage(int id ,PageDTO page);
    }
}
