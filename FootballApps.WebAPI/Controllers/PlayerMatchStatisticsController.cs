using FootballApps.BusinessLayer.Abstract;
using FootballApps.DtoLayer.Dtos.PlayerMatchStatisticsDtos;
using FootballApps.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballApps.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerStatisticsController : ControllerBase
    {
        private readonly IPlayerMatchStatisticService _service;

        public PlayerStatisticsController(IPlayerMatchStatisticService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = _service.TGetListAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _service.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreatePlayerMatchStatisticDto dto)
        {
            var PlayerMatchStatisticEntity = new PlayerMatchStatistic
            {
                PlayerId = dto.PlayerId,
                MatchsId = dto.MatchsId,
                Goals = dto.Goals,
                Assists = dto.Assists,
                YellowCards = dto.YellowCards,
                RedCards = dto.RedCards,
                GoalMinutes = dto.GoalMinutes,
            };
            _service.TAdd(PlayerMatchStatisticEntity);
            return Ok("Oyuncu Maç İstatistiği Başarıyla Eklendi");
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdatePlayerMatchStatisticDto dto)
        {
            var existingPlayerMatchStatistic = _service.TGetById(dto.Id);
            existingPlayerMatchStatistic.PlayerId = dto.PlayerId;
            existingPlayerMatchStatistic.MatchsId = dto.MatchsId;
            existingPlayerMatchStatistic.Goals = dto.Goals;
            existingPlayerMatchStatistic.Assists = dto.Assists;
            existingPlayerMatchStatistic.YellowCards = dto.YellowCards;
            existingPlayerMatchStatistic.RedCards = dto.RedCards;
            existingPlayerMatchStatistic.GoalMinutes = dto.GoalMinutes;
            _service.TUpdate(existingPlayerMatchStatistic);
            return Ok("Oyuncu Maç İstatistiği Başarıyla Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Oyuncu Maç İstatistiği Başarıyla Silindi");
        }
    }
}
