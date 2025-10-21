using FootballApps.BusinessLayer.Abstract;
using FootballApps.DtoLayer.Dtos.LatestNewDtos;
using FootballApps.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballApps.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LatestNewsController : ControllerBase
    {
        private readonly ILatestNewService _service;

        public LatestNewsController(ILatestNewService service)
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
        public IActionResult Create([FromBody] CreateLatestNewDto dto)
        {
            var LatestNewEntity = new LatestNew
            {
                Title = dto.Title,
                ImageUrl = dto.ImageUrl,
                Writer = dto.Writer,
                CreatedDate = dto.CreatedDate,
                WriterImageUrl = dto.WriterImageUrl
            };
            _service.TAdd(LatestNewEntity);
            return Ok("Haber Başarıyla Eklendi");
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateLatestNewDto dto)
        {
            var existingLatestNew = _service.TGetById(dto.LatestNewId);
            existingLatestNew.Title = dto.Title;
            existingLatestNew.ImageUrl = dto.ImageUrl;
            existingLatestNew.Writer = dto.Writer;
            existingLatestNew.CreatedDate = dto.CreatedDate;
            existingLatestNew.WriterImageUrl = dto.WriterImageUrl;
            _service.TUpdate(existingLatestNew);
            return Ok("Haber Başarıyla Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Haber Başarıyla Silindi");
        }
    }
}
