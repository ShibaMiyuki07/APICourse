using API.Context;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CoureurService
    {
        private readonly CourseContext CourseContext;

        public CoureurService(CourseContext courseContext)
        {
            CourseContext = courseContext;
        }

        public async Task<IEnumerable<Coureur>> GetCoureurByEquipe(string idEquipe)
        {
            return await CourseContext.Coureurs.Include(c => c.IdgenreNavigation).Include(c => c.IdequipeNavigation).Where(c => c.Idequipe == idEquipe).ToListAsync();
        }
    }
}
