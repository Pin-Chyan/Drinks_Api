namespace Saluteo.Services
{
    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    public class ClientService
    {
        private readonly IGenericRepository<Client> _clientRepository;

        public ClientService(IGenericRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            var clients = await _clientRepository.GetAllAsync();

            return clients.ToList();
        }

        public async Task<Client?> GetClientByIdAsync(long id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                return null;
            }

            return client;
        }

        public async Task<Client?> CreateClientAsync(ClientDto clientDto)
        {
            if (clientDto == null)
            {
                return null;
            }

            var client = new Client
            {
                IdNumber = clientDto.IdNumber,
                FirstName = clientDto.FirstName,
                LastName = clientDto.LastName,
                DateOfBirth = clientDto.DateOfBirth,
                Email = clientDto.Email,
                Password = clientDto.Password
            };

            await _clientRepository.InsertAsync(client);

            return client;
        }

        public async Task<Client?> UpdateClientAsync(long id, ClientDto updatedClientDto)
        {
            var existingClient = await GetClientByIdAsync(id);
            if (existingClient == null)
            {
                return null;
            }

            existingClient.IdNumber = updatedClientDto.IdNumber;
            existingClient.FirstName = updatedClientDto.FirstName;
            existingClient.LastName = updatedClientDto.LastName;
            existingClient.DateOfBirth = updatedClientDto.DateOfBirth;
            existingClient.Email = updatedClientDto.Email;
            existingClient.Password = updatedClientDto.Password;

            await _clientRepository.UpdateAsync(existingClient);
            return existingClient;
        }

        public async Task<bool> DeleteClientAsync(long id)
        {
            var existingClient = await _clientRepository.GetByIdAsync(id);
            if (existingClient == null)
            {
                return false;
            }

            await _clientRepository.DeleteAsync(id);
            return true;
        }
    }
}
