using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestKSApp_BE_BL.Interfaces;

namespace TechnicalTestKSApp_BE_BL.Models
{
    public class ResponseBase : IResponse
    {
        public bool IsSuccess { get; set; }
        public Object Response { get; set; }
        public Dictionary<string, IEnumerable<string>> Errors { get; set; }

        public ResponseBase(bool isSuccess = true)
        {
            IsSuccess = isSuccess;
            Errors = new Dictionary<string, IEnumerable<string>>();
        }

        public async Task Set<T>(T entity)
            where T : class
        {
            Response = entity;
        }

        public async Task Set(int result)
        {
            IsSuccess = result == 1;
            Response = null;
        }

    }
}
