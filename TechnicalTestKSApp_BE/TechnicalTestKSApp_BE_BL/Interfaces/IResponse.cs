using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTestKSApp_BE_BL.Interfaces
{
    public interface IResponse
    {
        bool IsSuccess { get; set; }
        Object Response { get; set; }
        Dictionary<string, IEnumerable<string>> Errors { get; set; }
        Task Set<T>(T entity) where T : class;
        Task Set(int result);
    }
}
