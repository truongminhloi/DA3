using DA3.Models;

namespace DA3.Service.Contract
{
    public interface IFeedbackService
    {
        List<FeedbackModel> GetAllFeedbacks();

        string SaveChange(FeedbackModel model);
    }
}
