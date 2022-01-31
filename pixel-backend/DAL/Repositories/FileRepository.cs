using DAL.Interfaces;
using Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class FileRepository : GenericRepository<File>, IFileRepository
    {
        public FileRepository(ApplicationContext context) : base(context) { }

        public List<File> GetRandomImageFiles(int count)
        {
            Random rand = new Random();
            IReadOnlyList<File> files = _context.Files.ToList();

            HashSet<File> randomImageFiles = new HashSet<File>();
            for (int i = 0; i < count; i++)
            {
                int randomIndex = rand.Next(0, files.Count);
                randomImageFiles.Add(files[randomIndex]);
            }
            return randomImageFiles.ToList();
        }
    }
}
