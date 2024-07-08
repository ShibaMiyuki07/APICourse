using API.Models;

namespace API.Services.Interface
{
    public interface IResultatService
    {
        public Task<IEnumerable<Resultat>> SelectAllAsync();
        public Task<IEnumerable<Resultat>> SelectAllByIdEtape(string idetape);

    }
}
