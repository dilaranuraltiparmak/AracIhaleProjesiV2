using AracIhale.API.DTO;
using AracIhale.API.MyContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AracIhale.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class IhaleTeklifOnayController : ControllerBase
	{
		private readonly MyDBContext _context;

		public IhaleTeklifOnayController(MyDBContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<List<OnaylananTeklif>> GetIhaleOnay()
		{
			return await _context.OnaylananTeklif.Select(c => new OnaylananTeklif
			{
				IhaleID = c.IhaleID,

				IhaleTeklif=c.IhaleTeklif,
				Kullanici=c.Kullanici,
				TeklifFiyati=c.TeklifFiyati,
				OnaylanmaTarihi=c.OnaylanmaTarihi,	
				IhaleListesi=c.IhaleListesi




			}).ToListAsync();

		}
	}
}
