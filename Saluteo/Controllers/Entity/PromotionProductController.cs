namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class PromotionProductController : ControllerBase
    {
        private readonly IRepository<PromotionProduct> _promotionProductRepository;

        public PromotionProductController(IRepository<PromotionProduct> promotionProductRepository)
        {
            _promotionProductRepository = promotionProductRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PromotionProduct>> GetAllPromotionProducts()
        {
            var promotionProducts = _promotionProductRepository.GetAll().ToList();
            return Ok(promotionProducts);
        }

        [HttpPost]
        public ActionResult CreatePromotionProduct([FromBody] PromotionProductDto promotionProductDto)
        {
            if (promotionProductDto == null)
            {
                return BadRequest("Invalid data");
            }

            // Mapper :/
            var promotionProduct = new PromotionProduct
            {
                PromotionId = promotionProductDto.PromotionId,
                ProductId = promotionProductDto.ProductId
            };

            _promotionProductRepository.Insert(promotionProduct);

            return Ok(promotionProduct);
        }
    }
}
