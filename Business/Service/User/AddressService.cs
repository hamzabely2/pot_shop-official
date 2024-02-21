

using AutoMapper;
using Entity.Model;
using Mapper.Adress;
using Microsoft.AspNetCore.Http;
using Model.Adress;
using Repository.Interface.User;
using Service.Interface.User;

namespace Service.User
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IConnectionService _connectionService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;



        public AddressService(IAddressRepository addressRepository, IConnectionService connectionService, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _connectionService = connectionService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;

        }

        /// <summary> 
        /// add address
        /// </summary>
        /// <param name="request">.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Le message d'exception.</exception>
        public async Task<ReadAddress> CreateAddress(AddAddress request)
        {
            var userInfo = _connectionService.GetCurrentUserInfo(_httpContextAccessor);
            int userId = userInfo.Id;

            if (userId == 0)
                throw new ArgumentException("L'action a échoué : l'utilisateur n'existe pas");

            Address addressEntity = _mapper.Map<Address>(request);
            addressEntity.UserId = userId;

            Address addedAddress = await _addressRepository.CreateElementAsync(addressEntity).ConfigureAwait(false);

            return _mapper.Map<ReadAddress>(addedAddress);
        }



        /// get addresse by user id <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<IEnumerable<ReadAddress>> GetAddressesOfAUser()
        {
            var userInfo = _connectionService.GetCurrentUserInfo(_httpContextAccessor);
            int userId = userInfo.Id;
            if (userInfo.Id == 0)
                throw new ArgumentException("l'action a échoué :l'utilisateur  ne existe pas");

            var addresselist = await _addressRepository.GetAddressesByUserId(userId).ConfigureAwait(false);
            if (addresselist == null)
                throw new ArgumentException("l'action a échoué");

            return _mapper.Map<IEnumerable<ReadAddress>>(addresselist);
        }

        /// <summary>
        /// update addresse
        /// </summary>
        /// <param name="request"></param>
        /// <param name="IdAddresse"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<ReadAddress> UpdateAddress(PutAddress request, int IdAddress)
        {
            var existingAddress = await _addressRepository.GetByKeys(IdAddress).ConfigureAwait(false);
            if (existingAddress == null)
                throw new ArgumentException("L'action a échoué : l'adresse n'a pas été trouvée");

            _mapper.Map(request, existingAddress);

            var updatedAddress = await _addressRepository.UpdateElementAsync(existingAddress).ConfigureAwait(false);

            return _mapper.Map<ReadAddress>(updatedAddress);
        }


        ///delete address <summary>
        /// </summary>
        /// <param name="IdAddresse"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Address> DeleteAddress(int IdAddress)
        {
            var address = await _addressRepository.GetByKeys(IdAddress);
            if (address == null)
                throw new ArgumentException("L'action a échoué : l'adresse n'a pas été trouvée");

            var deleteAddress = await _addressRepository.DeleteElementAsync(address);
            if (deleteAddress == null)
                throw new ArgumentException("L'action a échoué : l'adresse n'a pas été supprime");

            return deleteAddress;
        }
    }
}
