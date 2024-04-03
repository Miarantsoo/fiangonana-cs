using fiangonana_cs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace fiangonana_cs.Controllers
{
    public class MpiangonaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(FormCollection values)
        {
            var email = values["email"];
            var password = values["password"];
            Mpiangona mpiangona = new();
            bool verify = mpiangona.GetByPassword(email, password);
            if (verify)
            {
                string json = JsonConvert.SerializeObject(mpiangona);
                HttpContext.Session.SetString("user", json);
                return RedirectToAction("Home", "DemandePret");
            }
            return RedirectToAction("Index");
        }
    }
}
