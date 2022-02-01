using pixel_backend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public interface IFileService
    {
        Task<FileDTO> GetFileById(int id);
        IReadOnlyList<FileDTO> GetRandomImageFiles(int count);
    }
}
