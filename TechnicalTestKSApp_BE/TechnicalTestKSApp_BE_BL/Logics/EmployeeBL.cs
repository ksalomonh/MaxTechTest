using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TechnicalTestKSApp_BE_BL.Interfaces;
using TechnicalTestKSApp_BE_BL.Interfaces.Logics;
using TechnicalTestKSApp_BE_BL.Interfaces.Repositories;
using TechnicalTestKSApp_BE_BL.Models;
using TechnicalTestKSApp_BE_DA.Interfaces;

namespace TechnicalTestKSApp_BE_BL.Logics
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly IResponse _response;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeBL(IResponse response, IEmployeeRepository employeeRepository)
        {
            _response = response;
            _employeeRepository = employeeRepository;
        }
        public async Task<IResponse> Delete(int id)
        {
            int result = await _employeeRepository.Delete(id);
            await _response.Set(result);
            return _response;
        }

        public async Task<IResponse> Get(int id)
        {
            IEnumerable<Employee> employees = await _employeeRepository.Get(id);
            _response.Response = employees;
            return await Task.FromResult(_response);
        }

        public async Task<IResponse> Get()
        {
            IEnumerable<Employee> employees = await _employeeRepository.Get();
            _response.Response = employees;
            return await Task.FromResult(_response);
        }

        public async Task<IResponse> Insert(Employee employee)
        {
            employee = await _employeeRepository.Insert(employee);
            await _response.Set(employee);
            return _response;
        }

        public async Task<IResponse> Update(Employee employee)
        {
            employee = await _employeeRepository.Update(employee);
            await _response.Set(employee);
            return _response;
        }
    }
}
