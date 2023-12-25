namespace Slid_App.Models.Interfse
{
    public interface ISlid
    {
        Task<List<Slid>> GetSlids();

        Task<Slid> GetSlid(int id);

        Task<Slid> DeleteSlidById(int id);

        Task<Slid> UpdateSlid(int id ,Slid slid);

        Task<Slid> CreatePage(int SlidId, Page page);

        Task<Slid> DeletePage(int PageId);
    }
}
