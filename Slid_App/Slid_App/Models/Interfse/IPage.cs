namespace Slid_App.Models.Interfse
{
    public interface IPage
    {
        Task<Page> UpdatePage(int id ,Page page);
    }
}
