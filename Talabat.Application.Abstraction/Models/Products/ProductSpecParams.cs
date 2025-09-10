namespace Talabat.Application.Abstraction.Models.Products
{
    public record ProductSpecParams
    {
        public string?  Sort { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int PageIndex { get; set; }=1;
        private const int maxPageSize = 100;
        private int pageSize = 10;
        public int PageSize
        {
            get => pageSize;
            set => pageSize = value > maxPageSize ? maxPageSize : value; 
        }
    }
}
