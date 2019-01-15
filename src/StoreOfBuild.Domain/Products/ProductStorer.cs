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

        public void Store(int id, string name, int categoryId, decimal price, int stockQuantity)
        {
            var category = _categoryRepository.getById(categoryId);
            DomainException.When(category == null, "Category is Required");

            var product = _productRepository.getById(id); 

            if(product == null){
                product = new Product(name, category, price, stockQuantity);
                _productRepository.Save(product);
            }
            else
            {
                product.Update(name, category, price, stockQuantity);
            }
        }
    }
}