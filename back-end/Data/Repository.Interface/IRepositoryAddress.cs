using Api.Data.Context.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Repository.Contract
{
    public interface IRepositoryAddress : IGenericRepository<Address>
    {
        Task<Boolean> AddAdressToUser(string IdUser, int IdAdresse);
        Task<List<Address>> GetAdressesForUser(string IdUser);
    }
}
