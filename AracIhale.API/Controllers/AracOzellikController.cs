using AracIhale.API.DTO;
using AracIhale.API.MyContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AracIhale.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AracOzellikController : ControllerBase
    {
        private readonly MyDBContext _context;

        public AracOzellikController(MyDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AracOzellik>>> GetAracOzellik()
        {
         
                return await _context.AracOzellik
            .Include(c => c.AracMarka) 
            .Include(c => c.AracModel) 
            .Select(c => new AracOzellik
            {
       AracMarka= c.AracMarka,
       AracModel=c.AracModel

            

            }).ToListAsync();
            }



        

        // GET: api/Arac/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AracOzellik>> GetAracOzelliks(int id)
        {
            var arac = await _context.AracOzellik.FindAsync(id);

            if (arac == null)
            {
                return NotFound();
            }

            return arac;
        }
    }
}
