﻿using AracIhale.API.DTO;
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
    public class IhaleController : ControllerBase
    {
        private readonly MyDBContext _context;

        public IhaleController(MyDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<IhaleListesi>> GetIhale()
        {
            return await _context.IhaleListesi.Select(c => new IhaleListesi
            {
                IhaleID = c.IhaleID,
                IhaleAdi = c.IhaleAdi ?? "",

                BireyselKurumsalID = c.BireyselKurumsalID,
                KurumsalSirketAdi = c.KurumsalSirketAdi ?? "",

                IhaleStatuID = c.IhaleStatuID,
                IhaleBaslangicTarihi = c.IhaleBaslangicTarihi,
                IhaleBaslangicSaati = c.IhaleBaslangicSaati,
                IhaleBitisTarihi = c.IhaleBitisTarihi,
                IhaleBitisSaati = c.IhaleBitisSaati,

                AracID = c.AracID,
                IhaleBaslangicFiyati = c.IhaleBaslangicFiyati,
                MinimumAlimFiyati = c.MinimumAlimFiyati,

                AracOzellikID=c.AracOzellikID,
                AracOzellik=c.AracOzellik,
                Araclar=c.Araclar,
                MarkaAdi =c.MarkaAdi,
                ModelAdi = c.ModelAdi


            }).ToListAsync();
        }


        [HttpGet("{id}")]
        public ActionResult<IhaleListesi> GetIhale(int id)
        {
            var ihale = _context.IhaleListesi.Find(id);
            if (ihale == null)
            {
                return NotFound();
            }
            return ihale;
        }

        [HttpPost]
        public async Task<ActionResult<List<IhaleListesi>>> CreateIhale(List<IhaleListesi> ihaleler)
        {
            foreach (var ihale in ihaleler)
            {
                

                _context.Add(ihale);
            }

            await _context.SaveChangesAsync();

            return Ok(ihaleler);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIhale(int id, IhaleListesi ihale)
        {
            if (id != ihale.IhaleID)
            {
                return BadRequest("Invalid Ihale ID");
            }

            // AracID sütunu burada güncellenmeli veya kontrol edilmeli (eğer kullanılmıyorsa).

            _context.Entry(ihale).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIhale(int id)
        {
            var ihale = await _context.IhaleListesi.FindAsync(id);
            var ihale2 = await _context.OnaylananTeklif.FindAsync(id);
            if (ihale == null || ihale2==null)
            {
                return NotFound("Invalid Ihale ID");
            }

            _context.IhaleListesi.Remove(ihale);
            _context.OnaylananTeklif.Remove(ihale2);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
