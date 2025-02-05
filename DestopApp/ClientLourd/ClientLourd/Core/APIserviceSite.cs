using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ClientLourd.MVVM.Model;

namespace ClientLourd.Core
{
    public static class APIserviceSite
    {
        private static string baseURL = "http://localhost:5052/";
        private static HttpClient client = new HttpClient();

        public static async Task<List<SiteModel>> GetSitesAsync()
        { 
            HttpResponseMessage response = await client.GetAsync($"{baseURL}api/sites");
            response.EnsureSuccessStatusCode(); 
            string json = await response.Content.ReadAsStringAsync();
            List<SiteModel> sites = JsonSerializer.Deserialize<List<SiteModel>>(json, new JsonSerializerOptions {PropertyNameCaseInsensitive = true });
            return sites ?? new List<SiteModel>();
            }
    }
}