﻿using Microsoft.EntityFrameworkCore;

namespace _924_server.Entities
{
    [PrimaryKey(nameof(UserId), nameof(InterestId))]
    public class UserInterest
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int InterestId { get; set; }
        public Interest Interest { get; set; } = null!;
    }
}
