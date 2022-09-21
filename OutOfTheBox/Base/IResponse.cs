using System.Net;

namespace OutOfTheBox.Web.Base
{
    public interface IResponse<T>
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
        public T Data { get; set; }
    }
}
