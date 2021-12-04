using System;
using System.Collections.Generic;
using System.Net;

namespace TC.Shared.Models
{
    public class FleksbitResponse
    {
        public HttpStatusCode Code { get; set; }
        public ICollection<FleksbitErrorInformation> Errors { get; set; }
        public object Response { get; set; }

        public static FleksbitResponse CreateResponse(object data)
        {
            FleksbitResponse response = new FleksbitResponse();
            response.Response = data;

            return response;
        }

        public static FleksbitResponse CreateResponse(HttpStatusCode statusCode, object data)
        {
            var response = CreateResponse(data);
            response.Code = statusCode;
            return response;
        }

        public static FleksbitResponse CreateResponse(HttpStatusCode statusCode, string message)
        {
            var response = CreateResponse(message);
            response.Code = statusCode;
            return response;
        }

        public static FleksbitResponse CreateErrorResponse(HttpStatusCode statusCode, ICollection<FleksbitErrorInformation> errors)
        {
            FleksbitResponse response = new FleksbitResponse();
            response.Code = statusCode;
            response.Errors = errors;

            return response;
        }

        public static FleksbitResponse CreateErrorResponse(HttpStatusCode statusCode, FleksbitErrorInformation error)
        {
            ICollection<FleksbitErrorInformation> errors = new List<FleksbitErrorInformation>();
            errors.Add(error);

            return CreateErrorResponse(statusCode, errors);
        }

    }
}
