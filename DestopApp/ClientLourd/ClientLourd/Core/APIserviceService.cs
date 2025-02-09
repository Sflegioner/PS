using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ClientLourd.MVVM.Model;

namespace ClientLourd.Core
{
    public class APIserviceService
    {
        private static readonly string baseURL = "http://localhost:5052/";
        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<ServiceModel>> GetServicesAsync()
        { 
            HttpResponseMessage response = await client.GetAsync($"{baseURL}api/services");
            response.EnsureSuccessStatusCode(); 
            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ServiceModel>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<ServiceModel>();
        }

        public static async Task<bool> PostServiceAsync(string serviceName)
        {
            HttpResponseMessage response = await client.PostAsync(
                $"{baseURL}api/services/{serviceName}", null);
            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> DeleteServiceAsync(string serviceName)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{baseURL}api/services/{serviceName}");
            return response.IsSuccessStatusCode;
        }
    }
}