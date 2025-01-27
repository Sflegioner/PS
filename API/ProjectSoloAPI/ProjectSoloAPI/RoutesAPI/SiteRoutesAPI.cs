using Microsoft.AspNetCore.Http;
using ProjectSoloAPI.Services; //Not working with Swagger, shit :(( 
namespace ProjectSoloAPI.RoutesAPI;

public static class SiteRoutesAPI
{
    public static void MapSiteRoutes(this WebApplication app)
    {
        app.MapGet("/api/sites", () =>
        {
            var sites = CRUDESiteMethods.GetAllSite(); 
            return Results.Json(sites); 
        });
        app.MapPost("/api/sites/{SiteName}", (string SiteName) =>
        {
            CRUDESiteMethods.PostSite(SiteName);
            return Results.Ok($"Site '{SiteName}' added successfully.");
        });
        app.MapPut("/api/sites/{SiteNameOld}&{SiteNameNew}", (string SiteNameOld,string SiteNameNew) =>
        {
            CRUDESiteMethods.PutSite(SiteNameOld,SiteNameNew);
            return Results.Ok($"Site '{SiteNameOld}' updated to '{SiteNameNew}' successfully.");
        });
        app.MapDelete("/api/sites/{SiteName}", (string SiteName) =>
        {
            CRUDESiteMethods.DeleteSite(SiteName);
            return Results.Ok($"Site '{SiteName}' deleted successfully.");
        });
    }
}

