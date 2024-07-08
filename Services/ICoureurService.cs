using API.Models;

namespace API.Services
{
    public interface ICoureurService
    {
        public Task<IEnumerable<Coureur>> GetCoureurByEquipe(string idEquipe);
    }
}
