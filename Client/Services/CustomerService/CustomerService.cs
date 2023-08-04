using MechanicApp.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace MechanicApp.Client.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public CustomerService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Customer> Customers { get; set; } = new List<Customer>();

        public async Task CreateCustomer(Customer customer)
        {
            var result = await _http.PostAsJsonAsync("api/customer", customer);
            await SetCustomers(result);
        }

        private async Task SetCustomers(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Customer>>();
            if (Customers  != null)
            {
                Customers = response;
                _navigationManager.NavigateTo("customers");
            }
            else
            {
                throw new Exception("Customer Not Found");
            }
        }

        public async Task DeleteCustomer(int id)
        {
            var result = await _http.DeleteAsync($"api/customer/{id}");
            await SetCustomers(result);
        }

        public async Task GetCustomers()
        {
            var result = await _http.GetFromJsonAsync<List<Customer>>("api/customer");
            if (result != null)
                Customers = result;
        }

        public async Task<Customer> GetSingleCustomer(int id)
        {
            var result = await _http.GetFromJsonAsync<Customer>($"api/customer/{id}");
            if (result != null)
                return result;
            throw new Exception("Customer not found");
        }


        public async Task UpdateCustomer(Customer customer)
        {
            var result = await _http.PutAsJsonAsync($"api/customer/{customer.ID}", customer);
            await SetCustomers(result);
        }
    }
}
