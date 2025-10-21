using FootballApps.BusinessLayer.Abstract;
using FootballApps.DtoLayer.Dtos.VideoDtos;
using FootballApps.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballApps.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IVideoService _service;

        public VideosController(IVideoService service)
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
        public IActionResult Create([FromBody] CreateVideoDto dto)
        {
            var VideoEntity = new Video
            {
                Title = dto.Title,
                ImageUrl = dto.ImageUrl,
                VideoUrl = dto.VideoUrl,
            };
            _service.TAdd(VideoEntity);
            return Ok("Video Başarıyla Eklendi");
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateVideoDto dto)
        {
            var existingVideo = _service.TGetById(dto.VideoId);
            existingVideo.Title = dto.Title;
            existingVideo.ImageUrl = dto.ImageUrl;
            existingVideo.VideoUrl = dto.VideoUrl;
            _service.TUpdate(existingVideo);
            return Ok("Video Başarıyla Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Video Başarıyla Silindi");
        }
    }
}
