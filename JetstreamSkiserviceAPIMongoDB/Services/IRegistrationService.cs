using JetstreamSkiserviceAPIMongoDB.Models;

namespace JetstreamSkiserviceAPIMongoDB.Services
{
    /// <summary>
    /// Interface für Registration Service
    /// </summary>
    public interface IRegistrationService
    {
        List<Registration> Get();

        Registration Get(string id);

        void Create(Registration registration);

        void Delete(string id);

        void Update(string id, Registration registration);
    }
}
