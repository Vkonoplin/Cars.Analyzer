using System.Threading.Tasks;

namespace VK.Cars.Analyzer.Service.WebApi.Business.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        Task<T> GetById(int id);

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task<int> Delete(T entity);
    }
}
