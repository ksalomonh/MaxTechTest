using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using TechnicalTestKSApp_BE_DA.Interfaces;
using TechnicalTestKSApp_BE_DA.Models;

namespace TechnicalTestKSApp_BE_DA
{
    public class SqlContext : IDbContext
    {
        private IDbConnection _connection;
        private readonly IConfiguration _configuration;

        public SqlContext(IDbConnection connection)
        {
            _connection = connection;
            CreateConnection().GetAwaiter().GetResult();
        }

        //private readonly string _connectionString;
        //public SqlContext(IDbConnection connection, string connectionStringKey, IWebHostEnvironment env, IConfiguration configuration)
        //{

        //7-}<o{G~#lPGYXW

        //    _connection = connection;
        //    _configuration = configuration;
        //    ConnectionStrings connectionStrings = _configuration.GetSection($"AppSettings:{nameof(ConnectionStrings)}").Get<ConnectionStrings>();
        //    _connectionString = connectionStrings.SqlConnection;
        //    switch (connectionStringKey)
        //    {
        //        case nameof(ConnectionStrings.SqlConnection):
        //            _connection.ConnectionString = connectionStrings.SqlConnection;
        //            break;
        //    }
        //}
        public async Task<IDbConnection> CreateConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            return _connection;
        }

        public async Task<int> ExecuteAsync<TParams>(TParams parameters, string query, int? commandTimeout = null)
            where TParams : class
        {
            SpResult result = await RunProcedureAsync<SpResult, object>(parameters, query, commandTimeout);
            //int entityId = await _connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout);
            _connection.Close();
            return result.ResultId;
        }

        public async Task<IEnumerable<TResult>> RunProcedureListAsync<TResult, TParams>(TParams parameters, string query, int? commandTimeout = null)
            where TResult : class
            where TParams : class
        {
            IEnumerable<TResult> entity = await _connection.QueryAsync<TResult>(query, parameters, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout);
            _connection.Close();
            return entity;
        }

        public async Task<TResult> RunProcedureAsync<TResult, TParams>(TParams parameters, string query, int? commandTimeout = null)
            where TResult : class
            where TParams : class
        {
            TResult entity = await _connection.QueryFirstOrDefaultAsync<TResult>(query, parameters, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout);
            _connection.Close();
            return entity;
        }
    }
}