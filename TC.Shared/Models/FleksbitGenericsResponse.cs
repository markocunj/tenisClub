using System.Collections.Generic;
using System.Net;

namespace TC.Shared.Models
{
    public class FleksbitGenericsResponse<T> where T : class
    {
        public HttpStatusCode Code { get; set; }
        public ICollection<FleksbitErrorInformation> Errors { get; set; }
        public T Response { get; set; }

        public static FleksbitGenericsResponse<T> CreateResponse(T data)
        {
            FleksbitGenericsResponse<T> response = new FleksbitGenericsResponse<T>();
            response.Response = data;

            return response;
        }

        public static FleksbitGenericsResponse<T> CreateResponse(HttpStatusCode statusCode, T data)
        {
            var response = CreateResponse(data);
            response.Code = statusCode;
            return response;
        }

        public static FleksbitGenericsResponse<T> CreateErrorResponse(HttpStatusCode statusCode, ICollection<FleksbitErrorInformation> errors)
        {
            FleksbitGenericsResponse<T> response = new FleksbitGenericsResponse<T>();
            response.Code = statusCode;
            response.Errors = errors;

            return response;
        }

        public static FleksbitGenericsResponse<T> CreateErrorResponse(HttpStatusCode statusCode, FleksbitErrorInformation error)
        {
            ICollection<FleksbitErrorInformation> errors = new List<FleksbitErrorInformation>();
            errors.Add(error);

            return CreateErrorResponse(statusCode, errors);
        }
    }
}
