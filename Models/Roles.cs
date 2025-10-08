namespace Prn232Project.Models
{
    public class Roles
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public IList<UserRoles>? UserRoles { get; set; }
    }
}
