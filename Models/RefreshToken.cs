namespace Prn232Project.Models
{
    public class RefreshToken
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
        public bool IsRevoked { get; set; } = false;
        public DateTime? RevokedAt { get; set; }
        public string? RevokedReason { get; set; }
        public Guid UserId { get; set; }
        public Users User { get; set; }
    }
}
