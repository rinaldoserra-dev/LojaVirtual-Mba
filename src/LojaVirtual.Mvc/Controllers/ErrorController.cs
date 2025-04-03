using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Mvc.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Erro/{statusCode}")]
        public IActionResult HandleError(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("NotFound");
            }

            return View("Error");
        }
    }
}
