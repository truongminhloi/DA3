namespace DA3.Service.Request
{
    public class BaseProductRequest
    {
        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public string Url { get; set; }

        public decimal Price { get; set; }

        public string Describe { get; set; }

        public string Color { get; set; }

        public int Status { get; set; }
    }
}
