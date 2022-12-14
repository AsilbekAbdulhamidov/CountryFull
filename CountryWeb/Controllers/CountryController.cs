using Data1.Models;
using Data1.DTO;
using Microsoft.AspNetCore.Mvc;
using ToWinFromFromAPI;
using CountryWeb.ViewModels;

namespace CountryWeb.Controllers
{
    public class CountryController : Controller
    {
        private readonly HalperAPI halper;

        public CountryController()
        {
            halper = new HalperAPI("https://localhost:7296/api/Country");
        }

        public async  Task<IActionResult> Index()
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
                MspUrl= country.MspUrl,
                Name= country.Name,

            };
            halper.Put(id, dto);
            return Redirect("Index");
        }

        //Show
        public async Task<IActionResult> Show(int? id)
        {
            var res = await halper.Get(id??1);
            return View(res);
        }
    }
}
