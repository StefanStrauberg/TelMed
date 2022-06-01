namespace BaseDomain.Specs
{
    public class QuerySpecParams
    {
        private const int maxPageSize = 50;
        private int _pageSize = 10;
        private string _search;
        public int PageIndex { get; set; } = 1;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
        public string Search { get => _search; set => _search = value.ToLower(); }
        public string Sort { get; set; }
    }
}
