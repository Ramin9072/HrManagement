namespace Hr_management.MVC.Services.Base
{
    public partial interface IClient
    { // partial because in duplicate in service client
        public HttpClient HttpClient { get; } // read only
    }

}
