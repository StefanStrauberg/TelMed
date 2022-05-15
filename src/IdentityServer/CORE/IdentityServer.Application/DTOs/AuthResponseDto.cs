namespace IdentityServer.Application.DTOs
{
    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string Token { get; set; }
    }
}
