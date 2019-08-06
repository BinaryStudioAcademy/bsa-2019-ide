using IDE.DAL.Entities;

namespace IDE.BLL.Helpers
{
    public static class UserExtention
    {
        public static string GetUserName(this User user)
        {
            return $"{user.FirstName} {user.LastName}";
        }
    }
}
