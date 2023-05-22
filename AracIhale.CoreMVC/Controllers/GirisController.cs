using AracIhale.CoreMVC.Models.VM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Net.Http.Json;
using AracIhale.CoreMVC.Extension;

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
                    // Kullanıcı adını çerezlere kaydediyoruz
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(30); // Çerezin 30 gün boyunca geçerli olmasını sağlıyoruz
                    Response.Cookies.Append("username", model.KullaniciAdi, options);
                }

                HttpContext.Session.MySessionSet("Ad", model.KullaniciAdi);// Kullanıcı adını bir Session'a kaydediyoruz
                HttpContext.Session.MySessionSet("KullaniciID", user.KullaniciID);// Kullanıcı IDsini bir Session'a kaydediyoruz
                HttpContext.Session.MySessionSet("KullaniciAdi", user.Ad); // Kullanıcı gerçek adını bir Session'a kaydediyoruz
                return RedirectToAction("AracListeleme", "Ihale");
            }
            else
            {
                // Giriş başarısız oldu, hata mesajını göster ve kullanıcıyı geri yönlendir
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

        }
    }
}
