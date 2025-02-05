using ProjectSoloAPI.Services;

namespace ProjectSoloAPI.RoutesAPI;

public static class SalarieRoutesAPI
{
    public static void MapSalarieRoutes(this WebApplication app)
    {
        app.MapGet("/api/salarie", () =>
        {
            var salarie = CRUDESalarieAPI.GetAllServices();
            return Results.Json(salarie);
        });

        app.MapPost("/api/salarie/{Nom}/{Prenom}/{TelephoneFixe}/{TelephonePortable}/{Email}/{ServiceId}/{SiteId}",
            (string Nom, string Prenom, string TelephoneFixe, string TelephonePortable, string Email, string ServiceId, string SiteId) =>
            {
                return Results.Json(CRUDESalarieAPI.PostSalarie(Nom, Prenom, TelephoneFixe, TelephonePortable, Email, ServiceId, SiteId));
            });

        app.MapPut("/api/salarie/{ID}/{Email}/{Nom}/{Prenom}/{TelephoneFixe}/{TelephonePortable}/{ServiceId}/{Site}",
            (string ID, string Email, string Nom, string Prenom, string TelephoneFixe, string TelephonePortable, string ServiceId, string SiteId) =>
            {
                return CRUDESalarieAPI.UpdateSalarie(ID,Nom, Prenom, Email, TelephoneFixe, TelephonePortable,ServiceId, SiteId)
                    ? Results.Ok($"Salarie {Email} updated successfully.")
                    : Results.NotFound($"Salarie {Email} not found.");
            });

        app.MapDelete("/api/salarie/{Email}",
            (string Email) =>
            {
                return CRUDESalarieAPI.DeleteSalarie(Email)
                    ? Results.Ok($"Salarie {Email} deleted successfully.")
                    : Results.NotFound($"Salarie {Email} not found.");
            });
    }
}