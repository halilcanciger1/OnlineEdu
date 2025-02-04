using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.MassageDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController(IGenericService<Message> messageService, IMapper mapper) : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            var values = messageService.TGetList();
            return Ok(values);
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = messageService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            messageService.TDelete(id);
            return Ok("Mesaj alanı silindi");
        }
        [HttpPost]

        public IActionResult Create(CreateMassageDto createMessageDto)
        {
            var newValue = mapper.Map<Message>(createMessageDto);
            messageService.TCreate(newValue);
            return Ok("Yeni Mesaj alanı oluşturuldu");
        }

        [HttpPut]

        public IActionResult Update(UpdateMassageDto updateMessageDto)
        {
            var value = mapper.Map<Message>(updateMessageDto);
            messageService.TUpdate(value);
            return Ok("Mesaj alanı güncellendi");
        }
    }
}
