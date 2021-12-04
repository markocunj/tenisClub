namespace TC.Shared.Models
{
    public class FleksbitErrorInformation
    {
        public string UserMessage { get; set; }

        public string InternalMessage { get; set; }

        public FleksbitErrorCodes Code { get; set; }
    }
}
