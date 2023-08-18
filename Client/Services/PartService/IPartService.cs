namespace MechanicApp.Client.Services.PartService
{
    public interface IPartService
    {
        List<Part> Parts { get; set; }
        Task<Part> GetSinglePart(int id);
        Task GetParts();
        Task GetJobParts(int id);
        Task CreatePart(Part part, int JobId);
        Task UpdatePart(Part part);
        Task DeletePart(int id);
    }
}
