using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IGenericService<About> aboutService, IMapper mapper) : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            var values = aboutService.TGetList();
            return Ok(values);
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = aboutService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            aboutService.TDelete(id);
            return Ok("Hakkımızda alanı silindi");
        }

        [HttpPost]

        public IActionResult Create(CreateAboutDto createAboutDto)
        {
            var newValue = mapper.Map<About>(createAboutDto);
            aboutService.TCreate(newValue);
            return Ok("Yeni hakkımızda alanı oluşturuldu");
        }

        [HttpPut]

        public IActionResult Update(UpdateAboutDto updateAboutDto)
        {
            var value = mapper.Map<About>(updateAboutDto);
            aboutService.TUpdate(value);
            return Ok("Hakkımızda alanı güncellendi");
        }
    }
}
