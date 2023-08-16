namespace Hr_management.MVC.Services.Base
{
    public class Response<T>
    {
        public string Message { get; set; } // message
        public string ValidationErrors { get; set; } // Error
        public bool Success { get; set; } // is success
        public T Data { get; set; } // response
    }

}
