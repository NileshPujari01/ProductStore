using Microsoft.EntityFrameworkCore;

namespace ProductStore.Application.Tests
{
    public abstract class BaseBuilder<T, TContext> where TContext : DbContext
    {
        protected TContext Context { get; }
        protected BaseBuilder(TContext context)
        {
            Context = context;
        }
        public abstract T AddToCollection(T newEntity);
    }
}
