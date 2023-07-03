namespace EatEasy.Domain.Core.Domain
{
    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Days { get; set; }
        public string Key { get; set; }
    }
}
