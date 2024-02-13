

using AutoMapper;
using Entity.Model;
using Mapper.Adress;
using Microsoft.AspNetCore.Http;
using Model.Adress;
using Repository.Interface.User;
using Service.Interface.User;

namespace Service.User
{
    public class AdressService : IAdressService
    {
        private readonly AdressIRepository _adressRepository;
        private readonly IConnectionService _connectionService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;



        public AdressService(AdressIRepository adressRepository, IConnectionService connectionService, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _adressRepository = adressRepository;
            _connectionService = connectionService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;

        }

        /// <summary> 
        /// add  adress
        /// </summary>
        /// <param name="request">.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Le message d'exception.</exception>
        public async Task<AdressRead> CreateAdress(AdressAdd request)
        {
            var userInfo = _connectionService.GetCurrentUserInfo(_httpContextAccessor);
            int userId = userInfo.Id;

            if (userId == 0)
                throw new ArgumentException("L'action a échoué : l'utilisateur n'existe pas");

            Adress addressEntity = _mapper.Map<Adress>(request);
            addressEntity.UserId = userId;

            Adress addedAddress = await _adressRepository.CreateElementAsync(addressEntity).ConfigureAwait(false);

            return _mapper.Map<AdressRead>(addedAddress);
        }



        /// get addresse by user id <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<IEnumerable<AdressRead>> GetAddressesOfAUser()
        {
            var userInfo = _connectionService.GetCurrentUserInfo(_httpContextAccessor);
            int userId = userInfo.Id;
            if (userInfo.Id == 0)
                throw new ArgumentException("l'action a échoué :l'utilisateur  ne existe pas");

            var addresselist = await _adressRepository.GetAdressesByUserId(userId).ConfigureAwait(false);
            if (addresselist == null)
                throw new ArgumentException("l'action a échoué");

            return _mapper.Map<IEnumerable<AdressRead>>(addresselist);
        }

        /// <summary>
        /// update addresse
        /// </summary>
        /// <param name="request"></param>
        /// <param name="IdAddresse"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<AdressRead> UpdateAdress(AdressPut request, int IdAddress)
        {
            var existingAddress = await _adressRepository.GetByKeys(IdAddress).ConfigureAwait(false);
            if (existingAddress == null)
                throw new ArgumentException("L'action a échoué : l'adresse n'a pas été trouvée");

            _mapper.Map(request, existingAddress);

            var updatedAddress = await _adressRepository.UpdateElementAsync(existingAddress).ConfigureAwait(false);

            return _mapper.Map<AdressRead>(updatedAddress);
        }


        ///delete adress <summary>
        /// </summary>
        /// <param name="IdAdresse"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Adress> DeleteAdress(int IdAdress)
        {
            var address = await _adressRepository.GetByKeys(IdAdress);
            if (address == null)
                throw new ArgumentException("L'action a échoué : l'adresse n'a pas été trouvée");

            var deleteAdress = await _adressRepository.DeleteElementAsync(address);
            if (deleteAdress == null)
                throw new ArgumentException("L'action a échoué : l'adresse n'a pas été supprime");

            return deleteAdress;
        }
    }
}
