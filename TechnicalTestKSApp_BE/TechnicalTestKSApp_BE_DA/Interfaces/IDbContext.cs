using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTestKSApp_BE_DA.Interfaces
{
    public interface IDbContext
    {
        Task<IDbConnection> CreateConnection();
        Task<int> ExecuteAsync<TParams>(TParams parameters, string query, int? commandTimeout = null)
            where TParams : class;
        Task<IEnumerable<TResult>> RunProcedureListAsync<TResult, TParams>(TParams parameters, string query, int? commandTimeout = null)
            where TResult : class
            where TParams : class;
        Task<TResult> RunProcedureAsync<TResult, TParams>(TParams parameters, string query, int? commandTimeout = null)
            where TResult : class
            where TParams : class;
    }
}
