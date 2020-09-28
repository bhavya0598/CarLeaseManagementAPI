using LeaseManagement.DataEntities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace LeaseManagement.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly LeaseManagementDbContext _context;
        private readonly DbSet<TEntity> entities;

        public Repository(LeaseManagementDbContext context)
        {
            _context = context;
            entities = _context.Set<TEntity>();
        }

        #region Execute SQL Query Without Parameters
        public async Task<List<TEntity>> ExecuteSqlQuery(string query) => await entities.FromSql(query).ToListAsync();
        #endregion

        #region Execute SQL Query With Parameters
        public async Task<TEntity> ExecuteSqlQueryWithParameters(string query, List<SqlParameter> parameter = null) => await entities.FromSql(query, parameter.ToArray()).FirstOrDefaultAsync();
        #endregion

        #region Execute Non Query
        public async Task<bool> ExecuteNonQuery(string query, SqlParameter parameter) => await entities.FromSql(query, parameter).AnyAsync();
        #endregion

        #region Get All
        public async Task<List<TEntity>> GetAll() => await entities.ToListAsync();
        #endregion

        #region Get Element By Id
        public async Task<TEntity> GetElementById(int id) => await entities.FindAsync(id);
        #endregion

        #region Insert
        public async Task Insert(TEntity entity)
        {
            if (entity != null)
            {
                await entities.AddAsync(entity);
            }
            else
            {
                throw new ArgumentNullException("Entity");
            }
        }
        #endregion

        #region Update   
        public void Update(TEntity entity)
        {
            if (entity != null)
            {
                entities.Update(entity);
            }
            else
            {
                throw new ArgumentNullException("Entity");
            }
        }
        #endregion

        #region Delete
        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                entities.Remove(entity);
            }
            else
            {
                throw new ArgumentNullException("Entity");
            }
        }
        #endregion
    }
}
