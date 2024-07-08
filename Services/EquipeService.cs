using API.Context;
using API.Models;
using API.Services.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class EquipeService(CourseContext courseContext,IMapper Mapper) : IEquipeService
    {
        private readonly CourseContext CourseContext = courseContext;
        private readonly IMapper Mapper = Mapper;

        public async Task<Equipe?> GetEquipeByLoginAsync(API.Models.Dto.Request.AdminDto admin)
        {
            return await CourseContext.Equipes.Where(c => c.Login == admin.Login && c.Password == admin.Password).FirstOrDefaultAsync();
        }

        public async Task<Equipe> CreateEquipeAsync(API.Models.Dto.Request.EquipeDto equipe)
        {
            Equipe Nouveau = Mapper.Map<Equipe>(equipe);
            await CourseContext.AddAsync(Nouveau);
            await CourseContext.SaveChangesAsync();
            return Nouveau;
        }
    }
}
