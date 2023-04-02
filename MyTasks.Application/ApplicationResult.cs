using System.Net;

namespace MyTasks.Application
{
    public class ApplicationResult<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public T? Result { get; set; }

        public ApplicationResult() { }
    }
}
