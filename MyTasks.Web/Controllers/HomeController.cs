using Microsoft.AspNetCore.Mvc;
using MyTasks.Application.Interfaces;

namespace MyTasks.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceTasks _serviceTasks;

        public HomeController(IServiceTasks serviceTasks)
        {
            _serviceTasks = serviceTasks;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(
            string task,
            decimal effort,
            string remainingTimeForWarning)
        {
            var result = _serviceTasks.Create(task, effort, remainingTimeForWarning);

            return Json(result.Result);
        }

        [HttpPut]
        public IActionResult Update(
            int id,
            string task,
            decimal effort,
            string remainingTimeForWarning)
        {
            var result = _serviceTasks.Update(id, task, effort, remainingTimeForWarning);

            return Json(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _serviceTasks.Delete(id);

            return Json(result);
        }
    }
}