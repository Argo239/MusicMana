﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicMana.Models;
using MusicManaApi.BLL;
using MusicManaApi.DAL;
using MusicManaApi.Data;
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

            int skip = (int)Tools.GetPageIndex(pageIndex);
            int take = (int)Tools.GetPageSize(pageSize);

            var json = JsonConvert.SerializeObject(_appDbContext.Albums
                .Where(album => album.Singer != null)
                .OrderBy(album => album.Id)
                .Skip(skip)
                .Take(take)
                .Select(album => new
                {
                    Id = album.Id,
                    AlbumName = album.AlbumName,
                    SingerName = album.Singer.Sname,
                    SingerArea = album.Singer.Area
                })
                .ToList());

            return await Task.FromResult(Ok(json));

            //var json = JsonConvert.SerializeObject(_appDbContext.Albums
            //    .Where(album => album.Singer != null)
            //    .OrderBy(album => album.Id)
            //    .Skip(skip)
            //    .Take(take)
            //    .Select(album => new
            //    {
            //        Id = album.Id,
            //        AlbumName = album.AlbumName,
            //        SingerName = album.Singer.Sname,
            //        SingerArea = album.Singer.Area
            //    })
            //    .ToList());
            //return await Task.FromResult(Ok(json));
        }
        //return await Task.FromResult(Ok(_mainService.GetAllAlbum(pageIndex, pageSize, _appDbContext)));
    }
}
