

using Entity.Model;
using Mapper.Adress;
using Microsoft.AspNetCore.Http;
using Model.Adress;
using Repository.Interface;
using Service.Interface;

namespace Service
{
    public class AdressService : IAdressService
    {
        private readonly AdressIRepository _adressRepository;
        private readonly IConnectionService _connectionService;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public AdressService(AdressIRepository adressRepository, IConnectionService connectionService,IHttpContextAccessor httpContextAccessor)
        {
            _adressRepository = adressRepository;
            _connectionService = connectionService;
            _httpContextAccessor = httpContextAccessor;

        }

        /// add addresse <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<AdressRead> Add(AdressAdd request)
        {
            var userInfo = _connectionService.GetCurrentUserInfo(_httpContextAccessor);
            int userId = userInfo.Id;
            if (userInfo.Id == 0)
                throw new ArgumentException("l'action a échoué :l'utilisateur ne existe pas");

            var addresseToAdd = AdressMapper.TransformDtoAdd(request);

            var addresse = await _adressRepository.CreateElementAsync(addresseToAdd).ConfigureAwait(false);

            bool AddAdresseToUser = await _adressRepository.AddAdressToUser(userId, addresseToAdd.Id);
            if (AddAdresseToUser == false)
                throw new ArgumentException("l'action a échoué : l'adresse n'a pas été trouvée");

            return AdressMapper.TransformDtoExit(addresse);
        }

        /// get addresse by user id <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<List<AdressRead>> GetAddresseForUser()
        {
            var userInfo = _connectionService.GetCurrentUserInfo(_httpContextAccessor);
            int userId = userInfo.Id;
            if (userInfo.Id == 0)
                throw new ArgumentException("l'action a échoué :l'utilisateur  ne existe pas");

            var addresselist = await _adressRepository.GetAdressesForUser(userId).ConfigureAwait(false);
            if (addresselist == null)
                throw new ArgumentException("l'action a échoué");

            List<AdressRead> addresseDto = new();
            foreach (Adress addresse in addresselist)
            {
                addresseDto.Add(AdressMapper.TransformDtoExit(addresse));
            }
            return addresseDto;
        }

        /// <summary>
        /// update addresse
        /// </summary>
        /// <param name="request"></param>
        /// <param name="IdAddresse"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>

        public async Task<AdressRead> Update(AdressAdd request, int IdAddress)
        {
            var uniteGet = await _adressRepository.GetByKeys(IdAddress).ConfigureAwait(false);
            if (uniteGet == null)
                throw new ArgumentException("l'action a échoué : l'adresse n'a pas été trouvée");

            var address = AdressMapper.TransformDtoUpdate(request, uniteGet);
            var addressUpdate = await _adressRepository.UpdateElementAsync(address).ConfigureAwait(false);
            return AdressMapper.TransformDtoExit(addressUpdate);
        }

        ///delete comment <summary>
        /// </summary>
        /// <param name="IdAddresse"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Adress> Delete(int IdAddress)
        {
            var address = await _adressRepository.GetByKeys(IdAddress);
            if (address == null)
                throw new ArgumentException("l'action a échoué : l'adresse n'a pas été trouvée");

            var deleteAdress = await _adressRepository.DeleteElementAsync(address);
            if (deleteAdress == null)
                throw new ArgumentException("l'action a échoué : l'adresse n'a pas été supprime");

            return deleteAdress;
        }
    }
}
