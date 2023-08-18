using Microsoft.AspNetCore.Mvc;

namespace MechanicApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        public readonly DataContext _context;

        public PartController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Part>>> GetParts()
        {
            var parts = await _context.Parts.ToListAsync();
            return Ok(parts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Part>>> GetJobParts(int id)
        {
            var parts = await _context.Parts.Where(x => x.JobId == id).ToListAsync();
            if (parts == null)
            {
                return NotFound("No Parts Found");
            }
            return Ok(parts);
        }

        [HttpGet("/singlepart/{id}")]
        public async Task<ActionResult<Part>> GetSinglePart(int id)
        {
            var part = await _context.Parts.FirstOrDefaultAsync(x => x.ID == id);
            if (part == null)
            {
                return NotFound("No Part Found");
            }
            return Ok(part);
        }

        [HttpPost]
        public async Task<ActionResult<List<Part>>> CreatePart(Part part)
        {
            _context.Parts.Add(part);
            await _context.SaveChangesAsync();

            return Ok(await GetDbParts());
        }

        private async Task<List<Part>> GetDbParts()
        {
            return await _context.Parts.ToListAsync();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<Part>>> UpdatePart(Part part, int id)
        {
            var dbPart = await _context.Parts.FirstOrDefaultAsync(sh => sh.ID == id);
            if (dbPart == null)
                return NotFound("No Part Found");

            dbPart.Name = part.Name;
            dbPart.Cost = part.Cost;

            await _context.SaveChangesAsync();

            return Ok(await GetDbParts());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Part>>> DeletePart(int id)
        {
            var dbPart = await _context.Parts.FirstOrDefaultAsync(sh => sh.ID == id);
            if (dbPart == null)
                return NotFound("No Part Found");

            _context.Parts.Remove(dbPart);
            await _context.SaveChangesAsync();

            return Ok(await GetDbParts());
        }
    }
}
