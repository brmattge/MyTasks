using Newtonsoft.Json;

namespace MyTasks.Application.Models
{
    public class TaskModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("task")]
        public string Task { get; set; }

        [JsonProperty("effort")]
        public decimal Effort { get; set; }

        [JsonProperty("remainingWork")]
        public decimal RemainingWork { get; set; }

        [JsonProperty("remainingTimeForWarning")]
        public string RemainingTimeForWarning { get; set; }

        [JsonProperty("completedWork")]
        public decimal CompletedWork { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }
    }
}
