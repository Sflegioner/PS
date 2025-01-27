using Microsoft.AspNetCore.Http;
namespace ProjectSoloAPI.RoutesAPI;

public static class SiteRoutesAPI
{
    public static void MapSiteRoutes(this WebApplication app)
    {
        app.MapGet("/api/sites", () =>
        {
            return Results.Json(new[]
            {
                new { id = 1, name = "Example Service" }
            });
        });
    }
}

