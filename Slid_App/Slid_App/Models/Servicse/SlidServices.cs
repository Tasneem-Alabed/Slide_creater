using Slid_App.Models.Interfse;

namespace Slid_App.Models.Servicse
{
    public class SlidServices : ISlid
    {
        public Task<Slid> CreatePage(int SlidId, Page page)
        {
            throw new NotImplementedException();
        }

        public Task<Slid> DeletePage(int PageId)
        {
            throw new NotImplementedException();
        }

        public Task<Slid> DeleteSlidById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Slid> GetSlid(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Slid>> GetSlids()
        {
            throw new NotImplementedException();
        }

        public Task<Slid> UpdateSlid(int id, Slid slid)
        {
            throw new NotImplementedException();
        }
    }
}
