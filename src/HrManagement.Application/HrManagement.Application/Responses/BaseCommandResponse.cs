using System.Collections.Generic;

namespace HrManagement.Application.Responses
{
    public sealed class BaseCommandResponse
    {
        public BaseCommandResponse(int id, bool success, string message, List<string> errors)
        {
            Id = id;
            Success = success;
            Message = message;
            Errors = errors;
        }

        public int Id { get; private set; }
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public List<string> Errors { get; private set; }

        public class Builder
        {
            private int _id;
            private bool _success;
            private string _message;
            private List<string> _errors;

            public Builder Id(int id)
            {
                _id = id;
                return this;
            }

            public Builder Success(bool success)
            {
                _success = success;
                return this;
            }

            public Builder Message(string message)
            {
                _message = message;
                return this;
            }

            public Builder Errors(List<string> errors)
            {
                _errors = errors;
                return this;
            }

            public BaseCommandResponse Create()
            {

                return new BaseCommandResponse(_id, _success, _message, _errors);
            }
        }
    }
}
