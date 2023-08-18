namespace MechanicApp.Client.Services.PartService
{
    public interface IJobService
    {
        List<Job> Jobs { get; set; }
        Task<Job> GetSingleJob(int id);
        Task GetJobs();
        Task GetCustomerJobs(int id);
        Task CreateJob(Job job, int CustId);
        Task UpdateJob(Job job);
        Task DeleteJob(int id);
    }
}
