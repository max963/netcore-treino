using Microsoft.EntityFrameworkCore;
using StoreOfBuild.Domain.Products;
using System.Collections.Generic;
using System.Linq;

namespace StoreOfBuild.Data
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Product getById(int Id)
        {
            var query = _context.Set<Product>().Include(c => c.Category).Where(e => e.Id == Id);

            if (query.Any())
            {
                return query.First();
            }

            return null;
        }

        public override IEnumerable<Product> All()
        {
             var query = _context.Set<Product>().Include(p => p.Category);

            return query.Any() ? query.ToList() : new List<Product>();
        }

        

    }
}