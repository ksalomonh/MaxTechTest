using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestKSApp_BE_BL.Models;

namespace TechnicalTestKSApp_BE_BL.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<int> Delete(int id);
        Task<IEnumerable<Employee>> Get(int id);
        Task<IEnumerable<Employee>> Get();
        Task<Employee> Insert(Employee employee);
        Task<Employee> Update(Employee employee);
    }
}
