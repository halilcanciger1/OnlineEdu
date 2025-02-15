using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.TeacherSocialDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherSocialsController(IGenericService<TeacherSocial> teacherSocialService, IMapper mapper) : ControllerBase
    {
        [HttpGet("ByTeacherId{id}")]
        public IActionResult GetSocialByTeacherId(int id)
        {
            var values = teacherSocialService.TGetFilteredList(x => x.TeacherId == id );
            return Ok(values);
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = teacherSocialService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            teacherSocialService.TDelete(id);
            return Ok("Öğretmen sosyal media alanı silindi");
        }

        [HttpPost]

        public IActionResult Create(CreateTeacherSocialDto createTeacherSocialDto)
        {
            var newValue = mapper.Map<TeacherSocial>(createTeacherSocialDto);
            teacherSocialService.TCreate(newValue);
            return Ok("Yeni Öğretmen sosyal media alanı oluşturuldu");
        }

        [HttpPut]

        public IActionResult Update(UpdateTeacherSocialDto updateTeacherSocialDto)
        {
            var value = mapper.Map<TeacherSocial>(updateTeacherSocialDto);
            teacherSocialService.TUpdate(value);
            return Ok("Öğretmen sosyal media alanı güncellendi");
        }
    }
}
