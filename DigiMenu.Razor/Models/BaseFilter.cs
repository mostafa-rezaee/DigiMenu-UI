namespace DigiMenu.Razor.Models
{
    public class BaseFilter
    {
        public int EntityCount { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageCount { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public int Take { get; private set; }
    }

    public class BaseFilter<TData, TParam> : BaseFilter
    where TParam : BaseFilterParam
    where TData : BaseModel
    {
        public List<TData> Data { get; set; }
        public TParam FilterParams { get; set; }
    }

    public class BaseFilterParam
    {
        public int PageNumber { get; set; } = 1;
        public int PageCount { get; set; } = 50;
    }
}
