using Entity.Model;
using Model.Adress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.User
{
    public interface IAddressService
    {
        Task<ReadAddress> CreateAddress(AddAddress request);
        Task<IEnumerable<ReadAddress>> GetAddressesOfAUser();
        Task<ReadAddress> UpdateAddress(PutAddress request, int addresseId);
        Task<Address> DeleteAddress(int IdAddresse);
    }
}
