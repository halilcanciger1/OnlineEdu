using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.SubscriberDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController(IGenericService<Subscriber> subscriberService, IMapper mapper) : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            var values = subscriberService.TGetList();
            return Ok(values);
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = subscriberService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            subscriberService.TDelete(id);
            return Ok("Abonelik alanı silindi");
        }

        [HttpPost]

        public IActionResult Create(CreateSubscriberDto createSubscriberDto)
        {
            var newValue = mapper.Map<Subscriber>(createSubscriberDto);
            subscriberService.TCreate(newValue);
            return Ok("Yeni Abonelik alanı oluşturuldu");
        }

        [HttpPut]

        public IActionResult Update(UpdateSubscriberDto updateSubscriberDto)
        {
            var value = mapper.Map<Subscriber>(updateSubscriberDto);
            subscriberService.TUpdate(value);
            return Ok("Abonelik alanı güncellendi");
        }
    }
}
