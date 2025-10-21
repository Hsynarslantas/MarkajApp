using FootballApps.BusinessLayer.Abstract;
using FootballApps.DtoLayer.Dtos.ContactDtos;
using FootballApps.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballApps.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
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
        public IActionResult Create([FromBody] CreateContactDto dto)
        {
            var ContactEntity = new Contact
            {
                Address = dto.Address,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
            };
            _service.TAdd(ContactEntity);
            return Ok("İletişim Bilgisi Başarıyla Eklendi");
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateContactDto dto)
        {
            var existingContact = _service.TGetById(dto.ContactId);
            existingContact.Address = dto.Address;
            existingContact.Email = dto.Email;
            existingContact.PhoneNumber = dto.PhoneNumber;
            _service.TUpdate(existingContact);
            return Ok("İletişim Bilgisi Başarıyla Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("İletişim Bilgisi Başarıyla Silindi");
        }
    }
}
