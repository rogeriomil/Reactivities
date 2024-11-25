using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;
        public ActivitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities() 
        {
            return await _context.Activities.ToListAsync();
        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id) 
        {
            var activity = await _context.Activities.FindAsync(id);

            if (activity == null) 
            {
                return NotFound();
            }

            return activity;
        }
        
    }
}