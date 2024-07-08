using API.Context;
using API.Models;
using API.Services.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class EtapeService(CourseContext courseContext,IMapper mapper) : IEtapeService
    {
        private readonly IMapper Mapper = mapper;
        private readonly CourseContext CourseContext = courseContext;

        public async Task<IEnumerable<Etape>> SelectAllAsync()
        {
            return await CourseContext.Etapes.ToListAsync();
        }

        public async Task<Etape> CreateAsync(API.Models.Dto.Request.EtapeDto etape)
        {
            Etape nouveau = Mapper.Map<Etape>(etape);
            await CourseContext.AddAsync(nouveau);
            await CourseContext.SaveChangesAsync();
            return nouveau;
        }
    }
}
