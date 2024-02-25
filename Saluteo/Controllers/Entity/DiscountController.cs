namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Services.Entity;

    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly DiscountService _discountService;

        public DiscountController(DiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Discount>>> GetAllDiscounts()
        {
            var discounts = await _discountService.GetAllDiscountsAsync();

            return Ok(discounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Discount>> GetDiscountById(long id)
        {
            var discount = await _discountService.GetDiscountByIdAsync(id);
            if (discount == null)
            {
                return NotFound();
            }

            return Ok(discount);
        }

        [HttpPost]
        public async Task<ActionResult<Discount>> CreateDiscount([FromBody] DiscountDto discountDto)
        {
            var createdDiscount = await _discountService.CreateDiscountAsync(discountDto);
            if (createdDiscount == null)
            {
                return BadRequest("Invalid data");
            }

            return Ok(createdDiscount);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Discount>> UpdateDiscount(long id, [FromBody] DiscountDto updatedDiscountDto)
        {
            var updatedDiscount = await _discountService.UpdateDiscountAsync(id, updatedDiscountDto);
            if (updatedDiscount == null)
            {
                return NotFound();
            }

            return Ok(updatedDiscount);
        }
    }
}
