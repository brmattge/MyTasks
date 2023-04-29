using MyTasks.Application.Interfaces.Base;

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
        Task<ApplicationResult<string>> Get();
        Task<ApplicationResult<string>> Delete(string id);
    }
}
