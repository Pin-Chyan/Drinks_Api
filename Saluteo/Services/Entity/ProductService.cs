namespace Saluteo.Services.Entity
{
    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    public class ProductService
    {
        private readonly IGenericRepository<Product> _productRepository;

        public ProductService(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();

            return products.ToList();
        }

        public async Task<Product?> GetProductByIdAsync(long id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return null;
            }

            return product;
        }

        public async Task<Product?> CreateProductAsync(ProductDto productDto)
        {
            if (productDto == null)
            {
                return null;
            }

            var product = new Product
            {
                // Barcode validation
                Barcode = productDto.Barcode,
                ProductName = productDto.ProductName,
                ProductPrice = productDto.ProductPrice,
                ProductCategoryId = productDto.ProductCategoryId,
                CountryId = productDto.CountryId,
                CurrencyId = productDto.CurrencyId,
            };

            await _productRepository.InsertAsync(product);
            return product;
        }

        public async Task<Product?> UpdateProductAsync(long id, ProductDto updatedProductDto)
        {
            var existingProduct = await GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.Barcode = updatedProductDto.Barcode;
            existingProduct.ProductName = updatedProductDto.ProductName;
            existingProduct.ProductPrice = updatedProductDto.ProductPrice;
            existingProduct.ProductCategoryId = updatedProductDto.ProductCategoryId;
            existingProduct.CountryId = updatedProductDto.CountryId;
            existingProduct.CurrencyId = updatedProductDto.CurrencyId;

            await _productRepository.UpdateAsync(existingProduct);
            return existingProduct;
        }

        public async Task<bool> DeleteProductAsync(long id)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return false;
            }

            await _productRepository.DeleteAsync(id);
            return true;
        }
    }
}
