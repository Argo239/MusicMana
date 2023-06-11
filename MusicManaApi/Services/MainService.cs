using MusicMana.Models;
using MusicManaApi.Data;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using MusicManaApi.Utils;
using MusicManaApi.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace MusicManaApi.Services
{
    public class MainService : IMainService
    {
        public async Task<string> getAllAlbum(int? pageIndex, int? pageSize, AppDbContext _appDbContext)
        {
            int skip = (int)Tools.GetPageIndex(pageIndex);
            int take = (int)Tools.GetPageSize(pageSize);

            return await MainD.getAllAlbum(skip, take, _appDbContext); 
        }
    }
}
