using MyTasks.Application.Interfaces.Base;
using MyTasks.Application.Models;
using System.Net;

namespace MyTasks.Application.Interfaces
{
    public interface IServiceTasks : IServiceBase
    {
        Task<ApplicationResult<TaskModel>> Create(
            string task,
            decimal effort,
            decimal remainingWork,
            string remainingTimeForWarning,
            decimal completedWork);
        Task<ApplicationResult<TaskModel>> Update(
            string id,
            string task,
            decimal effort,
            decimal remainingWork,
            string remainingTimeForWarning,
            decimal completedWork,
            string status);
        Task<ApplicationResult<IEnumerable<TaskModel>>> Get();
        Task<ApplicationResult<TaskModel>> GetById(string id);
        Task<HttpStatusCode> Delete(string id);
    }
}
