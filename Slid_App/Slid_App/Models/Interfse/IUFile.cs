namespace Slid_App.Models.Interfse
{
    public interface IUFile
    {
        Task <UFile> GetUFile();

        Task <UFile> GitFileByName(string name);

        Task<UFile> DeleteFile(int id);
    }
}
