namespace Microsoft.eShopWeb.PublicApi.UserEndpoints;

public class UserHashPassDTO
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
}
