using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MechanicApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly DataContext _context;
        public CustomerController(DataContext context)
        {
                _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetSingleCustomer(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.ID == id);
            if (customer == null) 
            {
                return NotFound("No Customer Found");
            }
            return Ok(customer);
        }


        [HttpPost]
        public async Task<ActionResult<List<Customer>>> CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return Ok(await GetDbCustomers());
        }

        private async Task<List<Customer>> GetDbCustomers()
        {
            return await _context.Customers.ToListAsync();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(Customer customer, int id)
        {
            var dbCustomer = await _context.Customers.FirstOrDefaultAsync(sh => sh.ID == id);
            if (dbCustomer == null)
                return NotFound("No Customer Found");

            dbCustomer.FirstName = customer.FirstName;
            dbCustomer.LastName = customer.LastName;
            dbCustomer.Make = customer.Make;
            dbCustomer.Model = customer.Model;
            dbCustomer.Reg = customer.Reg;

            await _context.SaveChangesAsync();

            return Ok(await GetDbCustomers());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(int id)
        {
            var dbCustomer = await _context.Customers.FirstOrDefaultAsync(sh => sh.ID == id);
            if (dbCustomer == null)
                return NotFound("No Customer Found");

            _context.Customers.Remove(dbCustomer);
            await _context.SaveChangesAsync();

            return Ok(await GetDbCustomers());
        }
    }
}
