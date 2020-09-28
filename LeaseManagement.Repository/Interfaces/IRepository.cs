using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace LeaseManagement.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity> GetElementById(int id);

        Task Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task<List<TEntity>> ExecuteSqlQuery(string query);

        Task<TEntity> ExecuteSqlQueryWithParameters(string query, List<SqlParameter> parameters = null);

        Task<bool> ExecuteNonQuery(string query, SqlParameter parameter);
    }
}
