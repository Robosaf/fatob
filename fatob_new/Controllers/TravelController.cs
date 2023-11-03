using fatob_new.Data;
using fatob_new.Interfaces;
using fatob_new.Models;
using Microsoft.AspNetCore.Mvc;

namespace fatob_new.Controllers
{
    public class TravelController : Controller
    {
        private readonly ITravelRepository _travelRepository;
        private readonly IBusRepository _busRepository;
        private int _idToDelete;
        public TravelController(ITravelRepository travelRepository, IBusRepository busRepository)
        {
            _travelRepository = travelRepository;
            _busRepository = busRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Travel> travels = await _travelRepository.GetAll();
            return View(travels);
        }

        public async Task<IActionResult> TravelDetail(int id)
        {
            Travel travel = await _travelRepository.GetByIdAsync(id);
            travel.Bus = await _busRepository.GetByIdAsync(travel.BusId);
            return View(travel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Travel travel)
        {
            if (!ModelState.IsValid)
            {
                return View(travel);
            }

            _travelRepository.AddTravel(travel);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(int id)
        {
            var travel = await _travelRepository.GetByIdAsync(id);
            var bus = await _busRepository.GetByIdAsync(travel.BusId);
            travel.Bus = bus;
            
            if (travel == null)
            {
                return View("Error");
            }

            return View(travel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Travel travel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit travel");
                return View("Edit", travel);
            }

            var travelToUpdate = new Travel()
            {
                TravelId = id,
                StartCity = travel.StartCity,
                EndCity = travel.EndCity,
                BusId  = travel.BusId,
                Bus = travel.Bus,
                StartOfTravel = travel.StartOfTravel,
                EndOfTravel = travel.EndOfTravel,
                Cost = travel.Cost
            };


            _travelRepository.UpdateTravel(travelToUpdate);

            return RedirectToAction("Index");

            
        }


        public async Task<IActionResult> Delete(int id)
        {
            var travel = await _travelRepository.GetByIdAsync(id);
            var bus = await _busRepository.GetByIdAsync(travel.BusId);
            travel.Bus = bus;

            if (travel == null) return View("Error");

            return View(travel);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteTravel(int id)
        {
            var travel = await _travelRepository.GetByIdAsync(id);
            var bus = await _busRepository.GetByIdAsync(travel.BusId);
            travel.Bus = bus;

            if (travel == null) return View("Error");

            _travelRepository.DeleteTravel(travel);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetTicket()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetTicket(string email)
        {
            return View();
        }
    }
}
