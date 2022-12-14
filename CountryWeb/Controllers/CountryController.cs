using Data1.Models;
using Data1.DTO;
using Microsoft.AspNetCore.Mvc;
using ToWinFromFromAPI;
using CountryWeb.ViewModels;
using System.Diagnostics.Metrics;

namespace CountryWeb.Controllers
{
    public class CountryController : Controller
    {
        private readonly HalperAPI halper;

        public CountryController()
        {
            halper = new HalperAPI("https://localhost:7296/api/Country");
        }

        public async Task<IActionResult> Index()
        {
            var res = await halper.Get();
            return View(res);
        }

        //Post
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Add(CounrtyDto countryDto)
        {
            await halper.Post(countryDto);
            return Redirect("Index");
        }
        //Put  Edit
        public async Task<IActionResult> Edit(int id)
        {
            var res = await halper.Get(id);


            return View(res);
        }
        public async Task<IActionResult> Save(Country country)
        {
            int id = country.Id;
            CounrtyDto dto = new CounrtyDto()
            {
                Description = country.Description,
                MspUrl = country.MspUrl,
                Name = country.Name,

            };
            halper.Put(id, dto);
            return Redirect("Index");
        }

        //Show
        public async Task<IActionResult> Show(int? id)
        {
            var res = await halper.Get(id ?? 1);
            return View(res);
        }

        //Delete
        public async Task<IActionResult> Delete(int? id)
        {
            var res = await halper.Get(id ?? 1);
            CounrtyDto dto = new CounrtyDto()
            {
                Description = res.Description,
                MspUrl = res.MspUrl,
                Name = res.Name,

            };
            CountryEditModel editModel = new CountryEditModel()
            {
                Id = id ?? 1,
                Dto = dto,

            };
            return View(editModel);
        }

        public async Task<IActionResult> DelSave(int? id)
        {
            int Id = id ?? 1;
             await halper.Delete(Id);
            return RedirectToAction("index");
        }
        //delete
        /* public async Task<IActionResult> Delete(int id)
         {
             var  res = halper.Get(id);
             if (res != null)
             {
                await halper.Delete(id);
                 return RedirectToAction("index");
             }
             else
             {
                 return RedirectToAction("CountryNotFound", new { Id=id });
             }

         }*/
    }
}
