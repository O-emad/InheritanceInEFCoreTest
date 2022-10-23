using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using InheritanceInEFCoreTest.Domain;
using InheritanceInEFCoreTest.Services.Helpers;

namespace InheritanceInEFCoreTest
{
    public class PaginationAttribute : ActionFilterAttribute
    {
        private readonly string template;
        private readonly Type type;

        public PaginationAttribute(string template, Type type)
        {
            this.template = template?? throw new ArgumentNullException(nameof(template));
            this.type = type?? throw new ArgumentNullException(nameof(type));
        }




        public override void OnResultExecuting(ResultExecutingContext context)
        {
            try
            {
               
                var actionResult = context.Result as OkObjectResult;
                var result = actionResult.Value as PagedList<BaseEntity>;
                if (result is not null)
                {
                    var x = result.HasNext;
                }
            }
            catch { }
            base.OnResultExecuting(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var arguments = context.ActionArguments.Where(c => c.Key == template).Select(c=>c.Value).FirstOrDefault();
            var argumentType = arguments?.GetType();
            if(argumentType == type)
            {

            }

            context.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
            base.OnActionExecuting(context);
        }
    }
}
