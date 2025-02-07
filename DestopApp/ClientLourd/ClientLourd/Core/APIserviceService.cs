using System.Net.Http;
using System.Text.Json;
using ClientLourd.MVVM.Model;

namespace ClientLourd.Core;

public class APIserviceService
{
    private static string baseURL = "http://localhost:5052/";
    private static HttpClient client = new HttpClient();

    public static async Task<List<ServiceModel>> GetServicesAsync()
    { 
        HttpResponseMessage response = await client.GetAsync($"{baseURL}api/services");
        response.EnsureSuccessStatusCode(); 
        string json = await response.Content.ReadAsStringAsync();
        List<ServiceModel> services = JsonSerializer.Deserialize<List<ServiceModel>>(json, new JsonSerializerOptions {PropertyNameCaseInsensitive = true });
        return services ?? new List<ServiceModel>();
    }
}