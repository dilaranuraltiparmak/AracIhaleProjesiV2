using AracIhale.API.DTO;
using AracIhale.API.MyContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AracIhale.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GirisController : ControllerBase
    {
        private readonly MyDBContext _context;

        public GirisController(MyDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Giris(Kullanici kullanici)
        {
            var user = await _context.Kullanici.FirstOrDefaultAsync(u => u.KullaniciAdi == kullanici.KullaniciAdi && u.Sifre == kullanici.Sifre );

            if (user == null)
            {
                return Unauthorized(); 
            }

            return Ok(user);
        }

    }
}

