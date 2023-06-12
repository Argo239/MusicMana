using Microsoft.AspNetCore.Mvc;
using MusicManaApi.DataAccess;
using MusicManaApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicManaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainCotroller : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly MainService _mainService;

        public MainCotroller(AppDbContext appDbContext, MainService mainService)
        {
            _appDbContext = appDbContext;
            _mainService = mainService;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllAlbum(int? pageIndex, int? pageSize)
        {
            return Ok(await _mainService.getAllAlbum(pageIndex, pageSize, _appDbContext));
        }
    }
}
