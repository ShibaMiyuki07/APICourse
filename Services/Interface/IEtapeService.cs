using API.Models;

namespace API.Services.Interface
{
    public interface IEtapeService
    {
        public Task<IEnumerable<Etape>> SelectAllAsync();
        public Task<Etape> CreateAsync(API.Models.Dto.Request.EtapeDto etape);
    }
}
