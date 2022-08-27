using DA3.Common;

namespace DA3.Models
{
    public class StoreModel : BaseModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string StartTimeNormal { get; set; }

        public string EndTimeNormal { get; set; }

        public string StartTimeHoliday { get; set; }

        public string EndTimeHoliday { get; set; }
    }
}