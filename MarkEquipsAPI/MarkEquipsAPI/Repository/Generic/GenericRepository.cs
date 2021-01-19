using MarkEquipsAPI.Models.Base;
using System.Collections.Generic;
using System;
using MarkEquipsAPI.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MarkEquipsContext _context;
        private readonly DbSet<T> dataset;

        public GenericRepository(MarkEquipsContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public async Task<List<T>> FindAllAsync()
        {
            return await dataset.Include("Reservations").
                ToListAsync();
        }

        public async Task<T> FindByIDAsync(int id)
        {
            return await dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                dataset.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error in: " + e.Message);
            }

            return entity;
        }

        public async Task UpdateAsync(T item, T entity)
        {
            try
            {
                _context.Entry(item).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error in: " + e.Message);
            }
        }

        public async Task DeleteAsync(T item)
        {
            try
            {
                dataset.Remove(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error in: " + e.Message);
                ;
            }

        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await dataset.AnyAsync(e => e.Id.Equals(id));
        }

        public async Task<List<T>> FindWithPagedSearch(string query)
        {
            return await dataset.FromSqlRaw<T>(query).ToListAsync();
        }

        public int GetCount(string query)
        {
            var result = "";
            using (var connection = _context.Database.GetDbConnection())
            {
                connection.Open();
                using(var command = connection.CreateCommand()){
                    command.CommandText = query;
                    result = command.ExecuteScalar().ToString();
                }
            }
            return int.Parse(result);
        }
    }
}
