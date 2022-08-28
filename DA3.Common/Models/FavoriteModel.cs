namespace DA3.Models
{
    public class FavoriteModel : BaseModel
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }
    }
}