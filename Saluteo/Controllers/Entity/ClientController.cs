namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService ClientService)
        {
            this._clientService = ClientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetAllClients()
        {
            var clients = await _clientService.GetAllClientsAsync();

            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClientById(long id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient([FromBody] ClientDto clientDto)
        {
            var createdClient = await _clientService.CreateClientAsync(clientDto);
            if (createdClient == null)
            {
                return BadRequest("Invalid data");
            }

            return Ok(createdClient);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Client>> UpdateClient(long id, [FromBody] ClientDto updatedClientDto)
        {
            var updatedClient = await _clientService.UpdateClientAsync(id, updatedClientDto);
            if (updatedClient == null)
            {
                return NotFound();
            }

            return Ok(updatedClient);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClient(long id)
        {
            var isDeleted = await _clientService.DeleteClientAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
