namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IGenericRepository<Discount> _discountRepository;

        public DiscountController(IGenericRepository<Discount> discountRepository)
        {
            _discountRepository = discountRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Discount>>> GetAllDiscounts()
        {
            var discounts = await _discountRepository.GetAllAsync();

            return Ok(discounts);
        }

        [HttpPost]
        public ActionResult CreateDiscount([FromBody] DiscountDto discountDto)
        {
            if (discountDto == null)
            {
                return BadRequest("Invalid data");
            }

            // Mapper :/
            var discount = new Discount
            {
                ValueTypeId = discountDto.ValueTypeId,
                discountAmount = discountDto.discountAmount
            };

            _discountRepository.InsertAsync(discount);

            return Ok(discount);
        }
    }
}
