using MechanicApp.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace MechanicApp.Client.Services.JobService
{
    public class JobService : IJobService
    {

        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public JobService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Job> Jobs { get; set; } = new List<Job>();

        public async Task GetJobs()
        {
            var result = await _http.GetFromJsonAsync<List<Job>>("api/job");
            if (result != null)
                Jobs = result;
        }

        public async Task GetCustomerJobs(int id)
        {
            var result = await _http.GetFromJsonAsync<List<Job>>($"api/job/{id}");
            if (result != null)
                Jobs = result;
        }

        public async Task<Job> GetSingleJob(int id)
        {
            var result = await _http.GetFromJsonAsync<Job>($"api/job/singlejob/{id}");
            if (result != null)
                return result;
            throw new Exception("Job not found");
        }

        private async Task SetJobs(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Job>>();
            if (Jobs != null)
            {
                Jobs = response;
                _navigationManager.NavigateTo("customers");
            }
            else
            {
                throw new Exception("Job Not Found");
            }
        }

        public async Task CreateJob(Job job)
        {
            var result = await _http.PostAsJsonAsync("api/job", job);
            await SetJobs(result);
        }

        public async Task UpdateJob(Job job)
        {
            var result = await _http.PutAsJsonAsync($"api/job/{job.ID}", job);
            await SetJobs(result);
        }

        public async Task DeleteJob(int id)
        {
            var result = await _http.DeleteAsync($"api/job/{id}");
            await SetJobs(result);
        }
    }
}
