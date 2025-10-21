using FootballApps.BusinessLayer.Abstract;
using FootballApps.DtoLayer.Dtos.BlogDtos;
using FootballApps.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballApps.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _service;

        public BlogsController(IBlogService service)
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
        public IActionResult Create([FromBody] CreateBlogDto dto)
        {
            var BlogEntity = new Blog
            {
                Title = dto.Title,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Writer = dto.Writer,
                CreatedDate = dto.CreatedDate,
                WriterImageUrl = dto.WriterImageUrl,
                WriterDescription = dto.WriterDescription
            };
            _service.TAdd(BlogEntity);
            return Ok("Blog Başarıyla Eklendi");
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateBlogDto dto)
        {
            var existingBlog = _service.TGetById(dto.BlogId);
            existingBlog.Title = dto.Title;
            existingBlog.ImageUrl = dto.ImageUrl;
            existingBlog.Writer = dto.Writer;
            existingBlog.Description = dto.Description;
            existingBlog.CreatedDate = dto.CreatedDate;
            existingBlog.WriterImageUrl = dto.WriterImageUrl;
            existingBlog.WriterDescription = dto.WriterDescription;
            _service.TUpdate(existingBlog);
            return Ok("Blog Başarıyla Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Blog Başarıyla Silindi");
        }
    }
}
