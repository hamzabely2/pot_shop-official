
using Entity.Model;
using Model.Adress;

namespace Service.Interface.User
{
    public interface IAdressService
    {
        Task<AdressRead> CreateAdress(AdressAdd request);
        Task<IEnumerable<AdressRead>> GetAddressesOfAUser();
        Task<AdressRead> UpdateAdress(AdressPut request, int adresseId);
        Task<Adress> DeleteAdress(int IdAdresse);
    }
}
