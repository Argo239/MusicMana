namespace MusicManaApi.Utils
{
    public class Tools
    {
        public static int GetPageIndex(int? pageIndex)
        {
            if (pageIndex == null || pageIndex < 0)
                pageIndex = 1;
            int _pageIndex = (int)pageIndex;
            return (_pageIndex - 1) * 5;
        }

        public static int GetPageSize(int? pageSize)
        {
            if (pageSize == null || pageSize <= 0)
                pageSize = 5;
            return (int)pageSize;
        }
    }
}
