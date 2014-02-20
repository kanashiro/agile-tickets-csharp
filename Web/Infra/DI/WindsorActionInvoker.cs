using System.Collections.Generic;
using System.Web.Mvc;
using Castle.MicroKernel;

namespace AgileTickets.Web.Infra.DI
{

    public class WindsorActionInvoker : ControllerActionInvoker
    {
        readonly IKernel kernel;

        public WindsorActionInvoker(IKernel kernel)
        {
            this.kernel = kernel;
        }

        protected override ActionExecutedContext InvokeActionMethodWithFilters(
                ControllerContext controllerContext,
                IList<IActionFilter> filters,
                ActionDescriptor actionDescriptor,
                IDictionary<string, object> parameters)
        {
            foreach (IActionFilter actionFilter in filters)
            {
                kernel.InjectProperties(actionFilter);
            }
            return base.InvokeActionMethodWithFilters(controllerContext, filters, actionDescriptor, parameters);
        }
    }
}