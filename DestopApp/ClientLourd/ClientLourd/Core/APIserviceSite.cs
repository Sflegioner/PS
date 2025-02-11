using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ClientLourd.MVVM.Model;

namespace ClientLourd.Core
{
    public static class APIserviceSite
    {
        private static readonly string baseURL = "http://localhost:5052/";
        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<SiteModel>> GetSitesAsync()
        { 
            HttpResponseMessage response = await client.GetAsync($"{baseURL}api/sites");
            response.EnsureSuccessStatusCode(); 
            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<SiteModel>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<SiteModel>();
        }

        public static async Task<bool> PostSiteAsync(string siteName)
        {
            HttpResponseMessage response = await client.PostAsync(
                $"{baseURL}api/sites/{siteName}", null);
            return response.IsSuccessStatusCode;
        }
        
        public static async Task<bool> DeleteSiteAsync(string siteName)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{baseURL}api/sites/{siteName}");
            return response.IsSuccessStatusCode;
        }
        
        public static async Task<bool> UpdateSiteAsync(string siteNameOld, string siteNameNew)
        {
            HttpResponseMessage response = await client.PutAsync(
                $"{baseURL}api/sites/{siteNameOld}&{siteNameNew}", null);
            return response.IsSuccessStatusCode;
        }
    }
}