namespace Prn232Project.Models
{
    public class Users
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? SecurityStamp { get; set; }=Guid.NewGuid().ToString();
        public string?   ConcurrencyStamp { get; set; }=Guid.NewGuid().ToString();
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }  
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public DateOnly? BirthDate { get; set; }
        public  IList<UserRoles>? UserRoles { get; set; }
        public IList<RefreshToken>? RefreshTokens { get; set; }
    }
}
