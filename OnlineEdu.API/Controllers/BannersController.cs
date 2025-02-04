
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.BannerDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IGenericService<Banner> bannerService, IMapper mapper) : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            var values = bannerService.TGetList();
            return Ok(values);
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = bannerService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            bannerService.TDelete(id);
            return Ok("Hakkımızda alanı silindi");
        }

        [HttpPost]

        public IActionResult Create(CreateBannerDto createBannerDto)
        {
            var newValue = mapper.Map<Banner>(createBannerDto);
            bannerService.TCreate(newValue);
            return Ok("Yeni hakkımızda alanı oluşturuldu");
        }

        [HttpPut]

        public IActionResult Update(UpdateBannerDto updateBannerDto)
        {
            var value = mapper.Map<Banner>(updateBannerDto);
            bannerService.TUpdate(value);
            return Ok("Hakkımızda alanı güncellendi");
        }
    }
}
