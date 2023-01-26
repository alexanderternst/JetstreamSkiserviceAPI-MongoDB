using JetstreamSkiserviceAPIMongoDB.Models;

namespace JetstreamSkiserviceAPIMongoDB.Services
{
    public interface IStatusService
    {
        List<Registration> Get();

        List<Registration> Get(string status);
    }
}
