using System.Collections.Generic;
using System.Net;

namespace TC.Shared.Models
{
    public class SwaggerResponse<T>
    {
        public HttpStatusCode Code { get; set; }
        public ICollection<FleksbitErrorInformation> Errors { get; set; }
        public T Response { get; set; }
    }
}
