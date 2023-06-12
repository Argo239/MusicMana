using Microsoft.AspNetCore.Mvc;
using MusicManaApi.DataAccess;

namespace MusicManaApi.Interface
{
    public interface IMainService
    {
        Task<string> getAllAlbum(int? pageIndex, int? pageSize, AppDbContext _appDbContext);
    }
}
