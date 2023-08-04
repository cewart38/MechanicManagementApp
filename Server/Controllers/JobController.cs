using Microsoft.AspNetCore.Mvc;

namespace MechanicApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        public readonly DataContext _context;

        public JobController(DataContext context) 
        { 
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Job>>> GetJobs()
        {
            var jobs = await _context.Jobs.ToListAsync();
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Job>>> GetCustomerJobs(int id)
        {
            var job = await _context.Jobs.Where(x => x.ID == id).ToListAsync();
            if (job == null)
            {
                return NotFound("No Jobs Found");
            }
            return Ok(job);
        }

        [HttpGet("/singlejob/{id}")]
        public async Task<ActionResult<Job>> GetSingleJob(int id)
        {
            var job = await _context.Customers.FirstOrDefaultAsync(x => x.ID == id);
            if (job == null)
            {
                return NotFound("No Job Found");
            }
            return Ok(job);
        }

        [HttpPost]
        public async Task<ActionResult<List<Job>>> CreateJob(Job job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();

            return Ok(await GetDbJobs());
        }

        private async Task<List<Job>> GetDbJobs()
        {
            return await _context.Jobs.ToListAsync();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<Job>>> UpdateJob(Job job, int id)
        {
            var dbJob = await _context.Jobs.FirstOrDefaultAsync(sh => sh.ID == id);
            if (dbJob == null)
                return NotFound("No Job Found");

            dbJob.JobTitle = job.JobTitle;
            dbJob.StartDate = job.StartDate;

            await _context.SaveChangesAsync();

            return Ok(await GetDbJobs());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Job>>> DeleteJob(int id)
        {
            var dbJob = await _context.Jobs.FirstOrDefaultAsync(sh => sh.ID == id);
            if (dbJob == null)
                return NotFound("No Job Found");

            _context.Jobs.Remove(dbJob);
            await _context.SaveChangesAsync();

            return Ok(await GetDbJobs());
        }
    }
}
