using Microsoft.AspNetCore.Mvc;
using WEB_Lab_2.Models;

namespace WEB_Lab_2.Controllers
{
    public class CalcServiceController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult ManualParsingSingle()
        {
            if (Request.Method == "POST")
            {
                try
                {
                    var calc = new CalcModel
                    {
                        X = Int32.Parse(HttpContext.Request.Form["x"]),
                        operation = HttpContext.Request.Form["operation"],
                        Y = Int32.Parse(HttpContext.Request.Form["y"])
                    };

                    ViewBag.Result = calc.Calc();
                }
                catch
                {
                    ViewBag.Result = "Invalid input";
                }

                return View("Result");
            }
            return View("Window");
        }



        [HttpGet]
        [ActionName("ManualParsingSeparate")]
        public IActionResult ManualParsingSeparateGet()
        {
            return View("Window");
        }
        [HttpPost]
        [ActionName("ManualParsingSeparate")]
        public IActionResult ManualParsingSeparatePost()
        {
            try
            {
                var calc = new CalcModel
                {
                    X = Int32.Parse(HttpContext.Request.Form["x"]),
                    operation = HttpContext.Request.Form["operation"],
                    Y = Int32.Parse(HttpContext.Request.Form["y"])
                };

                ViewBag.Result = calc.Calc();
            }
            catch
            {
                ViewBag.Result = "Invalid input";
            }

            return View("Result");
        }



        [HttpGet]
        public IActionResult ModelBindingParameters()
        {
            return View("Window");
        }
        [HttpPost]
        public IActionResult ModelBindingParameters(int x, string operation, int y)
        {
            if (ModelState.IsValid)
            {
                var calc = new CalcModel
                {
                    X = x,
                    operation = operation,
                    Y = y
                };
                ViewBag.Result = calc.Calc();
            }
            else
            {
                ViewBag.Result = "Invalid input";
            }

            return View("Result");
        }



        [HttpGet]
        public IActionResult ModelBindingSeparate()
        {
            return View("Window");
        }
        [HttpPost]
        public IActionResult ModelBindingSeparate(CalcModel model)
        {
            ViewBag.Result = ModelState.IsValid
                ? model.Calc()
                : "Invalid input";

            return View("Result");
        }
    }
}
