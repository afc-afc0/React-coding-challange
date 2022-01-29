using Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public interface IFileService
    {
        Task<File> GetFileById(int id);
        IReadOnlyList<File> GetRandomImageFiles(int count);
    }
}
