using Labor_Exchange.Application.IRepositories;
using Labor_Exchange.Core.Entities;
using Labor_Exchange.Infrastructure.ApplicationContext;
using Microsoft.EntityFrameworkCore;

namespace Labor_Exchange.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        public GenericRepository(EFContext dbcontext)
        {
            this._db = dbcontext;
            this._table = dbcontext.Set<TEntity>();
        }

        private EFContext _db;

        private DbSet<TEntity> _table;

        public async Task AddAsync(TEntity item)
        {
            await this._table.AddAsync(item);
            await this.SaveAsync();
        }

        public void Attach(params object[] obj)
        {
            this._db.AttachRange(obj);
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
    }
}
