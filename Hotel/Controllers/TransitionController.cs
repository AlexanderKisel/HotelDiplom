using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers
{
    public class TransitionController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
        public IActionResult AutorizationPage()
        {
            return View();
        }
        public IActionResult RegisterPage()
        {
            return View();
        }
        public IActionResult QandAPage()
        {
            return View();
        }
        public IActionResult RoomsPage()
        {
            return View();
        }
        public IActionResult MenuPage()
        {
            return View();
        }

        public IActionResult BookingPage()
        {
            return View();
        }

        public IActionResult MyBooking()
        {
            return View();
        }
    }
}
