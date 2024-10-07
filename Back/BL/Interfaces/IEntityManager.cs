using ENTITIES;
using ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IEntityManager<T> where T : EntityBase
    {
        Task<int> Add(T entity);
        Task<T?> Get(int id);
        Task<int> Update(T entity);
        Task<int> Delete(int id);
    }
}
