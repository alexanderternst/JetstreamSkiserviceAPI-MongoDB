using JetstreamSkiserviceAPIMongoDB.Models;

namespace JetstreamSkiserviceAPIMongoDB.Services
{
    public interface IUserService
    {
        string CreateToken(string username);

        void Ban(string id);

        void Unban(string id);

        List<User> Get();
    }
}
