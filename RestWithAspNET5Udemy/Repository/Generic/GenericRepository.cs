using Microsoft.EntityFrameworkCore;
using RestWithAspNET5Udemy.Model.Base;
using RestWithAspNET5Udemy.Model.Context;
using RestWithAspNET5Udemy.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNET5Udemy.Repository.Generic
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private SQLServerContext _context;
        //Cria dataSet dinâmico de acordo
        private DbSet<TEntity> dataset;

        public GenericRepository(SQLServerContext context)
        {
            _context = context;
            dataset = _context.Set<TEntity>();
        }
        public List<TEntity> FindAll()
        {
            return dataset.ToList();
        }

        public TEntity FindById(int id)
        {
            return dataset.FirstOrDefault(p => p.Id.Equals(id));
        }
        public TEntity Create(TEntity item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public TEntity Update(TEntity item)
        {
            var result = dataset.FirstOrDefault(p => p.Id.Equals(item.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public void Delete(int id)
        {
            var result = dataset.FirstOrDefault(p => p.Id.Equals(id));
            try
            {
                dataset.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Exists(int id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }
    }
}
