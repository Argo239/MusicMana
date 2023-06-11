using Microsoft.EntityFrameworkCore;
using MusicMana.Models;
using MusicManaApi.Data;
using MusicManaApi.Utils;
using Newtonsoft.Json;

namespace MusicManaApi.DataAccess
{
    public class MainD
    {
        public static async Task<string> getAllAlbum(int skip, int take, AppDbContext _appDbContext)
        {
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
