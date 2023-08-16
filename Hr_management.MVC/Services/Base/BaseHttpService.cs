using Hr_management.MVC.Contracts;
using System.Net.Http.Headers;

namespace Hr_management.MVC.Services.Base
{
    public class BaseHttpService
    {
        protected readonly ILocalStorageService _localStorageService;
        protected readonly IClient _client;

        public BaseHttpService(ILocalStorageService localStorageService, IClient client)
        {
            _localStorageService = localStorageService;
            _client = client;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException exception)
        {
            switch (exception.StatusCode)
            {
                case 400:
                    return new Response<Guid> { Message = "Validation Errors", ValidationErrors = exception.Response, Success = false };
                case 404:
                    return new Response<Guid> { Message = "Server not found", ValidationErrors = exception.Response, Success = false };
                default:
                    return new Response<Guid> { Message = "Something is wrong", ValidationErrors = exception.Response, Success = false };

            }
        }

        protected void AddBearerToken()
        {
            if (_localStorageService.Exists("token"))
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _localStorageService.GetStorageValue<string>("token"));
            }
        }
    }
}
