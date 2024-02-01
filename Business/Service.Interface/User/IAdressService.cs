
using Entity.Model;
using Model.Adress;

namespace Service.Interface.User
{
    public interface IAdressService
    {
        Task<AdressRead> Add(AdressAdd request);
        Task<List<AdressRead>> GetAddresseForUser();
        Task<AdressRead> Update(AdressAdd request, int adresseId);
        Task<Adress> Delete(int IdAddresse);
    }
}
