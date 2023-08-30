using MechanicApp.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace MechanicApp.Client.Services.PartService
{
    public class PartService : IPartService
    {

        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public PartService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Part> Parts { get; set; } = new List<Part>();

        public async Task GetParts()
        {
            var result = await _http.GetFromJsonAsync<List<Part>>("api/part");
            if (result != null)
                Parts = result;
        }

        public async Task<List<Part>> GetPartsList()
        {
            var result = await _http.GetFromJsonAsync<List<Part>>("api/part");
            return result;
        }

        public async Task GetJobParts(int id)
        {
            var result = await _http.GetFromJsonAsync<List<Part>>($"api/part/{id}");
            if (result != null)
                Parts = result;
        }

        public async Task<Part> GetSinglePart(int id)
        {
            var result = await _http.GetFromJsonAsync<Part>($"singlepart/{id}");
            if (result != null)
                return result;
            throw new Exception("Part not found");
        }

        private async Task SetParts(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Part>>();
            if (Parts != null)
            {
                Parts = response;
                _navigationManager.NavigateTo("customers");
            }
            else
            {
                throw new Exception("Job Not Found");
            }
        }

        public async Task CreatePart(Part part, int JobId)
        {
            part.JobId = JobId;
            var result = await _http.PostAsJsonAsync("api/part", part);
            var response = await result.Content.ReadFromJsonAsync<List<Part>>();
            if (Parts != null)
            {
                Parts = response;
            }
            else
            {
                throw new Exception("Job Not Found");
            }
        }

        public async Task UpdatePart(Part part)
        {
            var result = await _http.PutAsJsonAsync($"api/part/{part.ID}", part);
            await SetParts(result);
        }

        public async Task DeletePart(int id)
        {
            var result = await _http.DeleteAsync($"api/part/{id}");
            var response = await result.Content.ReadFromJsonAsync<List<Part>>();
            if (Parts != null)
            {
                Parts = response;
            }
            else
            {
                throw new Exception("Job Not Found");
            }
        }
    }
}
