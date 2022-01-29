using DAL.Interfaces;
using Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FileRepository : GenericRepository<File>, IFileRepository
    {
        public FileRepository(ApplicationContext context) : base(context) { }

        public Task<IEnumerable<File>> GetRandomImageFiles(int count)
        {
            throw new NotImplementedException();
        }
    }
}
