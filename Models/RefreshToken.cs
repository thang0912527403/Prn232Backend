namespace Prn232Project.Models
{
    public class RefreshToken
    {
        public int Id { get; set; } 
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
        public bool IsRevoked { get; set; } = false;
        public DateTime? RevokedAt { get; set; }
        public string? RevokedReason { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
