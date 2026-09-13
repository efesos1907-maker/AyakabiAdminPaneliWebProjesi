using Microsoft.AspNetCore.Mvc;
using WebApplication55.Models;

namespace WebApplication55.Controllers
{
    public class AyakkabiController : Controller
    {
        private static readonly List<Ayakkabi> _ayakkabilar = new List<Ayakkabi>();
        private static int _nextId = 1;

        private readonly IWebHostEnvironment _environment;

        public AyakkabiController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View(_ayakkabilar);
        }

        public IActionResult List()
        {
            return View(_ayakkabilar);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Ayakkabi model, IFormFile? resimDosyasi)
        {
            if (ModelState.IsValid)
            {
                if (resimDosyasi != null && resimDosyasi.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(resimDosyasi.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await resimDosyasi.CopyToAsync(fileStream);
                    }

                    model.ResimUrl = "/uploads/" + uniqueFileName;
                }
                else if (string.IsNullOrWhiteSpace(model.ResimUrl))
                {
                    model.ResimUrl = "/ayakabısite/images/AYKB.webp";
                }

                model.Id = _nextId++;
                _ayakkabilar.Add(model);

                return RedirectToAction(nameof(List));
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var ayakkabi = _ayakkabilar.FirstOrDefault(a => a.Id == id);
            if (ayakkabi == null)
            {
                return RedirectToAction(nameof(List));
            }

            return View(ayakkabi);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Ayakkabi model, IFormFile? resimDosyasi)
        {
            var mevcut = _ayakkabilar.FirstOrDefault(a => a.Id == model.Id);
            if (mevcut != null && ModelState.IsValid)
            {
                if (resimDosyasi != null && resimDosyasi.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(resimDosyasi.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await resimDosyasi.CopyToAsync(fileStream);
                    }

                    mevcut.ResimUrl = "/uploads/" + uniqueFileName;
                }
                else if (!string.IsNullOrWhiteSpace(model.ResimUrl))
                {
                    mevcut.ResimUrl = model.ResimUrl;
                }

                mevcut.Baslik = model.Baslik;
                mevcut.Aciklama = model.Aciklama;
                mevcut.Fiyat = model.Fiyat;

                return RedirectToAction(nameof(List));
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var ayakkabi = _ayakkabilar.FirstOrDefault(a => a.Id == id);
            if (ayakkabi != null)
            {
                _ayakkabilar.Remove(ayakkabi);
            }

            return RedirectToAction(nameof(List));
        }
    }
}
