using Microsoft.AspNetCore.Mvc;
using MusicManaApi.DataAccess;
using MusicManaApi.Data;

namespace MusicManaApi.Services
{
    public interface IMainService {

        Task<string> getAllAlbum(int? pageIndex, int? pageSize, AppDbContext _appDbContext);

    }
}
