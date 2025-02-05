namespace Application.Contracts.Users;

public record CurrentUser(string UserId, string Email, string FullName, IEnumerable<string> roles)
{
    public bool IsAuthenticated => !string.IsNullOrWhiteSpace(UserId);
    public bool IsAdmin => roles.Contains("Admin");
    public bool IsCustomer => roles.Contains("Customer");
    public bool IsInRole(string role) => roles.Contains(role);
}
