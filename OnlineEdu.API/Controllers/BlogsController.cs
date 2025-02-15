using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.BlogDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IGenericService<Blog> blogService, IMapper mapper, IBlogService blogService1) : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            var values = blogService1.GetBlogsWithCategories();
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

        [HttpGet("GetBlogByWriterId/{id}")]
        public IActionResult GetBlogByWriterId(int id)
        {
            var value = blogService1.GetBlogsWithCategoriesByWriter(id);
            var mappedValue = mapper.Map<List<ResultBlogDto>>(value);
            return Ok(mappedValue);

        }
    }
}
