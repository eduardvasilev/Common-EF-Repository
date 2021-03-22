using System;
using System.Threading.Tasks;
using Common.DataAccess.Abstraction;
using Common.DomainModel;

namespace Common.DataAccess.Implementation.EF
{
    public class WriteRepository<T> : IWriteRepository<T> where T : EntityBase
    {
        private readonly EfContext _context;

        public WriteRepository(EfContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            await _context.Set<T>().AddAsync(entity);
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.FromResult(_context.Update(entity));
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.FromResult(_context.Remove(entity));
        }
    }
}