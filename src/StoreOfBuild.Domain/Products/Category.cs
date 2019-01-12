namespace StoreOfBuild.Domain.Products
{
    public class Category: Entity
    {
        
        public string Name { get; set; }

        public Category(string name)
        {
            ValidateAndSetName(name);
        }

        public void Update(string name)
        {
            ValidateAndSetName(name);
        }

        private void ValidateAndSetName(string name)
        {
            DomainException.When(string.IsNullOrEmpty(name), "Name is required");
            Name = name;
        }
    }
}