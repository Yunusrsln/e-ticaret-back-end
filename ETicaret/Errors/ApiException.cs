namespace API.Errors
{
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode, string message = null,string detail =null) 
            : base(statusCode, message)
        {
            this.Details = detail;
        }

        public string Details{ get; set; }
    }
}
