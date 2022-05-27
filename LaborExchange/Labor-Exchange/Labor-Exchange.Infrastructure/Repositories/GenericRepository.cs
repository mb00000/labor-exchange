using Labor_Exchange.Application.IRepositories;
using Labor_Exchange.Application.Paging;
using Labor_Exchange.Core.Entities;
using Labor_Exchange.Infrastructure.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Labor_Exchange.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private EFContext _db;

        private DbSet<TEntity> _table;

        public GenericRepository(EFContext dbcontext)
        {
            this._db = dbcontext;
            this._table = dbcontext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity item)
        {
            await this._table.AddAsync(item);
            await this.SaveAsync();
        }

        public async Task DeleteAsync(TEntity item)
        {
            this._table.Remove(item);
            await this.SaveAsync();
        }

        public async Task<TEntity> GetOneAsync(int id)
        {
            return await this._table.FirstOrDefaultAsync<TEntity>(entity => entity.Id == id);
        }

        public async Task SaveAsync()
        {
            await this._db.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity item)
        {
            this._table.Update(item);
            await this.SaveAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            this._table.UpdateRange(entities);
            await this._db.SaveChangesAsync();
        }

        public async Task<PagedList<TEntity>> GetPageAsync(PageParameters pageParameters)
        {
            var entities = await this._table
                         .AsNoTracking()
                         .Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize)
                         .Take(pageParameters.PageSize)
                         .ToListAsync();
            var count = await this._table.CountAsync();

            return new PagedList<TEntity>(entities, pageParameters, count);
        }

        public async Task<PagedList<TEntity>> GetPageAsync(PageParameters pageParameters, Expression<Func<TEntity, bool>> predicate)
        {
            var entities = await this._table
                                     .AsNoTracking()
                                     .Where(predicate)
                                     .Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize)
                                     .Take(pageParameters.PageSize)
                                     .ToListAsync();
            var count = await this._table.CountAsync();

            return new PagedList<TEntity>(entities, pageParameters, count);
        }

        public void Attach(params object[] obj)
        {
            this._db.AttachRange(obj);
        }
    }
}
