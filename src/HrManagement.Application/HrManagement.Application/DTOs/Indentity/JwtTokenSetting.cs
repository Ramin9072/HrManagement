namespace HrManagement.Application.DTOs.Indentity
{
    public class JwtTokenSetting
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string DuraionInMinutes { get; set; }

    }
}
