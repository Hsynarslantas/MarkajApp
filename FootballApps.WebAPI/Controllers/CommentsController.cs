using FootballApps.BusinessLayer.Abstract;
using FootballApps.DtoLayer.Dtos.CommentDtos;
using FootballApps.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballApps.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _service;

        public CommentsController(ICommentService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            var values = _service.TGetListAll();
            return Ok(values);
        }
        [HttpGet("GetCommentsByBlogId/{id}")]
        public IActionResult GetCommentsByBlogId(int id)
        {
            var values = _service.TGetCommentsByBlogId(id);
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _service.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateCommentDto dto)
        {
            var CommentEntity = new Comment
            {
                NameSurname = dto.NameSurname,
                Email = dto.Email,
                Subject = dto.Subject,
                Body = dto.Body,
                BlogId = dto.BlogId
            };
            _service.TAdd(CommentEntity);
            return Ok("Yorum Başarıyla Eklendi");
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateCommentDto dto)
        {
            var existingComment = _service.TGetById(dto.CommentId);
            existingComment.NameSurname = dto.NameSurname;
            existingComment.Email = dto.Email;
            existingComment.Subject = dto.Subject;
            existingComment.Body = dto.Body;
            existingComment.BlogId = dto.BlogId;
            _service.TUpdate(existingComment);
            return Ok("Yorum Başarıyla Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Yorum Başarıyla Silindi");
        }
    }
}
