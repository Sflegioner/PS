using ProjectSoloAPI.Models;
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

        app.MapPut("/api/salarie/{ID}", async (string ID, HttpContext context) =>
        {
            try
            {
                var salarie = await context.Request.ReadFromJsonAsync<SalarieModel>();
                if (salarie == null)
                {
                    return Results.BadRequest("Invalid JSON body.");
                }

                bool isUpdated = CRUDESalarieAPI.UpdateSalarie(ID, salarie.Nom, salarie.Prenom, salarie.Email,
                    salarie.TelephoneFixe, salarie.TelephonePortable,
                    salarie.ServiceId, salarie.SiteId);

                return isUpdated
                    ? Results.Ok($"Salarie {salarie.Email} updated successfully.")
                    : Results.NotFound($"Salarie with ID {ID} not found.");
            }
            catch (Exception ex)
            {
                return Results.Problem($"Internal Server Error: {ex.Message}");
            }
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