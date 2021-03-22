using System.Threading.Tasks;
using Common.DomainModel;

namespace Common.DataAccess.Abstraction
{
    public interface IWriteRepository<in T> where T : EntityBase
    {
        Task CreateAsync(T entity);

        Task SaveChangesAsync();

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
