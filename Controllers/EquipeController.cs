using API.Models;
using API.Services;
using API.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/Equipe")]
    [ApiController]
    public class EquipeController(IMapper mapper,IResultatService resultatService,ICoureurService coureurService) : ControllerBase
    {
        private readonly IMapper Mapper = mapper;
        private readonly IResultatService ResultatService = resultatService;
        private readonly ICoureurService CoureurService = coureurService;

        [HttpGet("Resultat/{idEtape}")]
        public async Task<ActionResult> ResultatByEtape([FromRoute] string idEtape)
        {
            IEnumerable<Resultat> ListeResultat = await ResultatService.SelectAllByIdEtape(idEtape);
            return Ok(ListeResultat);
        }
        [HttpGet("Coureur/{idequipe}")]
        public async Task<ActionResult> GetCoureurByEquipe(string idEquipe)
        {
            IEnumerable<Coureur> ListeCoureur = await CoureurService.GetCoureurByEquipe(idEquipe);
            if (!ListeCoureur.Any())
            {
                return BadRequest("Cette équipe n'a pas de coureur");
            }
            return Ok(ListeCoureur);
        }

    }
}
