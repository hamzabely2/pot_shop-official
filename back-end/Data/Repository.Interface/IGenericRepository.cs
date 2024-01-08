using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Repository.Contract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByKeys(int id);
        Task<T> CreateElementAsync(T element);
        Task<T> UpdateElementAsync(T element);
        Task<T> DeleteElementAsync(T element);
    }
}
