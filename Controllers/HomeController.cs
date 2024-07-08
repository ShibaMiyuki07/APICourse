using API.Models;
using API.Models.Dto.Response;
using API.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/Home")]
    [ApiController]
    public class HomeController(IAdminService adminService, IEquipeService equipeService,IMapper Mapper,IEtapeService EtapeService) : ControllerBase
    {
        private readonly IAdminService AdminService = adminService;
        private readonly IEquipeService EquipeService = equipeService;
        private readonly IMapper Mapper = Mapper;
        private readonly IEtapeService EtapeService = EtapeService;

        [HttpPost("Login")]
        public async Task<ActionResult> Login(API.Models.Dto.Request.AdminDto admin)
        {
            Admin? CompteAdmin = await AdminService.GetAdminByLoginAsync(admin);
            Equipe? CompteEquipe = await EquipeService.GetEquipeByLoginAsync(admin);
            if (CompteAdmin != null)
            {
                AdminDto Response = Mapper.Map<AdminDto>(CompteAdmin);
                return Ok(Response);
            }
            if (CompteEquipe != null)
            {
                EquipeDto Response = Mapper.Map<EquipeDto>(CompteEquipe);
                return Ok(Response);
            }
            return BadRequest("Le compte n'existe pas");
        }

        [HttpPost("CreateAdmin")]
        public async Task<ActionResult> CreateAdmin(API.Models.Dto.Request.AdminDto admin)
        {
            Admin retour = await AdminService.CreateAdminAsync(admin);
            return Ok(Mapper.Map<API.Models.Dto.Response.AdminDto>(retour));
        }

        [HttpPost("CreateEquipe")]
        public async Task<ActionResult> CreateEquipe(API.Models.Dto.Request.EquipeDto Equipe)
        {
            Equipe retour = await EquipeService.CreateEquipeAsync(Equipe);
            return Ok(Mapper.Map<API.Models.Dto.Response.EquipeDto>(retour));
        }

        [HttpGet("ListeEtape")]
        public async Task<ActionResult> ListeEtape()
        {
            IEnumerable<Etape> ListeEtapes = await EtapeService.SelectAllAsync();
            if (!ListeEtapes.Any())
            {
                return BadRequest("Il n'y a pas de liste d'étapes");
            }
            return Ok(ListeEtapes);
        }


        [HttpPost("CreateEtape")]
        public async Task<ActionResult> CreateEtape(API.Models.Dto.Request.EtapeDto etape)
        {
            Etape nouveau = await EtapeService.CreateAsync(etape);
            return Ok(nouveau);
        }

    }
}
