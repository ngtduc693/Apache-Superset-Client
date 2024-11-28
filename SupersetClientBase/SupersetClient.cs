using SupersetClientBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SupersetClientBase
{
    internal class SupersetClient : ISupersetClient
    {
        private readonly HttpClient _httpClient;

        public SupersetClient(string baseUrl, string accessToken)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        public async Task<string> GetDashboardsAsync()
        {
            var response = await _httpClient.GetAsync("/api/v1/dashboard/");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetChartsAsync()
        {
            var response = await _httpClient.GetAsync("/api/v1/chart/");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> ExecuteSqlAsync(string query)
        {
            var content = new StringContent($"{{\"query\": \"{query}\"}}", Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/v1/sqllab/", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
