namespace Techinical.Quala.Api.Services
{
    public interface IencriptationService
    {
        string Encrypt(string plainText);
        string Decrypt(string cipherText);
    }
}
