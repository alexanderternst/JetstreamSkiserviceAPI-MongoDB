using JetstreamSkiserviceAPIMongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace JetstreamSkiserviceAPIMongoDB.Services
{
    public class StatusService : IStatusService
    {
        public readonly IMongoCollection<Registration> _registrationCollection;

        public StatusService(IOptions<RegistrationDatabaseSettings> registrationDatabaseSettings)
        {
            try
            {
                var mongoClient = new MongoClient(
                registrationDatabaseSettings.Value.ConnectionString);

                var mongoDatabase = mongoClient.GetDatabase(
                    registrationDatabaseSettings.Value.DatabaseName);

                _registrationCollection = mongoDatabase.GetCollection<Registration>(
                    registrationDatabaseSettings.Value.RegistrationCollectionName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Registration> Get()
        {
            var sort = Builders<Registration>.Sort.Ascending("status");
            return _registrationCollection.Find(_ => true).Sort(sort).ToList();
        }

        public List<Registration> Get(string status)
        {
            var filter = Builders<Registration>.Filter.Eq("status", status);
            return _registrationCollection.Find(filter).ToList();
        }
    }
}
