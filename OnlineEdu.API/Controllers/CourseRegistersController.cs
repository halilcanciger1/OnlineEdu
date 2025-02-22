using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseRegisterDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseRegistersController(IGenericService<CourseRegister> genericService, IMapper mapper, ICourseRegisterService courseRegisterService) : ControllerBase
    {
        [HttpGet("GetMyCourses/{userId}")]
        public IActionResult GetMyCourses(int userId)
        {
            var values = courseRegisterService.TGetAllWithCourseAndCategory(x => x.AppUserId == userId);
            var mappedValues = mapper.Map<List<ResultCourseRegisterDto>>(values);
            return Ok(mappedValues);
        }

        [HttpPost]
        public IActionResult Create(CreateCourseRegisterDto createCourseRegisterDto)
        {
            var newValue = mapper.Map<CourseRegister>(createCourseRegisterDto);
            genericService.TCreate(newValue);
            return Ok("Kurs kaydı oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            genericService.TDelete(id);
            return Ok("Kurs kaydı silindi");
        }
        [HttpPut]
        public IActionResult Update(UpdateCourseRegisterDto updateCourseRegisterDto)
        {
            var value = mapper.Map<CourseRegister>(updateCourseRegisterDto);
            genericService.TUpdate(value);
            return Ok("Kurs kaydı güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = genericService.TGetById(id);
            return Ok(value);
        }
    }
}
