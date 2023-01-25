using JetstreamSkiserviceAPIMongoDB.Models;

namespace JetstreamSkiserviceAPIMongoDB.Services
{
    public interface IRegistrationService
    {
        List<Registration> GetAll();

        Registration Get(string id);

        void Add(Registration registration);

        void Delete(string id);

        void Update(string id, Registration registration);
    }
}
