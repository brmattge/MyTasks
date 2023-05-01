using Microsoft.Azure.Cosmos;
using MyTasks.Application.Interfaces;
using MyTasks.Application.Models;
using MyTasks.Infra.Context;
using prmToolkit.NotificationPattern;
using System.Net;

namespace MyTasks.Application.Services
{
    public class ServiceTasks : Notifiable, IServiceTasks
    {
        private readonly CosmosDbContext _context;

        public ServiceTasks(CosmosDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationResult<TaskModel>> Create(
            string task,
            decimal effort,
            decimal remainingWork,
            string remainingTimeForWarning,
            decimal completedWork)
        {
            ApplicationResult<TaskModel> result = new ApplicationResult<TaskModel>();

            try
            {
                var request = new TaskModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Task = task,
                    Effort = effort,
                    RemainingWork = remainingWork,
                    RemainingTimeForWarning = remainingTimeForWarning,
                    CompletedWork = completedWork,
                    Status = null
                };

                var container = _context.GetContainer();
                var response = await container.CreateItemAsync(request);

                result.Result = request;
                result.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception)
            {
                result.StatusCode = HttpStatusCode.InternalServerError;
            }

            return await Task.FromResult(result);
        }

        public async Task<ApplicationResult<TaskModel>> Update(
            string id,
            string task,
            decimal effort,
            decimal remainingWork,
            string remainingTimeForWarning,
            decimal completedWork,
            string status)
        {
            ApplicationResult<TaskModel> result = new ApplicationResult<TaskModel>();

            try
            {
                var request = new TaskModel
                {
                    Id = id,
                    Task = task,
                    Effort = effort,
                    RemainingWork = remainingWork,
                    RemainingTimeForWarning = remainingTimeForWarning,
                    CompletedWork = completedWork,
                    Status = status
                };

                var container = _context.GetContainer();
                var response = await container.ReplaceItemAsync(request, request.Id);

                result.Result = request;
                result.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception)
            {
                result.StatusCode = HttpStatusCode.InternalServerError;
            }

            return await Task.FromResult(result);
        }

        public async Task<ApplicationResult<IEnumerable<TaskModel>>> Get()
        {
            ApplicationResult<IEnumerable<TaskModel>> result = new ApplicationResult<IEnumerable<TaskModel>>();

            try
            {
                var container = _context.GetContainer();
                var query = container.GetItemQueryIterator<TaskModel>();
                var results = new List<TaskModel>();
                while (query.HasMoreResults)
                {
                    var response = await query.ReadNextAsync();
                    results.AddRange(response.ToList());
                }

                result.Result = results;
                result.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception)
            {
                result.StatusCode = HttpStatusCode.InternalServerError;
            }

            return await Task.FromResult(result);
        }

        public async Task<ApplicationResult<TaskModel>> GetById(string id)
        {
            ApplicationResult<TaskModel> result = new ApplicationResult<TaskModel>();

            try
            {
                var container = _context.GetContainer();
                var response = await container.ReadItemAsync<TaskModel>(id, new PartitionKey(id));

                result.Result = response;
                result.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception)
            {
                result.StatusCode = HttpStatusCode.InternalServerError;
            }

            return await Task.FromResult(result);
        }

        public async Task<HttpStatusCode> Delete(string id)
        {
            try
            {
                var container = _context.GetContainer();
                await container.DeleteItemAsync<TaskModel>(id, new PartitionKey(id));

                return await Task.FromResult(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return await Task.FromResult(HttpStatusCode.InternalServerError);
            }
        }
    }
}
