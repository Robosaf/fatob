using fatob_new.HelperModel;
using fatob_new.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace fatob_new.Controllers
{
    public class BuyTicketController : Controller
    {
        private readonly ITravelRepository _travelRepository;
        private readonly IBusRepository _busRepository;
        private readonly IEmailSenderService _senderService;

        public BuyTicketController(ITravelRepository travelRepository, IBusRepository busRepository,
            IEmailSenderService senderService)
        {
            _travelRepository = travelRepository;
            _busRepository = busRepository;
            _senderService = senderService;
        }
        public async Task<IActionResult> Index(int id)
        {
            var travel = await _travelRepository.GetByIdAsync(id);
            travel.Bus = await _busRepository.GetByIdAsync(travel.BusId);
            TicketBuyerModel model = new TicketBuyerModel();
            model.Travel = travel;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TicketBuyerModel model)
        {
            await _senderService.SendEmailAsync(model);
            return RedirectToAction("Index", "Travel");
        }
    }
}
