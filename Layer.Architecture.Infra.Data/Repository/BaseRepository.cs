using Autoglass.Architecture.Domain.Entities;
using Autoglass.Architecture.Domain.Interfaces;
using Autoglass.Architecture.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Autoglass.Architecture.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly MySqlContext _mySqlContext;

        public BaseRepository(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

        public void Insert(Produto obj)
        {
            _mySqlContext.Set<Produto>().Add(obj);
            _mySqlContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _mySqlContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _mySqlContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _mySqlContext.SaveChanges();
        }

        public IList<TEntity> Select() =>
            _mySqlContext.Set<TEntity>().ToList();

        public TEntity Select(int id) =>
            _mySqlContext.Set<TEntity>().Find(id);  

        public void Update(Produto obj)
        {
            _mySqlContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _mySqlContext.SaveChanges();
        }

        public void DeleteNovo(Produto obj)
        {
            _mySqlContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _mySqlContext.SaveChanges();
        }
    }
}
