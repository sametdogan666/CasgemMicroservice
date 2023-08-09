using CasgemMicroservice.Services.PhotoStock.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoStocksController : ControllerBase
    {
        [HttpPost("save-photo")]
        public async Task<IActionResult> SavePhoto(IFormFile? formFile, CancellationToken cancellationToken)
        {

            if (formFile != null && formFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", formFile.FileName);
                await using var stream = new FileStream(path, FileMode.Create);
                await formFile.CopyToAsync(stream, cancellationToken);
                var returnPath = formFile.FileName;
                PhotoDto photo = new PhotoDto()
                {
                    ImageUrl = returnPath
                };

                return Ok("Fotoğraf oluşturuldu");
            }

            return Ok("Fotoğraf oluşturulurken hata oluştu!");
        }
    }
}
