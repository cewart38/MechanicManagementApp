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
                 new Job { ID = 1, CustomerId = 1, StartDate = new DateTime(2023, 5, 15), JobTitle = "MOT Check", IsCompleted = true, FinishDate = new DateTime (2023, 5, 30), TotalHours = 15 },
                 new Job { ID = 2, CustomerId = 2, StartDate = new DateTime(2023, 4, 22), JobTitle = "Service" });

            modelBuilder.Entity<Part>().HasData(
                 new Part { ID = 1, JobId = 1, Name = "Brake Pads", Cost = 30.50 },
                 new Part { ID = 2, JobId = 1, Name = "Brake Disc", Cost = 60.30 },
                 new Part { ID = 3, JobId = 1, Name = "Brake Fluid", Cost = 10.00 });
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Part> Parts { get; set; }
    }
}
