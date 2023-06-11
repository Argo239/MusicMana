using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicMana.Models;
using MusicManaApi.DataAccess;
using MusicManaApi.Data;
using MusicManaApi.Services;
using MusicManaApi.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Org.BouncyCastle.Crypto.Tls;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicManaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainCotroller : ControllerBase
    {
        AppDbContext _appDbContext = new AppDbContext();
        MainService _mainService = new MainService();

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllAlbum(int? pageIndex, int? pageSize)
        {
            return Ok(await _mainService.getAllAlbum(pageIndex, pageSize, _appDbContext));
        }
    }
}
