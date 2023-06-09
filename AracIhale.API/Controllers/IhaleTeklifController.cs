﻿using AracIhale.API.DTO;
using AracIhale.API.MyContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AracIhale.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IhaleTeklifController : ControllerBase
    {
        private readonly MyDBContext _context;

        public IhaleTeklifController(MyDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<IhaleTeklif>> GetIhaleTeklif()
        {
            return await _context.IhaleTeklif
        .Include(c => c.IhaleListesi) // IhaleListesi verilerini dahil eder
        .Include(c => c.Kullanici) // Kullanici verilerini dahil eder
        .Select(c => new IhaleTeklif
        {
            IhaleID = c.IhaleID,
            KullaniciID = c.KullaniciID,
            TeklifFiyati = c.TeklifFiyati,
            TeklifTarihi = c.TeklifTarihi,
            TeklifID = c.TeklifID,

            IhaleListesi = c.IhaleListesi, // Eklenen
            Kullanici = c.Kullanici

        }).ToListAsync();
        }


		[HttpGet("{id}")]
        public ActionResult<IhaleTeklif> GetIhaleIhale(int id)
        {
            var ihale = _context.IhaleTeklif.Find(id);
            if (ihale == null)
            {
                return NotFound();
            }
            return ihale;
        }

        [HttpPost]
        public async Task<ActionResult<IhaleTeklif>> CreateIhaleTeklif(IhaleTeklif ihale)
        {
            //ihale.TeklifTarihi = DateTime.UtcNow;  // TeklifTarihi'ni otomatik olarak şu anki tarih ve saate ayarlar

            _context.Add(ihale);

            await _context.SaveChangesAsync();

            return Ok(ihale);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIhaleTeklif(int id, IhaleTeklif ihale)
        {
            if (id != ihale.IhaleID)
            {
                return BadRequest("Gecersiz Ihale ID");
            }

            _context.Entry(ihale).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIhaleTeklif(int id)
        {
            var ihale = await _context.IhaleTeklif.FindAsync(id);
            if (ihale == null)
            {
                return NotFound("Gecersiz Ihale ID");
            }

            _context.IhaleTeklif.Remove(ihale);
            await _context.SaveChangesAsync();

            return Ok();
        }



		[HttpGet("{id}/onayla")]
		public async Task<IActionResult> Onayla(int id)
		{
			var teklif = await _context.IhaleTeklif
		.Include(t => t.IhaleListesi)
		.Include(t => t.Kullanici)
		.FirstOrDefaultAsync(t => t.TeklifID == id);
			if (teklif == null)
			{
				return NotFound("Geçersiz Teklif ID");
			}

			var ihaleID = teklif.IhaleID;

			// IhaleID'ye ait diğer teklifleri silme işlemi
			var digerTeklifler = await _context.IhaleTeklif
				.Where(t => t.IhaleID == ihaleID && t.TeklifID != id)
				.ToListAsync();

			_context.IhaleTeklif.RemoveRange(digerTeklifler);

            var onaylananTeklif = new OnaylananTeklif
            {

                //TeklifID = teklif.TeklifID,
                KullaniciID = teklif.KullaniciID,
                IhaleID = teklif.IhaleID,
                OnaylanmaTarihi = DateTime.UtcNow,
				TeklifFiyati=teklif.TeklifFiyati,

			};

			_context.OnaylananTeklif.Add(onaylananTeklif);
			_context.IhaleTeklif.Remove(teklif); /// BireyselAracTeklif tablosundan silme işlemi
			await _context.SaveChangesAsync();


			return Ok();
		}
	}
}