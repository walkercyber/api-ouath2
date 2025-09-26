using Microsoft.Extensions.Options;
using NordloSolar.WebApi.Config;

namespace NordloSolar.WebApi.Endpoints;

public static class OAuthEndpoints
{
    public static void MapOAuthEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/oauth/callback", async (
          HttpContext context,
          IOptions<OAuthOptions> oAuthOptions,
          IHttpClientFactory httpClientFactory) =>
        {
            var code = context.Request.Query["code"];
            if (string.IsNullOrEmpty(code))
                return Results.BadRequest("Missing authorization code");

            var options = oAuthOptions.Value;
            var client = httpClientFactory.CreateClient();

            var values = new Dictionary<string, string>
            {
                { "client_id", options.ClientId },
                { "client_secret", options.ClientSecret },
                { "grant_type", "authorization_code" },
                { "code", code! },
                { "redirect_uri", options.RedirectUri }
            };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(options.TokenEndpoint, content);

            if (!response.IsSuccessStatusCode)
                return Results.Problem("Token endpoint error", statusCode: (int)response.StatusCode);

            var tokenResponse = await response.Content.ReadAsStringAsync();
            return Results.Ok(tokenResponse);
        });
    }
}
