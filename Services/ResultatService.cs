using API.Context;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ResultatService(CourseContext courseContext)
    {
        private readonly CourseContext CourseContext = courseContext;

        public async Task<IEnumerable<Resultat>> SelectAllAsync()
        {
            return await CourseContext.Resultats.Include(c => c.IdetapecoureurNavigation).Include(c => c.Resultatspenalites).ToListAsync();
        }

        public async Task<IEnumerable<Resultat>> SelectAllByIdEtape(string idetape)
        {
            return await CourseContext.Resultats.Include(c => c.IdetapecoureurNavigation).Where(c => c.IdetapecoureurNavigation!.Idetape == idetape).ToListAsync();
        }
    }
}
