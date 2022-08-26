namespace DA3.Models
{
    public class BaseModel
    {
        public string? CreateBy { get; set; }

        public string? UpdateBy { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }
    }
}