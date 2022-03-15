using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BookApp.Filters
{
    public class QueueMsgAttribute : ActionFilterAttribute
    {
        public QueueMsgAttribute()
        {

        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            //TODO: Enqueue your message here for PUT, POST and DELETE operations
        }
    }
}