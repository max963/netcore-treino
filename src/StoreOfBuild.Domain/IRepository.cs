namespace StoreOfBuild.Domain
{
    public interface IRepository<TEntity>
    {
        TEntity getById(int id);
        void Save(TEntity entity);
    }
}