using Microsoft.EntityFrameworkCore;

namespace _924_server.Entities
{
    [PrimaryKey(nameof(UserId), nameof(InterestId))]
    public class UserInterest
    {
        public int UserId { get; set; }
        public int InterestId { get; set; }
    }
}
