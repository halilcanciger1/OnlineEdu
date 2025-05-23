﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseCategoryDtos;
using OnlineEdu.DTO.DTOs.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin,Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoryController(IGenericService<CourseCategory> courseCategoryService, IMapper mapper, ICourseCategoryService courseCategoryService1) : ControllerBase
    {
        [AllowAnonymous]
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

        [HttpGet("ShownOnHome/{id}")]
        public IActionResult ShownOnHome(int id)
        {
            courseCategoryService1.TShownOnHome(id);
            return Ok("Anasayfada gösterildi");
        }

        [HttpGet("DontShownOnHome/{id}")]
        public IActionResult DontShownOnHome(int id)
        {
            courseCategoryService1.TDontShownOnHome(id);
            return Ok("Anasayfada gösterilmedi");
        }
        [AllowAnonymous]
        [HttpGet("GetActiveCategories")]
        public IActionResult GetActiveCategories()
        {
            var values = courseCategoryService.TGetFilteredList(x => x.IsShown == true);
            return Ok(values);
        }
        [AllowAnonymous]
        [HttpGet("GetCourseCategoryCount")]
        public IActionResult GetCourseCategoryCount()
        {
            var count = courseCategoryService.TCount();
            return Ok(count);
        }
    }
}
