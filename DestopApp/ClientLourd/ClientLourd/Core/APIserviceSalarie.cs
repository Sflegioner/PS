using System.Net.Http;
using System.Text.Json;
using System.Linq;
using System.Text;
using ClientLourd.MVVM.Model;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ClientLourd.Core;

public class APIserviceSalarie
{
    private static string baseURL = "http://localhost:5052/";
    private static HttpClient client = new HttpClient();

    public static async Task<List<SalarieModel>> GetSalarieAsync()
    { 
        HttpResponseMessage response = await client.GetAsync($"{baseURL}api/salarie");
        response.EnsureSuccessStatusCode(); 
        string json = await response.Content.ReadAsStringAsync();
        List<SalarieModel> salaries = JsonSerializer.Deserialize<List<SalarieModel>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<SalarieModel>();

        var sites = await APIserviceSite.GetSitesAsync();
        var services = await APIserviceService.GetServicesAsync();

        foreach (var salarie in salaries)
        {
            var site = sites.FirstOrDefault(s => s.Id == salarie.siteId);
            salarie.siteName = site != null ? site.SiteName : "NaN";

            var service = services.FirstOrDefault(s => s.Id == salarie.serviceId);
            salarie.serviceName = service != null ? service.ServiceName : "NaN";
        }

        return salaries;
    }

    public static async Task<bool> PostSalarieAsync(SalarieModel salarie)
    {
        string url = $"{baseURL}api/salarie/{salarie.Nom}/{salarie.Prenom}/{salarie.TelephoneFixe}/{salarie.TelephonePortable}/{salarie.Email}/{salarie.serviceId}/{salarie.siteId}";
    
        HttpResponseMessage response = await client.PostAsync(url, null);

        return response.IsSuccessStatusCode;
    }

    public static async Task<bool> DeleteSalarieAsync(SalarieModel salarie)
    {
        string url = $"{baseURL}api/salarie/{salarie.Email}";
        HttpResponseMessage response = await client.DeleteAsync(url);
        return response.IsSuccessStatusCode;
    }
    
    public static async Task<bool> PutSalarieAsync(SalarieModel salarie)
    {
        string url = $"{baseURL}api/salarie/{salarie.Id}"; 
        var json = JsonConvert.SerializeObject(new
        {
            salarie.Id,
            salarie.Nom,
            salarie.Prenom,
            salarie.TelephoneFixe,
            salarie.TelephonePortable,
            salarie.Email,
            salarie.serviceId,
            salarie.siteId
        });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PutAsync(url, content);
        if (!response.IsSuccessStatusCode)
        {
            string errorMessage = await response.Content.ReadAsStringAsync();
            return false;
        }
        return true;
    }


}