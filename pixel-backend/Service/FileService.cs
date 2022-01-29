using DAL.Interfaces;
using Infastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Service
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<File> GetFileById(int id)
        {
            return await _fileRepository.GetById(id);
        }

        public  IReadOnlyList<File> GetRandomImageFiles(int count)
        {
            return _fileRepository.GetRandomImageFiles(count);
        }
    }
}
