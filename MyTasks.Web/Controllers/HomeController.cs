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

        public async Task<IActionResult> Index()
        {
            var tasks = await _serviceTasks.Get();

            return View(tasks.Result);
        }

        [HttpPost]
        public IActionResult Create(
            string task,
            decimal effort,
            decimal remainingWork,
            string remainingTimeForWarning,
            decimal completedWork)
        {
            var result = _serviceTasks.Create(
                task,
                effort,
                remainingWork,
                remainingTimeForWarning,
                completedWork);

            return Json(result.Result);
        }

        [HttpPut]
        public IActionResult Update(
            string id,
            string task,
            decimal effort,
            decimal remainingWork,
            string remainingTimeForWarning,
            decimal completedWork,
            string status)
        {
            var result = _serviceTasks.Update(
                id,
                task,
                effort,
                remainingWork,
                remainingTimeForWarning,
                completedWork,
                status);

            return Json(result.Result);
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var result = _serviceTasks.Delete(id);

            return Json(result.Result);
        }
    }
}