using Common.DataAccess.Abstraction;
using Common.DomainModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Common.DataAccess.Implementation.EF
{
    public class ReadRepository<T> : IReadRepository<T> where T : EntityBase
    {
        private readonly EfContext _context;

        public ReadRepository(EfContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public Task<T> GetByIdAsync(string id)
        {
            return _context.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id);
        }
    }
}
