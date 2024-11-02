namespace Project.WebAPI.Models
{
    public class UserLogInfo
    {
        public int UserId { get; set; }

        public DateTime AuthenticationTime { get; set; }

        public UserLogInfo(int userId)
        {
            UserId = userId;
            AuthenticationTime = DateTime.Now;
        }
    }
}
