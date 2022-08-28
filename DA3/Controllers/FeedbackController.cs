using DA3.Models;
using DA3.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace DA3.Controler
{
    public class FeedbackController : Controller
    {

        private readonly IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        public IActionResult Admin()
        {
            var feedbackModels = _feedbackService.GetAllFeedbacks();
            var model = new FeedbackViewModel
            {
                feedbacks = feedbackModels
            };

            return View(model);
        }

        public IActionResult HandelSaveChange(ContactViewModel contactViewModel)
        {
            var model = contactViewModel.FeedbackModel;
            _feedbackService.SaveChange(model);
            return RedirectToAction("Index", "Contact");
        }

    }
}
