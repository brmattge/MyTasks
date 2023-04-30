using Microsoft.AspNetCore.Mvc;
using MyTasks.Application.Interfaces;
using System.Threading.Tasks;

namespace MyTasks.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceTasks _serviceTasks;

        public HomeController(IServiceTasks serviceTasks)
        {
            _serviceTasks = serviceTasks;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var tasks = await _serviceTasks.Get();

            //return View(tasks);
            return View(tasks.Result);
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
            string id,
            string task,
            decimal effort,
            string remainingTimeForWarning)
        {
            var result = _serviceTasks.Update(id, task, effort, remainingTimeForWarning);

            return Json(result);
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var result = _serviceTasks.Delete(id);

            return Json(result);
        }
    }
}