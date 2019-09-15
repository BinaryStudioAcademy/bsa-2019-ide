using IDE.DAL.Entities;

namespace IDE.BLL.Helpers
{
    public static class UserExtension
    {
        public static string GetUserName(this User user)
        {
            return $"{user.FirstName} {user.LastName}";
        }
    }
}
