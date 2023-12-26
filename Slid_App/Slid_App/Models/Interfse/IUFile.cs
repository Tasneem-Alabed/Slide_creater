using Slid_App.Models.DTO;

namespace Slid_App.Models.Interfse
{
    public interface IUFile
    {
        Task <List<UFileDTO>> GetUFile(int id);

        Task <UFileDTO> GitFileByName(string name);

        Task<UFileDTO> DeleteFile(int id);

        Task<UFileDTO> CreateUFile(UFileDTO FileU);
    }
}
