using ConcertBooking.Entities;
using ConcertBooking.Repositories.Interfaces;
using ConcertBooking.WebHost.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConcertBooking.WebHost.Controllers
{
    public class ConcertsController : Controller
    {
        private readonly IConcertRepo _concertRepo;
        private readonly IVenueRepo _venueRepo;
        private readonly IArtistRepo _artistRepo;
        private readonly IUtilityRepo _utilityRepo;
        private string containerName = "ConcertImage";
        private readonly IBookingRepo _bookingRepo;
        public ConcertsController(IConcertRepo concertRepo, IVenueRepo venueRepo, IArtistRepo artistRepo, IUtilityRepo utilityRepo, IBookingRepo bookingRepo)
        {
            _concertRepo = concertRepo;
            _venueRepo = venueRepo;
            _artistRepo = artistRepo;
            _utilityRepo = utilityRepo;
            _bookingRepo = bookingRepo;
        }

        public async Task<IActionResult> Index()
        {
                List<ConcertViewModel> vmList = new List<ConcertViewModel>();
                var concerts = await _concertRepo.GetAll();
                foreach (var concert in concerts)
                {
                    vmList.Add(new ConcertViewModel
                    {
                        Id = concert.Id,
                        Name = concert.Name,
                        DateTime = concert.DateTime,
                        ArtistName = concert.Artist.Name,
                        VenueName = concert.Venue.Name
                    });
                }
                return View(vmList);
        }

        public async Task<IActionResult> Create()
        {
            var artists = await _artistRepo.GetAll();
            var venues = await _venueRepo.GetAll();
            ViewBag.artistList = new SelectList(artists, "Id", "Name");
            ViewBag.VenuesList = new SelectList(venues, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateConcertViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var concert = new Concert {
                    Name = vm.Name,
                    Description = vm.Description,
                    DateTime = vm.DateTime,
                    VenueId = vm.VenueId,
                    ArtistId = vm.ArtistId
                };

                if (vm.ImageUrl != null)
                {
                    concert.ImageUrl = await _utilityRepo.SaveImage(containerName, vm.ImageUrl);
                }

                await _concertRepo.Save(concert);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var concert = await _concertRepo.GetById(id);

            var artists = await _artistRepo.GetAll();
            var venues = await _venueRepo.GetAll();
            ViewBag.artistList = new SelectList(artists, "Id", "Name");
            ViewBag.VenuesList = new SelectList(venues, "Id", "Name");

            var vm = new EditConcertViewmodel
            {
                Id = concert.Id,
                Name = concert.Name,
                DateTime = concert.DateTime,
                Description = concert.Description,
                VenueId = concert.VenueId,
                ArtistId = concert.ArtistId,
                ImageUrl = concert.ImageUrl
            };

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditConcertViewmodel vm)
        {
            var concert = await _concertRepo.GetById(vm.Id);

            concert.Id = vm.Id;
            concert.Name = vm.Name;
            concert.Description = vm.Description;
            concert.DateTime = vm.DateTime;
            concert.ArtistId = vm.ArtistId;
            concert.VenueId = vm.VenueId;

            if (vm.ChooseImage != null)
            {
                concert.ImageUrl = await _utilityRepo.EditImage(containerName, vm.ChooseImage, concert.ImageUrl);
            }

            await _concertRepo.Edit(concert); 
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var concert = await _concertRepo.GetById(id);
            await _concertRepo.Delete(concert);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets(int id)
        {
            var bookings = await _bookingRepo.GetAll(id);
            var vm = bookings.Select(b => new DashboardViewModel
            {
                UserName = b.User.UserName,
                ConcertName = b.Concert.Name,
                SeatNumber = string.Join(",", b.Tickets.Select(t=> t.SeatNumber))
            }).ToList();
            return View(vm);
        }
    }
}
