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
            DomainException.When(name.Length <= 3, "Name must be at last 4 charatctere");
            Name = name;
        }
    }
}