namespace BookLover.Web.UserSessionUtils
{
    public interface IUserSessionManager
    {
        void CreateUserSession(string username, string authToken);

        void InvalidateUserSession();

        bool RevalidateUserSession();

        void DeleteExpiredUserSessions();
    }
}