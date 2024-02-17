namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IRepository<Client> _clientRepository;

        public ClientController(IRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetAllClients()
        {
            var clients = _clientRepository.GetAll().ToList();
            return Ok(clients);
        }

        [HttpPost]
        public ActionResult CreateClient([FromBody] ClientDto clientDto)
        {
            if (clientDto == null)
            {
                return BadRequest("Invalid data");
            }

            // Mapper :/
            var client = new Client
            {
                IdNumber = clientDto.IdNumber,
                FirstName = clientDto.FirstName,
                LastName = clientDto.LastName,
                DateOfBirth = clientDto.DateOfBirth,
                Email = clientDto.Email,
                Password = clientDto.Password
            };

            _clientRepository.Insert(client);

            return Ok(client);
        }
    }
}
