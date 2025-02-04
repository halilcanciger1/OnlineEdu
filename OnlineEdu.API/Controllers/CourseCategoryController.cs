using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseCategoryDtos;
using OnlineEdu.DTO.DTOs.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoryController(IGenericService<CourseCategory> courseCategoryService, IMapper mapper) : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            var values = courseCategoryService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = courseCategoryService.TGetById(id);
            return Ok(value);
        }
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            courseCategoryService.TDelete(id);
            return Ok("Kurs alanı silindi");
        }

        [HttpPost]

        public IActionResult Create(CreateCourseCategoryDto createCourseCategoryDto)
        {
            var newValue = mapper.Map<CourseCategory>(createCourseCategoryDto);
            courseCategoryService.TCreate(newValue);
            return Ok("Yeni kurs alanı oluşturuldu");
        }

        [HttpPut]

        public IActionResult Update(UpdateCourseCategoryDto updateCourseCategoryDto)
        {
            var value = mapper.Map<CourseCategory>(updateCourseCategoryDto);
            courseCategoryService.TUpdate(value);
            return Ok("Kurs alanı güncellendi");
        }
    }
}
