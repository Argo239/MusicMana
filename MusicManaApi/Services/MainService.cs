using MusicMana.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using MusicManaApi.Utils;
using MusicManaApi.DataAccess;
using Microsoft.EntityFrameworkCore;
using MusicManaApi.Interface;

namespace MusicManaApi.Services
{
    public class MainService : IMainService
    {
        public async Task<string> getAllAlbum(int? pageIndex, int? pageSize, AppDbContext _appDbContext)
        {
            int skip = (int)Tools.GetPageIndex(pageIndex);
            int take = (int)Tools.GetPageSize(pageSize);

            var json = await _appDbContext.Albums
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
                .ToListAsync();
            return JsonConvert.SerializeObject(json);
        }
    }
}
