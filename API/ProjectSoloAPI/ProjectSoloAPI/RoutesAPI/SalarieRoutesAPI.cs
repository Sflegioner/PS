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

        app.MapPost("/api/salarie/{Nom}/{Prenom}/{TelephoneFixe}/{TelephonePortable}/{Email}/{Service}/{Site}",
            (string Nom, string Prenom, string TelephoneFixe, string TelephonePortable, string Email, string Service, string Site) =>
            {
                return Results.Json(CRUDESalarieAPI.PostSalarie(Nom, Prenom, TelephoneFixe, TelephonePortable, Email, Service, Site));
            });

        app.MapPut("/api/salarie/{Email}/{Nom}/{Prenom}/{TelephoneFixe}/{TelephonePortable}/{Service}/{Site}",
            (string Email, string Nom, string Prenom, string TelephoneFixe, string TelephonePortable, string Service, string Site) =>
            {
                return CRUDESalarieAPI.UpdateSalarie(Email, Nom, Prenom, TelephoneFixe, TelephonePortable, Service, Site)
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