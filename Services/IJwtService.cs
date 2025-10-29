namespace Techinical.Quala.Api.Services
{
    public interface IJwtService
    {
        string GenerateToken(string userId, string userName, string role);
    }
}
