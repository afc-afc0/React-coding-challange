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
        List<File> GetRandomImageFiles(int count); 
    }
}
