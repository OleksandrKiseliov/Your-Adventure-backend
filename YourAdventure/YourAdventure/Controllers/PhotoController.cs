using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using YourAdventure.Models;
using System;
using YourAdventure.BusinessLogic.Services.Interfaces;

namespace YourAdventure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoGenerator _photoGenerator;

        public PhotoController(IPhotoGenerator photoGenerator)
        {
            _photoGenerator = photoGenerator;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadPhoto([FromForm] FileUploadViewModel model, int countryFId, int personFId)
        {
            var photo = await _photoGenerator.UploadPhoto(model, countryFId, personFId);
            return Ok(photo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var photoBytes = await _photoGenerator.GetPhoto(id);
            return Ok(photoBytes);  
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletePhoto(int Id)
        {
            await _photoGenerator.DeletePhoto(Id);
            return Ok(Id);
        }
    }
}
