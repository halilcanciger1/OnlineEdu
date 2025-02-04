using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(IGenericService<Course> courseService, IMapper mapper) : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            var values = courseService.TGetList();
            return Ok(values);
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = courseService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            courseService.TDelete(id);
            return Ok("Kurs alanı silindi");
        }

        [HttpPost]

        public IActionResult Create(CreateCourseDto createCourseDto)
        {
            var newValue = mapper.Map<Course>(createCourseDto);
            courseService.TCreate(newValue);
            return Ok("Yeni kurs alanı oluşturuldu");
        }

        [HttpPut]

        public IActionResult Update(UpdateCourseDto updateCourseDto)
        {
            var value = mapper.Map<Course>(updateCourseDto);
            courseService.TUpdate(value);
            return Ok("Kurs alanı güncellendi");
        }
    }
}
