using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operations.PL.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
