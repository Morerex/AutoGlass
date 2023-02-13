using Autoglass.Architecture.Domain.Entities;
using System.Collections.Generic;

namespace Autoglass.Architecture.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(Produto obj);

        void Update(TEntity obj);

        void DeleteNovo(Produto obj);

        void Delete(int id);

        IList<TEntity> Select();

        TEntity Select(int id);
    }
}
