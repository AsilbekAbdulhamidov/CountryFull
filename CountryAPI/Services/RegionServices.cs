using AutoMapper;
using CountryAPI.Repostory;
using Data1.DTO;
using Data1.Models;

namespace CountryAPI.Services
{
    public class RegionServices : IServices<Region, RegionDto>
    {
        private readonly IRepostory<Region> _regRep;
        private readonly IMapper _mapper;

        public RegionServices(IRepostory<Region> regRep, IMapper mapper)
        {
            _regRep = regRep;
            _mapper = mapper;
        }

        public async Task Create(RegionDto DTO)
        {

            await _regRep.Create(_mapper.Map<Region>(DTO));

        }

        public async Task<bool> Delete(int id)
        {
            var res = await _regRep.Get(id);
            if (res is null)
            {
                return false;
            }
            else
            {
                await _regRep.Delete(res);
                return true;
            }
        }

        public async Task<IEnumerable<Region>> Get()
        {
            return await _regRep.Get();
        }

        public async Task<Region> Get(int id)
        {
            return await _regRep.Get(id);
        }

        public async Task<Region> UpdateCountry(int id, RegionDto DTO)
        {
            Region reg = _mapper.Map<Region>(DTO);
            reg.Id = id;
            return await _regRep.Update(id, reg);

        }
    }
}
