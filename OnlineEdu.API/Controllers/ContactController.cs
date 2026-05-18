using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.ContactDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController(IGenericService<Contact> contactService, IMapper mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]

        public IActionResult Get()
        {
            var values = contactService.TGetList();
            return Ok(values);
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = contactService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            contactService.TDelete(id);
            return Ok("Blog alanı silindi");
        }

        [HttpPost]

        public IActionResult Create(CreateContactDto createContactDto)
        {
            var newValue = mapper.Map<Contact>(createContactDto);
            contactService.TCreate(newValue);
            return Ok("Yeni Blog alanı oluşturuldu");
        }

        [HttpPut]

        public IActionResult Update(UpdateContactDto updateContactDto)
        {
            var value = mapper.Map<Contact>(updateContactDto);
            contactService.TUpdate(value);
            return Ok("Blog alanı güncellendi");
        }
    }
}
