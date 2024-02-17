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
        private readonly IRepository<Discount> _discountRepository;

        public DiscountController(IRepository<Discount> discountRepository)
        {
            _discountRepository = discountRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Discount>> GetAllDiscounts()
        {
            var discounts = _discountRepository.GetAll().Include(_ => _.ValueType).ToList();
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

            _discountRepository.Insert(discount);

            return Ok(discount);
        }
    }
}
