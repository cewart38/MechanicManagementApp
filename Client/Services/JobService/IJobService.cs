namespace MechanicApp.Client.Services.JobService
{
    public interface IJobService
    {
        List <Job> Jobs { get; set;  }
        Task<Job> GetSingleJob(int id);
        Task GetJobs();
        Task GetCustomerJobs(int id);
        Task CreateJob(Job job);
        Task UpdateJob(Job job);
        Task DeleteJob(int id);
    }
}
