using Infastructure.Entities;
using pixel_backend.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public interface IFileService
    {
        Task<FileDTO> GetFileById(int id);
        IReadOnlyList<FileDTO> GetRandomImageFiles(int count);
    }
}
