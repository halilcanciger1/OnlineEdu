using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.BlogCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin,Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoryController(IBlogCategoryService blogService, IMapper mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]

        public IActionResult Get()
        {
            var values = blogService.TGetBlogCategoriesWithBlog();
            return Ok(values);
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = blogService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            blogService.TDelete(id);
            return Ok("Blog Kategori alanı silindi");
        }

        [HttpPost]

        public IActionResult Create(CreateBlogCategoryDto createBlogCategoryDto)
        {
            var newValue = mapper.Map<BlogCategory>(createBlogCategoryDto);
            blogService.TCreate(newValue);
            return Ok("Yeni Blog Kategori alanı oluşturuldu");
        }

        [HttpPut]

        public IActionResult Update(UpdateBlogCategoryDto updateBlogCategoryDto)
        {
            var value = mapper.Map<BlogCategory>(updateBlogCategoryDto);
            blogService.TUpdate(value);
            return Ok("Blog Kategori alanı güncellendi");
        }
    }
}
