using fatob_new.HelperModel;
using fatob_new.Interfaces;
using fatob_new.Models;
using Microsoft.AspNetCore.Mvc;

namespace fatob_new.Controllers
{
    public class FindATravelController : Controller
    {
        private readonly ITravelRepository _travelRepository;

        public FindATravelController(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            TravelFindModel findTravelModel = new TravelFindModel();
            findTravelModel.Travels = await _travelRepository.GetAll();
            return View(findTravelModel);
        }

        [HttpPost, ActionName("Index")]
        public async Task<IActionResult> IndexTravels(TravelFindModel findTravelModel)
        {
            IEnumerable<Travel> travels = await _travelRepository.GetByCities(findTravelModel.CityFrom,
                findTravelModel.CityTo, findTravelModel.DateFrom);

            findTravelModel.Travels = travels;

            return View(findTravelModel);
        }
    }
}
