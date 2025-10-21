using FootballApps.BusinessLayer.Abstract;
using FootballApps.DtoLayer.Dtos.ContactCommentDtos;
using FootballApps.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballApps.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactCommentsController : ControllerBase
    {
        private readonly IContactCommentService _service;

        public ContactCommentsController(IContactCommentService service)
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
        public IActionResult Create([FromBody] CreateContactCommentDto dto)
        {
            var ContactCommentEntity = new ContactComment
            {
                NameSurname = dto.NameSurname,
                Email = dto.Email,
                Subject = dto.Subject,
                Message = dto.Message,
            };
            _service.TAdd(ContactCommentEntity);
            return Ok("İletişim Mesajı Başarıyla Eklendi");
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateContactCommentDto dto)
        {
            var existingContactComment = _service.TGetById(dto.ContactCommentId);
            existingContactComment.NameSurname = dto.NameSurname;
            existingContactComment.Email = dto.Email;
            existingContactComment.Subject = dto.Subject;
            existingContactComment.Message = dto.Message;
            _service.TUpdate(existingContactComment);
            return Ok("İletişim Mesajı Başarıyla Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("İletişim Mesajı Başarıyla Silindi");
        }
    }
}
