using JetstreamSkiserviceAPIMongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace JetstreamSkiserviceAPIMongoDB.Services
{
    public class StatusService : IStatusService
    {
        public readonly IMongoCollection<Registration> _registrationCollection;

        /// <summary>
        /// Status Service Konstruktor mit Dateneinstellungen/-konfiguration
        /// </summary>
        /// <param name="registrationDatabaseSettings">Datenbankeinstellungen</param>
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

        /// <summary>
        /// Get Methode welche Registrationen von MongoDB Datenbank nach Status gefiltert abruft
        /// </summary>
        /// <returns>Liste von Registrationen</returns>
        public List<Registration> Get()
        {
            // TO-DO: schönere ausgabe
            var sort = Builders<Registration>.Sort.Ascending("status");
            return _registrationCollection.Find(_ => true).Sort(sort).ToList();
        }

        /// <summary>
        /// Get Methode welche Registrationen von MongoDB Datenbank nach Status ausgibt
        /// </summary>
        /// <param name="status">status</param>
        /// <returns>Liste von Registrationen</returns>
        public List<Registration> Get(string status)
        {
            var filter = Builders<Registration>.Filter.Eq("status", status);
            return _registrationCollection.Find(filter).ToList();
        }
    }
}
