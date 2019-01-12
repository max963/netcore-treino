using System.Linq;
using StoreOfBuild.Domain;

namespace StoreOfBuild.Data
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity : Entity
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context){
            _context = context;
        }
        public TEntity getById(int Id)
        {
            return _context.Set<TEntity>().SingleOrDefault(e => e.Id == Id);
        }

        public void Save(TEntity entity){
            _context.Set<TEntity>().Add(entity);
        }
    }
}