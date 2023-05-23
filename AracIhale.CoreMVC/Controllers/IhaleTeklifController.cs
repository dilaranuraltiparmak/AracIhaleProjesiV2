using AracIhale.CoreMVC.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AracIhale.CoreMVC.Controllers
{
	public class IhaleTeklifController : Controller
	{


        private readonly APIGateway _apiGateway;

        public IhaleTeklifController(APIGateway apiGateway)
        {
            _apiGateway = apiGateway;
        }
		[Authorize]
		[HttpGet]
        public async Task<IActionResult> TeklifVer(int id)
        {

            IhaleTeklif ihaleteklif = await _apiGateway.GetIhaleTeklif(id);
            if (ihaleteklif == null)
            {
                return NotFound();
            }
            return View(ihaleteklif);
        }

        [HttpPost]
        public async Task<IActionResult> TeklifVer(IhaleTeklif ihaleTeklif)
        {
            if (ModelState.IsValid)
            {
                await _apiGateway.CreateIhaleTeklif(ihaleTeklif);
                return RedirectToAction("Teklifler", "IhaleTeklif");
            }
            return View(ihaleTeklif);
        }


		[Authorize]
		[HttpGet]
        public async Task<IActionResult> Teklifler()
        {
            var ihaleler = await _apiGateway.ListIhaleTeklif();
            return View(ihaleler);
        }



        public async Task<IActionResult> DeleteTeklif(int id)
        {
            var result = await _apiGateway.DeleteIhaleTeklif(id);
            if (result)
            {
                return RedirectToAction("Teklifler");
            }
            else
            {
                return View("Error");
            }
        }

		[Authorize]
		public async Task<IActionResult> EditTeklif(int id)
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

        public async Task<IActionResult> OnaylaTeklif(int id)
        {
            var result = await _apiGateway.OnaylaIhaleTeklif(id);

            if (result)
            {
                return RedirectToAction("OnaylananTeklifler");
            }
            else
            {
                return View("Error");
            }

        }

		[Authorize]
		[HttpGet]
        public async Task<IActionResult> OnaylananTeklifler(int id)
        {
			var ihaleler = await _apiGateway.ListIhaleTeklifOnay();
			return View(ihaleler);
		}
	}


	
}
