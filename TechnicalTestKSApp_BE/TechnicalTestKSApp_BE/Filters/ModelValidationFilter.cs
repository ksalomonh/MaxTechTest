using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using TechnicalTestKSApp_BE_BL.Interfaces;
using TechnicalTestKSApp_BE_BL.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TechnicalTestKSApp_BE.Filters
{
    public class ModelValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                IResponse response = new ResponseBase(context.ModelState.IsValid);

                //var errorsInModelState = context.ModelState
                //    .Where(x => x.Value?.Errors.Count > 0)
                //    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage)).ToArray();

                //foreach (var error in errorsInModelState)
                //{
                //    foreach (var subError in error.Value)
                //    {
                //        var errorModel = new
                //        {
                //            FieldName = error.Key,
                //            Message = subError
                //        };

                //        response.Errors.Add(errorModel);
                //    }
                //}

                context.Result = new BadRequestObjectResult(response)
                {
                    ContentTypes =
                    {
                        Application.Json,
                        Application.Xml
                    }
                };
                return;
            }
            await next();
        }
    }
}
