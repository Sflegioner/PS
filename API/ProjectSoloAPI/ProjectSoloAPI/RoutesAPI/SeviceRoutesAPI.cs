using ProjectSoloAPI.Services;

namespace ProjectSoloAPI.RoutesAPI;

public static class SeviceRoutesAPI
{
    public static void MapSeviceRoutes(this WebApplication app)
    {
        app.MapGet("/api/services", () =>
        {
            var Services = CRUDEServiceMethods.GetAllServices(); 
            return Results.Json(Services); 
        });
        app.MapPost("/api/services/{ServiceName}", (string ServiceName) =>
        {
            CRUDEServiceMethods.PostService(ServiceName);
            return Results.Ok($"Service '{ServiceName}' added successfully.");
        });
        app.MapPut("/api/services/{ServiceNameOld}&{ServiceNameNew}", (string ServiceNameOld,string ServiceNameNew) =>
        {
            CRUDEServiceMethods.PutService(ServiceNameOld,ServiceNameNew);
            return Results.Ok($"Service '{ServiceNameOld}' updated to '{ServiceNameNew}' successfully.");
        });
        app.MapDelete("/api/services/{ServiceName}", (string ServiceName) =>
        {
            CRUDEServiceMethods.DeleteService(ServiceName);
            return Results.Ok($"Service '{ServiceName}' deleted successfully.");
        });
    }
}