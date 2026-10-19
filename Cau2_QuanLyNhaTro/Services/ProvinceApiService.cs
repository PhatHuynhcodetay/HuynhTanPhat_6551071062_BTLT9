using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cau2_QuanLyNhaTro.Services
{
    public class AdministrativeUnit
    {
        public int code { get; set; }
        public string name { get; set; } = string.Empty;
        public List<AdministrativeUnit>? wards { get; set; }

        public override string ToString() => name;
    }

    public static class ProvinceApiService
    {
        // 1 HttpClient dùng chung (singleton/static), Timeout = 10 giây
        private static readonly HttpClient _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

        public static async Task<List<AdministrativeUnit>> GetProvincesAsync()
        {
            // Endpoint chính thức theo đề bài: https://provinces.open-api.vn/api/v2/
            string url = "https://provinces.open-api.vn/api/v2/";
            string json = await _httpClient.GetStringAsync(url);
            var list = JsonSerializer.Deserialize<List<AdministrativeUnit>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return list ?? new List<AdministrativeUnit>();
        }

        public static async Task<List<AdministrativeUnit>> GetWardsAsync(int provinceCode)
        {
            // Endpoint chính thức: https://provinces.open-api.vn/api/v2/p/{code}?depth=2
            string url = $"https://provinces.open-api.vn/api/v2/p/{provinceCode}?depth=2";
            string json = await _httpClient.GetStringAsync(url);
            var doc = JsonSerializer.Deserialize<AdministrativeUnit>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return doc?.wards ?? new List<AdministrativeUnit>();
        }
    }
}
