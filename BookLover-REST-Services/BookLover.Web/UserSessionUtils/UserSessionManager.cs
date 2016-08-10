namespace BookLover.Web.UserSessionUtils
{
    using System;
    using System.Net.Http;
    using System.Linq;
    using System.Web;

    using EntityFramework.Extensions;
    using Microsoft.AspNet.Identity;

    using DataAccessLayer.Data;

    using EntityModels;

    public class UserSessionManager: IUserSessionManager
    {
        protected IBookLoverData Data { get; private set; }

        private HttpRequestMessage CurrentRequest
        {
            get { return (HttpRequestMessage)HttpContext.Current.Items["MS_HttpRequestMessage"]; }
        }

        public UserSessionManager(IBookLoverData data)
        {
            this.Data = data;
        }

        public void CreateUserSession(string username, string authToken)
        {
            var userId = this.Data.Users.All().First(u => u.UserName == username).Id;
            var userSession = new UserSession()
            {
                UserId = userId,
                AuthToken = authToken
            };

            this.Data.UserSessions.Add(userSession);
            userSession.ExpirationDateTime = DateTime.Now + Settings.Default.UserSessionTimeout;
            this.Data.SaveChanges();
        }

        public void InvalidateUserSession()
        {
            string authToken = GetCurrentAuthorizationToken();
            var currentUserId = GetCurrentUserId();
            var userSession = this.Data.UserSessions.All().FirstOrDefault(session => 
                    session.AuthToken == authToken && session.UserId == currentUserId);

            if (userSession != null)
            {
                this.Data.UserSessions.Remove(userSession);
                this.Data.SaveChanges();
            }
        }

        public bool RevalidateUserSession()
        {
            string authToken = GetCurrentAuthorizationToken();
            var currentUserId = GetCurrentUserId();
            var userSession = this.Data.UserSessions.All().FirstOrDefault(session =>
                session.AuthToken == authToken && session.UserId == currentUserId);

            if (userSession == null)
            {
                return false;
            }

            if (userSession.ExpirationDateTime < DateTime.Now)
            {
                return false;
            }

            userSession.ExpirationDateTime = DateTime.Now + Settings.Default.UserSessionTimeout;
            this.Data.SaveChanges();
            return true;
        }

        public void DeleteExpiredUserSessions()
        {
            this.Data.UserSessions.All().Where(session =>
                session.ExpirationDateTime < DateTime.Now).Delete();
        }

        private string GetCurrentAuthorizationToken()
        {
            string authToken = null;

            if (this.CurrentRequest.Headers.Authorization != null)
            {
                if (this.CurrentRequest.Headers.Authorization.Scheme == "Bearer")
                {
                    authToken = CurrentRequest.Headers.Authorization.Parameter;
                }
            }

            return authToken;
        }

        private string GetCurrentUserId()
        {
            if (HttpContext.Current.User == null)
            {
                return null;
            }

            string userId = HttpContext.Current.User.Identity.GetUserId();
            return userId;
        }
    }
}