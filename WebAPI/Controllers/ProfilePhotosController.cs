using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilePhotosController : ControllerBase
    {
        IProfilePhotoService _profilePhotoService;
        IWebHostEnvironment _webHostEnvironment;

        public ProfilePhotosController(IProfilePhotoService profilePhotoService,IWebHostEnvironment webHostEnvironment)
        {
            _profilePhotoService = profilePhotoService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _profilePhotoService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _profilePhotoService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int id)
        {
            var result = _profilePhotoService.GetByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] ProfilePhoto profilephoto)
        {
            var result = _profilePhotoService.Update(file,profilephoto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("ImageId"))] int id)
        {
            var image = _profilePhotoService.GetById(id);
            var result = _profilePhotoService.Delete(image.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
