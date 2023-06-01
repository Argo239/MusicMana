using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MusicMana.Models;
using MusicManaApi.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicManaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainCotroller : ControllerBase
    {

        AppDbContext _appDbContext = new AppDbContext();

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var json = JsonConvert.SerializeObject(new { Album = _appDbContext.Albums.ToList() });
            return await Task.FromResult(Ok(json));
        }

        // GET api/<MainCotroller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MainCotroller>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MainCotroller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MainCotroller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
