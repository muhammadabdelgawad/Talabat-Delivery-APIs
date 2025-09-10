namespace Talabat.Application.Abstraction.Models.Products
{
    public record ProductSpecParams
    {
        public string?  Sort { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int PageIndex { get; set; }
        private const int maxPageSize = 50;
        private int pageSize;
        public int PageSize
        {
            get => pageSize;
            set { PageSize = value > maxPageSize ? maxPageSize : value; }
        }
    }
}
