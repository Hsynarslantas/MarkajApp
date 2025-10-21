using FootballApps.BusinessLayer.Abstract;
using FootballApps.DtoLayer.Dtos.PlayerDtos;
using FootballApps.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballApps.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _service;

        public PlayersController(IPlayerService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            var values = _service.TGetListAll();
            return Ok(values);
        }
        [HttpGet("GetStarPlayers")]
        public IActionResult GetStarPlayers()
        {
            var values = _service.TGetStarPlayers();
            return Ok(values);
        }
        [HttpGet("GetMostGoal5Players")]
        public IActionResult GetMostGoal5Players()
        {
            var values = _service.TGetMostGoal5Players();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _service.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreatePlayerDto dto)
        {
            var playerEntity = new Player
            {
                FullName = dto.FullName,
                Position = dto.Position,
                ShirtNumber = dto.ShirtNumber,
                PhotoUrl = dto.PhotoUrl,
                TeamId = dto.TeamId,
                PlayerVideoUrl = dto.PlayerVideoUrl,
                Goals = dto.Goals
            };
            _service.TAdd(playerEntity);
            return Ok("Oyuncu Başarıyla Eklendi");
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdatePlayerDto dto)
        {
            var existingPlayer = _service.TGetById(dto.PlayerId);
            existingPlayer.FullName = dto.FullName;
            existingPlayer.Position = dto.Position;
            existingPlayer.ShirtNumber = dto.ShirtNumber;
            existingPlayer.PhotoUrl = dto.PhotoUrl;
            existingPlayer.TeamId = dto.TeamId;
            existingPlayer.PlayerVideoUrl = dto.PlayerVideoUrl;
            existingPlayer.Goals = dto.Goals;
            _service.TUpdate(existingPlayer);
            return Ok("Oyuncu Başarıyla Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Oyuncu Başarıyla Silindi");
        }
    }
}
