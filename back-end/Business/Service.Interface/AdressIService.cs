
using Entity.Model;
using Model.Adress;

namespace Service.Interface
{
    public interface AdressIService
    {
        Task<AdressRead> Add(AdressAdd request);
        Task<List<AdressRead>> GetAddresseForUser();
        Task<AdressRead> Update(AdressAdd request, int adresseId);
        Task<Adress> Delete(int IdAddresse);
    }
}
