using JetstreamSkiserviceAPIMongoDB.Models;

namespace JetstreamSkiserviceAPIMongoDB.Services
{
    public interface IRegistrationService
    {
        List<Registration> Get();

        Registration Get(string id);

        void Create(Registration registration);

        void Delete(string id);

        void Update(string id, Registration registration);
    }
}
