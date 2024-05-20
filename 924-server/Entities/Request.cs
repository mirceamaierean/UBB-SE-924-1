namespace _924_server.Entities
{
    public class Request
    {
        public int Id { get; set; }

        public User Sender { get; set; } = null!;
        public int SenderId { get; set; }
        public User Receiver { get; set; } = null!;
        public int ReceiverId { get; set; }
    }
}
