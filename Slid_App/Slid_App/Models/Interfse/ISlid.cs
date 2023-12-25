using Slid_App.Models.DTO;

namespace Slid_App.Models.Interfse
{
    public interface ISlid
    {
        Task<List<SlidDTO>> GetSlids();

        Task<SlidDTO> GetSlid(int id);

        Task<SlidDTO> DeleteSlidById(int id);

        Task<SlidDTO> UpdateSlid(int id , SlidDTO slid);

        Task<SlidDTO> CreatePage(int SlidId, PageDTO page);

        Task<SlidDTO> DeletePage(int PageId);
    }
}
