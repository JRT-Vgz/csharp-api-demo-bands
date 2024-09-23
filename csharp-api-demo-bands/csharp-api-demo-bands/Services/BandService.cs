using AutoMapper;
using csharp_api_demo_bands.DTOs;
using csharp_api_demo_bands.Models;
using csharp_api_demo_bands.Repository;

namespace csharp_api_demo_bands.Services
{
    public class BandService : ICommonService<BandDto, BandInsertDto, BandUpdateDto>
    {
        private IRepository<Band> _bandRepository;
        private IMapper _mapper;

        public BandService(IRepository<Band> bandRepository,
            IMapper mapper)
        {
            _bandRepository = bandRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BandDto>> GetAll()
        {
            var bands = await _bandRepository.GetAll();
            return bands.Select(b => _mapper.Map<BandDto>(b));
        }

        public async Task<BandDto> GetById(int id)
        {
            var band = await _bandRepository.GetById(id);

            if (band == null) { return null; }

            var bandDto = _mapper.Map<BandDto>(band);

            return bandDto;
        }

        public async Task<BandDto> Insert(BandInsertDto bandInsertDto)
        {
            var band = _mapper.Map<Band>(bandInsertDto);

            await _bandRepository.Insert(band);
            await _bandRepository.Save();

            var bandDto = _mapper.Map<BandDto>(band);

            return bandDto;
        }

        public async Task<BandDto> Update(BandUpdateDto bandUpdateDto, int id)
        {
            var band = await _bandRepository.GetById(id);

            if (band == null) { return null; }

            band = _mapper.Map<BandUpdateDto, Band>(bandUpdateDto, band);

            _bandRepository.Update(band);
            await _bandRepository.Save();

            var bandDto = _mapper.Map<BandDto>(band);

            return bandDto;
        }

        public async Task<BandDto> Delete(int id)
        {
            var band = await _bandRepository.GetById(id);

            if (band == null) { return null; }

            _bandRepository.Delete(band);
            await _bandRepository.Save();

            var bandDto = _mapper.Map<BandDto>(band);

            return bandDto;
        }
    }
}
