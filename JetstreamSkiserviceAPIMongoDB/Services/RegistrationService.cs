using JetstreamSkiserviceAPIMongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace JetstreamSkiserviceAPIMongoDB.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IMongoCollection<Registration> _registrationCollection;
        
        /// <summary>
        /// Registration Service Konstruktor mit Dateneinstellungen/-konfiguration
        /// </summary>
        /// <param name="registrationDatabaseSettings">Datenbankeinstellungen</param>
        public RegistrationService(IOptions<RegistrationDatabaseSettings> registrationDatabaseSettings)
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
        /// Get Methode welche Registrationen von MongoDB Datenbank abruft 
        /// </summary>
        /// <returns>Liste von Registrationen</returns>
        public List<Registration> Get()
        {
            return _registrationCollection.Find(_ => true).ToList();
        }

        /// <summary>
        /// Get Methode welche Registration nach id von MongoDB Datenbank abruft
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Registration</returns>
        public Registration Get(string id)
        {
            return _registrationCollection.Find(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Create Methode welche Registration in MongoDB Datenbank erstellt
        /// </summary>
        /// <param name="registration">Neue Registration</param>
        public void Create(Registration registration)
        {
            _registrationCollection.InsertOne(registration);
        }

        /// <summary>
        /// Delete Methode welche Registration in MongoDB Datenbank löscht
        /// </summary>
        /// <param name="id">id</param>
        public void Delete(string id)
        {
            _registrationCollection.DeleteOne(x => x.Id == id);

        }

        /// <summary>
        /// Update Methode welche Registration in MongoDB Datenbank modifiziert
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="registration">Modifizierte Registration</param>
        public void Update(string id, Registration registration)
        {
            _registrationCollection.ReplaceOne(x => x.Id == id, registration);
        }
    }
}
