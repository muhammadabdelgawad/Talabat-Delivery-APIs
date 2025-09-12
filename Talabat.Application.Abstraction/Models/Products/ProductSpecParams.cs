namespace Talabat.Application.Abstraction.Models.Products
{
    public record ProductSpecParams
    {
        public string? Sort { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int PageIndex { get; set; } = 1;
        private const int maxPageSize = 100;
        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > maxPageSize ? maxPageSize : value;
        }

        private string? _search;
        public string? Search
        {
            get => _search;
            set => _search = value?.ToUpper();
        }



    }
}
