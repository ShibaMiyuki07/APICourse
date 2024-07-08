using API.Models;

namespace API.Services.Interface
{
    public interface IAdminService
    {
        public Task<Admin?> GetAdminByLoginAsync(API.Models.Dto.Request.AdminDto admin);
        public Task<Admin> CreateAdminAsync(API.Models.Dto.Request.AdminDto admin);
    }
}
