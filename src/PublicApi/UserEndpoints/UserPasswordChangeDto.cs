namespace Microsoft.eShopWeb.PublicApi.UserEndpoints;

public class UserPasswordChangeDTO
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}
