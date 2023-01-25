﻿using JetstreamSkiserviceAPIMongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json;

namespace JetstreamSkiserviceAPIMongoDB.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IMongoCollection<Registration> _registrationCollection;

        public RegistrationService(IOptions<RegistrationDatabaseSettings> registrationDatabaseSettings)
        {
            var mongoClient = new MongoClient(
            registrationDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                registrationDatabaseSettings.Value.DatabaseName);

            _registrationCollection = mongoDatabase.GetCollection<Registration>(
                registrationDatabaseSettings.Value.RegistrationCollectionName);
        }

        public List<Registration> GetAll()
        {
            return _registrationCollection.Find(_ => true).ToList();
        }

        public Registration Get(string id)
        {
            return _registrationCollection.Find(x => x.Id == id).FirstOrDefault();
        }

        public void Add(Registration registration)
        {
            _registrationCollection.InsertOne(registration);
        }

        public void Delete(string id)
        {
            _registrationCollection.DeleteOne(x => x.Id == id);

        }

        public void Update(string id, Registration registration)
        {
            _registrationCollection.ReplaceOne(x => x.Id == id, registration);
        }
    }
}