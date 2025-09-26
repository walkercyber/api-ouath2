namespace NordloSolar.WebApi.Config;

public class OAuthOptions
{
    public required string ClientId { get; set; }
    public required string ClientSecret { get; set; }
    public required string RedirectUri { get; set; }
    public required string TokenEndpoint { get; set; }
}
