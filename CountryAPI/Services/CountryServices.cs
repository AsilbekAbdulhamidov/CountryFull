using CountryAPI.Repostory;
using Data1.DTO;
using Data1.Models;
using AutoMapper;

namespace CountryAPI.Services
{
    public class CountryServices : IServices<Country,CounrtyDto>
    {
        private readonly IRepostory<Country> cnRep;
        private readonly IMapper mapper;  //reg qilish kkk


        public CountryServices(IRepostory<Country> _cnRep, IMapper _mapper)
        {
            cnRep = _cnRep;
            mapper = _mapper;
        }

        public async Task Create(CounrtyDto DTO)
        {
            var country = mapper.Map<Country>(DTO);

            //try
            //{
            //    var fil = DTO.fromFile;
            //    if (fil != null)
            //    {
            //        FileInfo fi = new FileInfo(fil.FileName);
            //        var newfilename = "image_" + DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
            //        var path = Path.Combine("", hostEnvironment.ContentRootPath + "/Images/" + newfilename);
            //        using (var stream = new FileStream(path, FileMode.Create))
            //        {
            //            fil.CopyTo(stream);
            //        }
            //        DTO.ImageURl = path;


            //    }
            //}
            //catch (Exception ex)
            //{

            //}

            cnRep.Create(country).GetAwaiter().GetResult();
        }

        public async Task<bool> Delete(int id)
        {
            var res = await cnRep.Get(id);
            if (res is null)
            {
                return false;
            }
            else
            {
                await cnRep.Delete(res);
                return true;
            }
        }

        public async Task<IEnumerable<Country>> Get()
        {
            return await cnRep.Get();
        }

        public async Task<Country> Get(int id)
        {
            return await cnRep.Get(id);
        }

        public async Task<Country> UpdateCountry(int id, CounrtyDto DTO)
        {
            Country country = mapper.Map<Country>(DTO);
            country.Id = id;
            return await cnRep.Update(id, country);
        }



    }
}
