using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestKSApp_BE_BL.Interfaces;
using TechnicalTestKSApp_BE_BL.Interfaces.Repositories;
using TechnicalTestKSApp_BE_BL.Logics;
using TechnicalTestKSApp_BE_BL.Models;
using TechnicalTestKSApp_BE_DA.Interfaces;

namespace TechnicalTestKSApp_BE_BL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbContext _dbService;
        private DynamicParameters _parameters;
        public EmployeeRepository(IDbContext dbService)
        {
            _dbService = dbService;
        }

        public async Task<int> Delete(int id)
        {
            _parameters = new();
            _parameters.Add("EmployeeId", id);
            int result = await _dbService.ExecuteAsync<object>(_parameters, "dbo.SPDeleteEmployee");
            return result;
        }

        public async Task<IEnumerable<Employee>> Get(int id)
        {
            _parameters = new();
            _parameters.Add("EmployeeId", id);
            IEnumerable<Employee> employees = await _dbService.RunProcedureListAsync<Employee, object>(_parameters, "dbo.SPGetEmployee");
            return employees;
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            IEnumerable<Employee> employees = await _dbService.RunProcedureListAsync<Employee, object>(new { }, "dbo.SPGetAllEmployees");
            return employees;
        }

        public async Task<Employee> Insert(Employee employee)
        {
            _parameters = new();
            _parameters.Add("@NationalityId", employee.NationalityId);
            _parameters.Add("@EmployeeNumber", employee.EmployeeNumber);
            _parameters.Add("@Name", employee.Name);
            _parameters.Add("@LastName", employee.LastName);
            _parameters.Add("@BirthDate", employee.BirthDate);
            _parameters.Add("@Curp", employee.Curp);
            _parameters.Add("@Ssn", employee.Ssn);
            _parameters.Add("@Phone", employee.Phone);
            employee.EmployeeId = await _dbService.ExecuteAsync<object>(_parameters, "dbo.SPAddEmployee");
            return employee;
        }

        public async Task<Employee> Update(Employee employee)
        {
            _parameters = new();
            _parameters.Add("@EmployeeId", employee.EmployeeId);
            _parameters.Add("@NationalityId", employee.NationalityId);
            _parameters.Add("@EmployeeNumber", employee.EmployeeNumber);
            _parameters.Add("@Name", employee.Name);
            _parameters.Add("@LastName", employee.LastName);
            _parameters.Add("@BirthDate", employee.BirthDate);
            _parameters.Add("@Curp", employee.Curp);
            _parameters.Add("@Ssn", employee.Ssn);
            _parameters.Add("@Phone", employee.Phone);
            employee.EmployeeId = await _dbService.ExecuteAsync<object>(_parameters, "dbo.SPEditEmployee");
            return employee;
        }
    }
}
