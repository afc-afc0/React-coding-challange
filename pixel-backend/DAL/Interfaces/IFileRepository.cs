using Infastructure.Entities;
using System.Collections.Generic;


namespace DAL.Interfaces
{
    public interface IFileRepository : IGenericRepository<File>
    {
        List<File> GetRandomImageFiles(int count); 
    }
}
