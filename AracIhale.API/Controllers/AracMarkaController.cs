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
    public class AracMarkaController : ControllerBase
    {
        private readonly MyDBContext _context;

        public AracMarkaController(MyDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<AracMarka>>> GetAracMarkalar()
        {
            return await _context.AracMarka
                .Include(c => c.AracModels)
                .Select(c => new AracMarka
                {
                    AracMarkaID = c.AracMarkaID,
                    MarkaAdi = c.MarkaAdi
                })
                .ToListAsync();
        }

  
    }
}
