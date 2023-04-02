using MyTasks.Application.Interfaces;
using prmToolkit.NotificationPattern;
using System.Net;

namespace MyTasks.Application.Services
{
    public class ServiceTasks : Notifiable, IServiceTasks
    {
        public ServiceTasks() { }

        public async Task<ApplicationResult<string>> Create(
            string task, 
            decimal effort, 
            string remainingTimeForWarning)
        {
            ApplicationResult<string> result = new ApplicationResult<string>();

            try
            {
                result.Result = "Saved successfully";
                result.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                result.StatusCode = HttpStatusCode.InternalServerError;
                result.Result = "There was an error while saving your changes";
            }

            return await Task.FromResult(result);
        }

        public async Task<ApplicationResult<string>> Update(
            int id,
            string task,
            decimal effort,
            string remainingTimeForWarning)
        {
            ApplicationResult<string> result = new ApplicationResult<string>();

            try
            {
                result.Result = "Updated successfully";
                result.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                result.StatusCode = HttpStatusCode.InternalServerError;
                result.Result = "There was an error while saving your changes";
            }

            return await Task.FromResult(result);
        }

        public async Task<ApplicationResult<string>> Get()
        {
            ApplicationResult<string> result = new ApplicationResult<string>();

            try
            {
                result.Result = "Data retrieved successfully";
                result.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                result.StatusCode = HttpStatusCode.InternalServerError;
                result.Result = "There was an error while retrieving your data";
            }

            return await Task.FromResult(result);
        }

        public async Task<ApplicationResult<string>> Delete(int id)
        {
            ApplicationResult<string> result = new ApplicationResult<string>();

            try
            {
                result.Result = "Deleted successfully";
                result.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                result.StatusCode = HttpStatusCode.InternalServerError;
                result.Result = "There was an error while saving your changes";
            }

            return await Task.FromResult(result);
        }
    }
}
