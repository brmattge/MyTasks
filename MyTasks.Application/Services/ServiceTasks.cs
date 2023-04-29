﻿using Microsoft.Azure.Cosmos;
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

        public async Task<ApplicationResult<string>> Create(
            string task,
            decimal effort,
            string remainingTimeForWarning)
        {
            ApplicationResult<string> result = new ApplicationResult<string>();

            try
            {
                var request = new TaskModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Task = task,
                    Effort = effort,
                    RemainingTimeForWarning = remainingTimeForWarning,
                    Status = "New"
                };

                var container = _context.GetContainer();
                var response = await container.CreateItemAsync(request);

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
            string id,
            string task,
            decimal effort,
            string remainingTimeForWarning)
        {
            ApplicationResult<string> result = new ApplicationResult<string>();

            try
            {
                var request = new TaskModel
                {
                    Id = id,
                    Task = task,
                    Effort = effort,
                    RemainingTimeForWarning = remainingTimeForWarning,
                    Status = "New"
                };

                var container = _context.GetContainer();
                var response = await container.ReplaceItemAsync(request, request.Id);

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

        public async Task<ApplicationResult<string>> Delete(string id)
        {
            ApplicationResult<string> result = new ApplicationResult<string>();

            try
            {
                var container = _context.GetContainer();
                await container.DeleteItemAsync<TaskModel>(id, new PartitionKey(id));

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
