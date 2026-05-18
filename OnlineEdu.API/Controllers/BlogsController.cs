using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.BlogDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin, Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IGenericService<Blog> blogService, IMapper mapper, IBlogService blogService1) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]

        public IActionResult Get()
        {
            var values = blogService1.GetBlogsWithCategories();
            return Ok(values);
        }
        [AllowAnonymous]
        [HttpGet("Get4Blogs")]
        public IActionResult Get4Blogs()
        {
            var values = blogService1.TGet4BlogsWithCategories();
            var mappedValues = mapper.Map<List<ResultBlogDto>>(values);
            return Ok(values);
        }
        [AllowAnonymous]
        [HttpGet("GetBlogsByCategoryId{id}")]
        public IActionResult GetBlogsByCategoryId(int id)
        {
            var blogCaunt = blogService1.TGetBlogsByCategoryId(id);
            return Ok(blogCaunt);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = blogService1.TGetBlogWithCategory(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            blogService.TDelete(id);
            return Ok("Blog alanı silindi");
        }

        [HttpPost]

        public IActionResult Create(CreateBlogDto createBlogDto)
        {
            var newValue = mapper.Map<Blog>(createBlogDto);
            blogService.TCreate(newValue);
            return Ok("Yeni Blog alanı oluşturuldu");
        }

        [HttpPut]

        public IActionResult Update(UpdateBlogDto updateBlogDto)
        {
            var value = mapper.Map<Blog>(updateBlogDto);
            blogService.TUpdate(value);
            return Ok("Blog alanı güncellendi");
        }
        [AllowAnonymous]
        [HttpGet("GetBlogByWriterId/{id}")]
        public IActionResult GetBlogByWriterId(int id)
        {
            var value = blogService1.GetBlogsWithCategoriesByWriter(id);
            var mappedValue = mapper.Map<List<ResultBlogDto>>(value);
            return Ok(mappedValue);

        }
        [AllowAnonymous]
        [HttpGet("GetBlogCount")]
        public IActionResult GetBlogCount()
        {
            var value = blogService.TCount();
            return Ok(value);
        }
    }
}
