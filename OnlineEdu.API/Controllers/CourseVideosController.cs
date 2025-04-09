using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseVideoDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseVideosController(IGenericService<CourseVideo> courseVideoService, IMapper mapper) : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            var values = courseVideoService.TGetList();
            return Ok(values);
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = courseVideoService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            courseVideoService.TDelete(id);
            return Ok("Hakkımızda alanı silindi");
        }
        [HttpPost]

        public IActionResult Create(CreateCourseVideoDto createcourseVideoDto)
        {
            var newValue = mapper.Map<CourseVideo>(createcourseVideoDto);
            courseVideoService.TCreate(newValue);
            return Ok("Yeni hakkımızda alanı oluşturuldu");
        }

        [HttpPut]

        public IActionResult Update(UpdateCourseVideoDto updatecourseVideoDto)
        {
            var value = mapper.Map<CourseVideo>(updatecourseVideoDto);
            courseVideoService.TUpdate(value);
            return Ok("Hakkımızda alanı güncellendi");
        }

        [HttpGet("GetCourseVideosByCourseId/{id}")]
        public IActionResult GetCourseVideosByCourseId(int id)
        {
            var values = courseVideoService.TGetFilteredList(x => x.CourseId == id);
            return Ok(values);
        }
    }
}
