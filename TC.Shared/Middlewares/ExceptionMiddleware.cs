using TC.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using System;
using System.IO;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace TC.Shared.Middlewares
{
    /// <summary>
    /// Middelware which handles all application exceptions.
    /// Be sure to put it at begining of pipeline.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JsonSerializerSettings _jsonSerializerSettings;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <param name="stringLocalizer"></param>
        public ExceptionMiddleware(
            RequestDelegate next
            , IHttpContextAccessor httpContextAccessor
            
            )
        {
            this._next = next;
            _httpContextAccessor = httpContextAccessor;
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            };


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);

              }
            //add more catch expressions to handel specific exceptions
            catch (DbUpdateException ex)
            {
                Log.Fatal("{0}", ex);

                var innerException = ex.InnerException;

                if (innerException != null)
                {
                    var humanizedMessage = GetReadableErrorMessage(innerException);
                }

                FleksbitErrorInformation errorInformation = new FleksbitErrorInformation
                {
                    UserMessage = ex.Message,
                    InternalMessage = $"{ex.Message}, {ex.InnerException}, {ex.StackTrace}",
                    Code = FleksbitErrorCodes.RESOURCE_NOT_FOUND
                };

                await SendRepsonse(FleksbitResponse.CreateErrorResponse(HttpStatusCode.BadRequest, errorInformation), httpContext);

            }

            catch (AuthenticationException ex)
            {
                FleksbitErrorInformation errorInformation = new FleksbitErrorInformation
                {
                    UserMessage = ex.Message,
                    InternalMessage = ex.Message,
                    Code = FleksbitErrorCodes.AUTHENTICATION_FAILED
                };

                Log.Fatal("{0}", ex);

                await SendRepsonse(FleksbitResponse.CreateErrorResponse(HttpStatusCode.Unauthorized, errorInformation), httpContext);
            }
            
            catch (Exception ex)
             {
                FleksbitErrorInformation errorInformation = new FleksbitErrorInformation
                {
                    UserMessage = "",
                    InternalMessage = ex.InnerException.Message,
                    Code = FleksbitErrorCodes.INTERNAL_ERROR
                };

                Log.Fatal("{0}", ex);

                await SendRepsonse(FleksbitResponse.CreateErrorResponse(HttpStatusCode.InternalServerError, errorInformation), httpContext);
            }
        }

        private async Task SendRepsonse(FleksbitResponse response, HttpContext httpContext)
        {
            httpContext.Response.StatusCode = (int)response.Code;
            httpContext.Response.ContentType = "application/json";
            var json = JsonConvert.SerializeObject(response, _jsonSerializerSettings);
            await httpContext.Response.WriteAsync(json);
        }


        private string GetReadableErrorMessage(Exception innerException)
        {

            return null;

        }
    }
}
