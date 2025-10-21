using FootballApps.BusinessLayer.Abstract;
using FootballApps.DtoLayer.Dtos.MatchsDtos;
using FootballApps.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballApps.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchsController : ControllerBase
    {
        private readonly IMatchService _service;

        public MatchsController(IMatchService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            var values = _service.TGetListAll();
            return Ok(values);
        }
        [HttpGet("Get4UpcomingMatchEvent")]
        public IActionResult Get4UpcomingMatchEvent()
        {
            var values = _service.TGet4UpcomingMatchEvent();
            return Ok(values);
        }
        [HttpGet("GetListWithTeams")]
        public IActionResult GetListWithTeams()
        {
            var values = _service.TGetMatchListWithTeamName();
            return Ok(values);
        }
        [HttpGet("GetUpcomingMatchEvent")]
        public IActionResult GetUpcomingMatchEvent()
        {
            var values = _service.TGetUpcomingMatchEvent();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _service.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateMatchDto dto)
        {
            var MatchEntity = new Matchs
            {
                MatchsDate = dto.MatchsDate,
                Stadium = dto.Stadium,
                League = dto.League,
                HomeTeamScore = dto.HomeTeamScore,
                AwayTeamScore = dto.AwayTeamScore,
                HomeTeamId = dto.HomeTeamId,
                AwayTeamId = dto.AwayTeamId
            };
            _service.TAdd(MatchEntity);
            return Ok("Maç Başarıyla Eklendi");
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateMatchDto dto)
        {
            var existingMatch = _service.TGetById(dto.MatchsId);
            existingMatch.MatchsDate = dto.MatchsDate;
            existingMatch.Stadium = dto.Stadium;
            existingMatch.League = dto.League;
            existingMatch.HomeTeamScore = dto.HomeTeamScore;
            existingMatch.AwayTeamScore = dto.AwayTeamScore;
            existingMatch.HomeTeamId = dto.HomeTeamId;
            existingMatch.AwayTeamId = dto.AwayTeamId;
            _service.TUpdate(existingMatch);
            return Ok("Maç Başarıyla Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Maç Başarıyla Silindi");
        }
    }
}
