using JetstreamSkiserviceAPIMongoDB.Models;

namespace JetstreamSkiserviceAPIMongoDB.Services
{
    /// <summary>
    /// Interface für User Service
    /// </summary>
    public interface IUserService
    {
        string CreateToken(string username);

        void Ban(string id);

        void Unban(string id);

        List<User> Get();
    }
}
