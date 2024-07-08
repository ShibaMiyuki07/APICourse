using API.Context;
using API.Models;
using API.Services.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class AdminService(CourseContext courseContext,IMapper mapper) : IAdminService
    {
        private readonly CourseContext CourseContext = courseContext;
        private readonly IMapper Mapper = mapper;

        public async Task<Admin?> GetAdminByLoginAsync(API.Models.Dto.Request.AdminDto admin)
        {
            return await CourseContext.Admins.Where(c => c.Login == admin.Login && c.Password == admin.Password).FirstOrDefaultAsync()!;
        }

        public async Task<Admin> CreateAdminAsync(API.Models.Dto.Request.AdminDto admin)
        {
            Admin nouveau = Mapper.Map<Admin>(admin);
            await CourseContext.AddAsync(nouveau);
            await CourseContext.SaveChangesAsync();
            return nouveau;
        }
    }
}
