using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdeaManagement.Domain.Services
{
    public interface  IApiDataService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Create(T entity);

        Task<T> Update(int id, T entity);

        Task<bool> Delete(int id);


    }
}
