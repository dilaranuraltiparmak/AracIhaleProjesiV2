using AracIhale.CoreMVC.Models.VM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Net.Http.Json;
using AracIhale.CoreMVC.Extension;
using System.Net;

namespace AracIhale.CoreMVC.Controllers
{
    public class GirisController : Controller
    {
		private readonly HttpClient _httpClient;

		public GirisController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public IActionResult Giris()
		{
			var model = new Kullanici();

			if (Request.Cookies.ContainsKey("username"))
			{
				model.KullaniciAdi = Request.Cookies["username"];
			}

			return View(model);
		}

    
		

		[HttpPost]
		public async Task<IActionResult> Giris(Kullanici model, bool rememberMe)
		{
			var response = await _httpClient.PostAsJsonAsync("http://localhost:20750/api/Giris", model);

            if (response.IsSuccessStatusCode)
            {
                Kullanici user = await response.Content.ReadFromJsonAsync<Kullanici>();

                HttpContext.Session.MySessionSet("RolID", user.RolID);

                if (rememberMe)
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(30); 
                    Response.Cookies.Append("username", model.KullaniciAdi, options);
                }

                HttpContext.Session.MySessionSet("Ad", model.KullaniciAdi);
                HttpContext.Session.MySessionSet("KullaniciID", user.KullaniciID);
                HttpContext.Session.MySessionSet("KullaniciAdi", user.Ad); 
                return RedirectToAction("AracListeleme", "Ihale");
            }
            else
            {
                var statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Unauthorized)
                {
             
                    ModelState.AddModelError(string.Empty, "Invalid password. Please check your password and try again.");
                }
                else
                {
                   
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }

                return View(model);
            }
        }
    }
}
