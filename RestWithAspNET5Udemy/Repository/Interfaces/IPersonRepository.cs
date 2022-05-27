using RestWithAspNET5Udemy.Model;
using RestWithAspNET5Udemy.Model.Base;
using System.Collections.Generic;

namespace RestWithAspNET5Udemy.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Create(TEntity item);
        TEntity FindById(int id);
        List<TEntity> FindAll();
        TEntity Update(TEntity item);
        void Delete(int id);
        bool Exists(int id);

    }
}
