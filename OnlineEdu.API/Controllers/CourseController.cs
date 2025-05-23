﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(IGenericService<Course> courseService, IMapper mapper, ICourseService courseService1) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]

        public IActionResult Get()
        {
            var values = courseService1.TGetAllCoursesWithCategories();
            var mappedValues = mapper.Map<List<ResultCourseDto>>(values);
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

        [HttpGet("ShownOnHome/{id}")]
        public IActionResult ShownOnHome(int id)
        {
            courseService1.TShownOnHome(id);
            return Ok("Anasayfada gösterildi");
        }

        [HttpGet("DontShownOnHome/{id}")]
        public IActionResult DontShownOnHome(int id)
        {
            courseService1.TDontShownOnHome(id);
            return Ok("Anasayfada gösterilmedi");
        }

        [HttpGet("GetActiveCourses")]
        public IActionResult GetActiveCourses()
        {
            var values = courseService.TGetFilteredList(x => x.IsShown == true);
            return Ok(values);
        }

        [HttpGet("GetCoursesByTeacherId/{id}")]
        public IActionResult GetCoursesByTeacherId(int id)
        {
            var values = courseService1.GetCoursesByTeacherId(id);
            var mappedValues = mapper.Map<List<ResultCourseDto>>(values);
            return Ok(mappedValues);
        }
        [HttpGet("GetCourseCount")]
        public IActionResult GetCourseCount()
        {
            var count = courseService.TCount();
            return Ok(count);
        }

        [HttpGet("GetCoursesByCategoryId/{id}")]
        public IActionResult GetCoursesByCategoryId(int id)
        {
           var values = courseService1.TGetAllCoursesWithCategories(x => x.CourseCategoryId == id);
            return Ok(values);
        }
    }
}
