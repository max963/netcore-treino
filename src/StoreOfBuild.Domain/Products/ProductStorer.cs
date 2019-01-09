using StoreOfBuild.Domain.Dtos;

namespace StoreOfBuild.Domain.Products
{
    public class ProductStorer
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;

        public ProductStorer(IRepository<Product> productRepository, IRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public void Store(ProductDto dto)
        {
            var category = _categoryRepository.getById(dto.CategoryId);
            DomainException.When(category == null, "Category is Required");

            var product = _productRepository.getById(dto.Id); 

            if(product == null){
                product = new Product(dto.Name, dto.Price, dto.StockQuantity);
                _productRepository.Save(product);
            }
            else
            {
                product.Update(dto.Name, dto.Price, dto.StockQuantity);
            }
        }
    }
}