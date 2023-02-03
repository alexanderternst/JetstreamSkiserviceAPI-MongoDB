using JetstreamSkiserviceAPIMongoDB.Models;

namespace JetstreamSkiserviceAPIMongoDB.Services
{
    /// <summary>
    /// Interface für Status Service
    /// </summary>
    public interface IStatusService
    {
        List<Registration> Get();

        List<Registration> Get(string status);

        void Update(string id, StatusModel statusModel);
    }
}
