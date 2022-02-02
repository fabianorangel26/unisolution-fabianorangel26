using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace UniSolution.FabianoRangel26.EntityFramework.Repositories
{
    public abstract class FabianoRangel26RepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<FabianoRangel26DbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected FabianoRangel26RepositoryBase(IDbContextProvider<FabianoRangel26DbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class FabianoRangel26RepositoryBase<TEntity> : FabianoRangel26RepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected FabianoRangel26RepositoryBase(IDbContextProvider<FabianoRangel26DbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
