
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
    public class AracModelController : ControllerBase
    {
        private readonly MyDBContext _context;

        public AracModelController(MyDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<AracModel>>> GetAracModelleri()
        {
            return await _context.AracModel
                .Include(m => m.AracMarka)
                .Select(m => new AracModel
                {
                    AracModelID = m.AracModelID,
                    ModelAdi = m.ModelAdi,
                    AracMarkaID = m.AracMarkaID,
                    AracMarka = m.AracMarka
                })
                .ToListAsync();
        }
    }
}
