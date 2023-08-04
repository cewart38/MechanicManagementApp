namespace MechanicApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
               
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                 new Customer { ID = 1, FirstName = "Joe", LastName = "Bloggs", Make = "VW", Model = "Golf", Reg = "BFZ 1920" },
                 new Customer { ID = 2, FirstName = "Mark", LastName = "Hunt", Make = "Seat", Model = "Leon", Reg = "HJI 1903" });

            modelBuilder.Entity<Job>().HasData(
                 new Job { ID = 1, CustomerId = 1, StartDate = new DateTime(2023, 5, 15), JobTitle = "MOT Check" },
                 new Job { ID = 2, CustomerId = 2, StartDate = new DateTime(2023, 4, 22), JobTitle = "Service" });
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}
