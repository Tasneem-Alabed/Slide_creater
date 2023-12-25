using Slid_App.Models.DTO;

namespace Slid_App.Models.Interfse
{
    public interface IUFile
    {
        Task <UFileDTO> GetUFile();

        Task <UFileDTO> GitFileByName(string name);

        Task<UFileDTO> DeleteFile(int id);
    }
}
