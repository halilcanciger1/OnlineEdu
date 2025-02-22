using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.TestimonialDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController(IGenericService<Testimonial> testimonialService, IMapper mapper) : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            var values = testimonialService.TGetList();
            return Ok(values);
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = testimonialService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            testimonialService.TDelete(id);
            return Ok("Testimonial alanı silindi");
        }

        [HttpPost]

        public IActionResult Create(CreateTestimonialDto createTestimonialDto)
        {
            var newValue = mapper.Map<Testimonial>(createTestimonialDto);
            testimonialService.TCreate(newValue);
            return Ok("Yeni Testimonial alanı oluşturuldu");
        }

        [HttpPut]

        public IActionResult Update(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = mapper.Map<Testimonial>(updateTestimonialDto);
            testimonialService.TUpdate(value);
            return Ok("Testimonial alanı güncellendi");
        }
        [HttpGet("GetTestimonialCount")]
        public IActionResult GetTestimonialCount()
        {
            var count = testimonialService.TCount();
            return Ok(count);
        }
    }
}
