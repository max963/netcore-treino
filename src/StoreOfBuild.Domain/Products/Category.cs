namespace StoreOfBuild.Domain.Products
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category(string name)
        {
            ValidateAndSetName(name);
        }

        private void ValidateAndSetName(string name)
        {
            DomainException.When(string.IsNullOrEmpty(name), "Name is required");
            Id = id;
            Name = name;
        }
    }
}