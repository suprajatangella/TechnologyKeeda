using Microsoft.AspNetCore.Mvc;

namespace TechnologyKeeda.Web.Controllers
{
    public class TestController : Controller
    {
        static int inc = 0;
        public IActionResult ShowButton()
        {
            return View();
        }

        public IActionResult ClickButton()
        {
            inc++;
            return View("ShowButton", inc);
        }
    }
}
