using MarkEquipsAPI.Models.Base;
using System.Collections.Generic;
using System;
using MarkEquipsAPI.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MarkEquipsAPI.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MarkEquipsContext _context;
        private DbSet<T> dataset;

        public GenericRepository(MarkEquipsContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public List<T> FindAll()
        {
           return dataset.ToList();
        }

        public T FindByID(int id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Create(T entity)
        {
            try
            {
                dataset.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return entity;
        }

        public T Update(T entity)
        {
            var result = dataset.SingleOrDefault(e => e.Id.Equals(entity.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(entity);
                    _context.SaveChanges();
                    return entity;

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
            var result = dataset.SingleOrDefault(e => e.Id.Equals(id));
            if (result != null)
            {
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
        }

        public bool Exists(int id)
        {
            return dataset.Any(e => e.Id.Equals(id));
        }
    }
}
