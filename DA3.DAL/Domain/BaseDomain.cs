namespace DA3.DAL.Domain
{
    public class BaseDomain
    {
        public string? CreateBy { get; set; }

        public string? UpdateBy { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }
    }
}
