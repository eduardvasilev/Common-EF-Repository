using System.Linq;
using System.Threading.Tasks;
using Common.DomainModel;

namespace Common.DataAccess.Abstraction
{
    public interface IReadRepository<T> where T : EntityBase
    {
        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(string id);
    }
}