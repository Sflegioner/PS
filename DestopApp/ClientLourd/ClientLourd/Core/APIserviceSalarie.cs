using System.Net.Http;
using System.Text.Json;
using ClientLourd.MVVM.Model;

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
        List<SalarieModel> sites = JsonSerializer.Deserialize<List<SalarieModel>>(json, new JsonSerializerOptions {PropertyNameCaseInsensitive = true });
        return sites ?? new List<SalarieModel>();
    }

}