using DigiMenu.Razor.Models;

namespace DigiMenu.Razor.Infrastructure
{
    public static class UrlQueryGenerator
    {
        public static string GenerateBaseFilterUrl(this BaseFilterParam filterParam, string moduleName)
        {
            return $"{moduleName}?page={filterParam.PageNumber}&take={filterParam.PageCount}";
        }
    }
}
