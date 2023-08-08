using System;
using System.Collections.Generic;
using System.Text;

namespace HrManagement.Application.DTOs.Email
{
    public class EmailDTO
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    public class EmailSetting {
        public string ApiKey { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}
