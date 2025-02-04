using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.SocialMedia;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController(IGenericService<SocialMedia> socialMediaService, IMapper mapper) : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            var values = socialMediaService.TGetList();
            return Ok(values);
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = socialMediaService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            socialMediaService.TDelete(id);
            return Ok("Sosyal medya alanı silindi");
        }

        [HttpPost]

        public IActionResult Create(CreateSocialMediaDto createSocialMediaDto)
        {
            var newValue = mapper.Map<SocialMedia>(createSocialMediaDto);
            socialMediaService.TCreate(newValue);
            return Ok("Yeni sosyal medya alanı oluşturuldu");
        }

        [HttpPut("{id}")]

        public IActionResult Update(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var value = mapper.Map<SocialMedia>(updateSocialMediaDto);
            socialMediaService.TUpdate(value);
            return Ok("Sosyal medya alanı güncellendi");
        }
    }
}
