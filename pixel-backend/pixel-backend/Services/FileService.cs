using AutoMapper;
using DAL.Interfaces;
using Infastructure.Entities;
using Microsoft.EntityFrameworkCore;
using pixel_backend.DTO;
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
        private readonly IMapper _mapper;

        public FileService(IFileRepository fileRepository, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
        }

        public async Task<FileDTO> GetFileById(int id)
        {
            return _mapper.Map<FileDTO>(await _fileRepository.GetById(id));
        }

        public  IReadOnlyList<FileDTO> GetRandomImageFiles(int count)
        {
            return _mapper.Map<IReadOnlyList<FileDTO>>(_fileRepository.GetRandomImageFiles(count));
        }
    }
}
