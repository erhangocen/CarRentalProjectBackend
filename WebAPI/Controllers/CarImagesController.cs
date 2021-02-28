using Business.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImagesService;
        IWebHostEnvironment _webHostEnvironment;

        public CarImagesController(ICarImageService carImagesService,IWebHostEnvironment webHostEnvironment )
        {
            _carImagesService = carImagesService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImagesService.GetAll();

            if (result.Success)
            {
               return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImagesService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int id)
        {
            var result = _carImagesService.GetByCarId(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddAsync([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImagesService.Add(file,carImage);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult GetByCarId([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImagesService.Update(file,carImage);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("ImageId"))] int id)
        {
            var image = _carImagesService.GetById(id).Data;
            var result = _carImagesService.Delete(image);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
