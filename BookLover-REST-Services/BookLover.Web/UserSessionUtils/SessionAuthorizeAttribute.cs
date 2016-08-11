namespace BookLover.Web.UserSessionUtils
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Controllers;

    using DataAccessLayer.Data;
    using Ninject;

    public class SessionAuthorizeAttribute: AuthorizeAttribute
    {
        protected IBookLoverData Data { get; private set; }

        protected IUserSessionManager UserSessionManager { get; set; }

        [Inject]
        public void ReceiveDependencies(IBookLoverData data, IUserSessionManager userSessionManager)
        {
            this.Data = data;
            this.UserSessionManager = userSessionManager;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (SkipAuthorization(actionContext))
            {
                return;
            }

            if (this.UserSessionManager.RevalidateUserSession())
            {
                base.OnAuthorization(actionContext);
            }
            else
            {
                actionContext.Response = actionContext.ControllerContext.Request.CreateErrorResponse(
                    HttpStatusCode.Unauthorized, "Session token expired or not valid");
            }
        }

        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any() ||
                   actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }
    }
}