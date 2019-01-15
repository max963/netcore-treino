using System.Collections.Generic;
using System.Linq;
using StoreOfBuild.Domain;

namespace StoreOfBuild.Data
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context){
            _context = context;
        }

        public virtual IEnumerable<TEntity> All()
        {
            return _context.Set<TEntity>().AsEnumerable();
        }

        public virtual TEntity getById(int Id)
        {
            var query = _context.Set<TEntity>().Where(e => e.Id == Id);

            if (query.Any())
            {
                return query.First();
            }

            return null;
        }

        public void Save(TEntity entity){
            _context.Set<TEntity>().Add(entity);
        }
    }
}