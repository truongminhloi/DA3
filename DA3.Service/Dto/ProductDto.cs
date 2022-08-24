using DA3.Common;

namespace DA3.Service.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public string Url { get; set; }

        public decimal Price { get; set; }

        public string Describe { get; set; }

        public string Color { get; set; }

        public Status Status { get; set; }
    }
}
