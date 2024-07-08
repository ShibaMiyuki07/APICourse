using API.Models;

namespace API.Services.Interface
{
    public interface IEquipeService
    {
        public Task<Equipe?> GetEquipeByLoginAsync(API.Models.Dto.Request.AdminDto admin);

        public Task<Equipe> CreateEquipeAsync(API.Models.Dto.Request.EquipeDto equipe);
    }
}
