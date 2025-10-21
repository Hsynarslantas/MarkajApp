using FootballApps.BusinessLayer.Abstract;
using FootballApps.DtoLayer.Dtos.TeamDtos;
using FootballApps.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballApps.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _service;

        public TeamsController(ITeamService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            var values = _service.TGetListAll();
            return Ok(values);
        }
        [HttpGet("GetTeamsWithPoints")]
        public IActionResult GetTeamsWithPoints()
        {
            var values = _service.TGetTeamWithPoints();
            return Ok(values);
        }
        [HttpGet("GetMaxPointByTeam")]
        public IActionResult GetMaxPointByTeam()
        {
            var values = _service.TGetMaxPointByTeam();
            return Ok(values);
        }
        [HttpGet("GetMinPointByTeam")]
        public IActionResult GetMinPointByTeam()
        {
            var values = _service.TGetMinPointByTeam();
            return Ok(values);
        }
        [HttpGet("GetTeamWithMostLosses")]
        public IActionResult GetTeamWithMostLosses()
        {
            var values = _service.TGetTeamWithMostLosses();
            return Ok(values);
        }
        [HttpGet("GetMaxDrawByTeam")]
        public IActionResult GetMaxDrawByTeam()
        {
            var values = _service.TGetMaxDrawByTeam();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _service.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateTeamDto dto)
        {
            var TeamEntity = new Team
            {
                Name = dto.Name,
                LogoUrl = dto.LogoUrl,
                CoachName = dto.CoachName,

            };
            _service.TAdd(TeamEntity);
            return Ok("Takım Başarıyla Eklendi");
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateTeamDto dto)
        {
            var existingTeam = _service.TGetById(dto.TeamId);
            existingTeam.Name = dto.Name;
            existingTeam.LogoUrl = dto.LogoUrl;
            existingTeam.CoachName = dto.CoachName;
            _service.TUpdate(existingTeam);
            return Ok("Takım Başarıyla Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Takım Başarıyla Silindi");
        }
    }
}
