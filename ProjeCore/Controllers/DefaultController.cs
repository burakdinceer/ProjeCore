using Microsoft.AspNetCore.Mvc;
using ProjeCore.Models;
using System.Linq;

namespace ProjeCore.Controllers
{
    public class DefaultController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler = c.Birims.ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult YeniBirim()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniBirim(Birim b)
        {
            c.Birims.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");


        }

        public IActionResult BirimSil(int id)
        {
            var dep = c.Birims.Find(id);
            c.Birims.Remove(dep);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult BirimGetir(int id)
        {
            var depart = c.Birims.Find(id);
            return View("BirimGetir", depart);
        }

        public IActionResult BirimGüncelle(Birim d)
        {
            var dp = c.Birims.Find(d.BirimID);
            dp.BirimAd = d.BirimAd;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult BirimDetay(int id)
        {
            var degerler=c.Personels.Where(x=>x.BirimID==id).ToList();
            var brmad = c.Birims.Where(x => x.BirimID == id).Select(y => y.BirimAd).FirstOrDefault();
            ViewBag.brm=brmad;
            return View(degerler);
        }
    }
}
