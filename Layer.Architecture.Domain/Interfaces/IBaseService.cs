using FluentValidation;
using Autoglass.Architecture.Domain.Entities;
using System.Collections.Generic;

namespace Autoglass.Architecture.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        Produto Add(Produto produto);

        void Delete(int id);

        IEnumerable<Produto> Get();

        Produto GetById(int id);

        Produto Update(Produto produto);
    }
}
