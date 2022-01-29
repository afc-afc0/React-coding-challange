using Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IFileRepository : IGenericRepository<File>
    {
        Task<IEnumerable<File>> GetRandomImageFiles(int count); 
    }
}
