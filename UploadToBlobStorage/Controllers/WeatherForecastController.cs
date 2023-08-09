using Microsoft.AspNetCore.Mvc;
using UploadToBlobStorage.Models;
using UploadToBlobStorage.Validator;

namespace UploadToBlobStorage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpPost("UploadFiles")]
        public async Task<IActionResult> UploadFiles([FromForm] FileUploadRequest fileUploadRequest)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("UploadFiles2")]
        public async Task<IActionResult> UploadFiles2([FromForm] FileUploadRequest fileUploadBaseRequest)
        {
            try
            {
                IFormFileCollection file = HttpContext.Request.Form.Files;
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("UploadFiles22")]
        public async Task<IActionResult> Upload22(
     Sample value,
    IList<IFormFile> files)
        {
            var validator = new CustomerValidator();
            var result = await validator.ValidateAsync(value);

            if (!result.IsValid)
            {
                return BadRequest(string.Join("", result.Errors.Select(i => i.ErrorMessage)));
            }
            // Use serialized json object 'value'
            // Use uploaded 'files'
            return Ok();
        }
    }
}