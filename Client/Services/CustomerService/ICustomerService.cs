namespace MechanicApp.Client.Services.CustomerService
{
    public interface ICustomerService
    {
        List <Customer> Customers { get; set; }

        Task GetCustomers();
        Task<Customer> GetSingleCustomer(int id);
        Task CreateCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(int id);
    }
}
