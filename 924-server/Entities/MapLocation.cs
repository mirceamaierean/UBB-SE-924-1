namespace _924_server.Entities
{
    public class MapLocation
    {
        public int Id {  get; set; }
        public int XCoord { get; set; } = 0;
        public int YCoord { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User User { get; set; } = null!;

    }
}
