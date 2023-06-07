using MusicMana.Models;
using MusicManaApi.Data;
using MusicManaApi.Utils;
using Newtonsoft.Json;

namespace MusicManaApi.DAL
{
    public class MainDAL
    {
        public static string getAllAlbum(int? pageIndex, int? pageSize, AppDbContext _appDbContext)
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
            return json;





            //var json = await Task.Run(() =>
            //{
            //    return JsonConvert.SerializeObject(_appDbContext.Albums
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
            //});
        }
    }
}
