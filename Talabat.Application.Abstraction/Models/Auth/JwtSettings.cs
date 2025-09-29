namespace Talabat.Application.Abstraction.Models.Auth
{
    public class JwtSettings
    {
        public required string key { get; set; }
        public required string Audience { get; set; }
        public required string Issuer { get; set; }
        public required double DurationInMinutes { get; set; }
 
    }
}
