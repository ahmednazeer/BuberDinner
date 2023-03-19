namespace BuberDinner.Infrastructure.Authentication
{
    public class JwtSettings
    {
        public const string JwtSettingsSectionName= "JwtSettings";
        public string Secret { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int ExpirationInDays { get; set; }
    }
}