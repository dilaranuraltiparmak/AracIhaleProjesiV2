using AracIhale.CoreMVC.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using X.PagedList;

namespace AracIhale.CoreMVC.Controllers
{
    public class IhaleController : Controller
    {

        private readonly APIGateway _apiGateway;

        public IhaleController(APIGateway apiGateway)
        {
            _apiGateway = apiGateway;
        }
        [Authorize]
        public async Task<IActionResult> AracListeleme(int page=1)
        {
            var ihaleler = await _apiGateway.ListIhale();
            return View(ihaleler.ToPagedList(page,6));
        }

        public IActionResult AracIhaleOlusturma()
        {
            return View();
        }

        public IActionResult AracIhaleTeklifVerme()
        {
            return View();
        }
		[Authorize]
		public async Task<IActionResult> IhaleListeleme()
        {
            var ihaleler = await _apiGateway.ListIhale();
            return View(ihaleler);
        }

        [HttpGet]
        public IActionResult Create()
        {
            IhaleListesi ihaleler = new IhaleListesi();
            return View(ihaleler);
        }
        [HttpPost]
        public IActionResult Create(IhaleListesi ihale)
        {
            _apiGateway.CreateIhale(ihale);
            return RedirectToAction("AracListeleme");

        }
		[Authorize]
		public async Task<IActionResult> Delete(int id)
        {
            var result = await _apiGateway.DeleteIhale(id);
            if (result)
            {
                return RedirectToAction("AracListeleme");
            }
            else
            {
                return View("Error");
            }
        }

		[Authorize]
		[HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            IhaleListesi ihaleler = await _apiGateway.GetIhale(id);
            if (ihaleler == null)
            {
                return NotFound();
            }
            return View(ihaleler);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IhaleListesi ihaleler)
        {
            if (ModelState.IsValid)
            {
                bool isSuccess = await _apiGateway.UpdateIhale(ihaleler);
                if (isSuccess)
                {

                    return RedirectToAction("AracListeleme");
                }
                else
                {

                    ModelState.AddModelError("", "Duzenleme islemi basarısız oldu.");
                }
            }
            return View(ihaleler);
        }

        [HttpPost]
        public async Task<IActionResult> Listele(IhaleListesi ihale, string ihaleAdi, int aracTuru, int aracDurumu)
        {
            List<IhaleListesi> ihaleler = await _apiGateway.ListIhale();

            if (!string.IsNullOrEmpty(ihaleAdi))
            {
                ihaleler = ihaleler.Where(i => i.IhaleAdi == ihaleAdi).ToList();
            }

            if (aracTuru != 0)
            {
                ihaleler = ihaleler.Where(i => i.BireyselKurumsalID == aracTuru).ToList();
            }

            if (aracDurumu != 0)
            {
                ihaleler = ihaleler.Where(i => i.IhaleStatuID == aracDurumu).ToList();
            }

            return View("AracListeleme", ihaleler);
        }

        [HttpPost]
        public async Task<IActionResult> IhaleListeFiltrele(IhaleListesi ihale, string ihaleAdi, int aracTuru, int aracDurumu)
        {
            List<IhaleListesi> ihaleler = await _apiGateway.ListIhale();

            if (!string.IsNullOrEmpty(ihaleAdi))
            {
                ihaleler = ihaleler.Where(i => i.IhaleAdi == ihaleAdi).ToList();
            }

            if (aracTuru != 0)
            {
                ihaleler = ihaleler.Where(i => i.BireyselKurumsalID == aracTuru).ToList();
            }

            if (aracDurumu != 0)
            {
                ihaleler = ihaleler.Where(i => i.IhaleStatuID == aracDurumu).ToList();
            }

            return View("IhaleListeleme", ihaleler);
        }
    }
} 
