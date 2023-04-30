using MyTasks.Application.Interfaces.Base;
using MyTasks.Application.Models;

namespace MyTasks.Application.Interfaces
{
    public interface IServiceTasks : IServiceBase
    {
        Task<ApplicationResult<string>> Create(
            string task,
            decimal effort,
            string remainingTimeForWarning);
        Task<ApplicationResult<string>> Update(
            string id,
            string task,
            decimal effort,
            string remainingTimeForWarning);
        Task<ApplicationResult<IEnumerable<TaskModel>>> Get();
        Task<ApplicationResult<TaskModel>> GetById(string id);
        Task<ApplicationResult<string>> Delete(string id);
    }
}
