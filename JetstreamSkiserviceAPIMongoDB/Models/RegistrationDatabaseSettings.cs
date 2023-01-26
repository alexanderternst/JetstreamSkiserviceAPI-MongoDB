namespace JetstreamSkiserviceAPIMongoDB.Models
{
    public class RegistrationDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string RegistrationCollectionName { get; set; } = null!;

        public string UserCollectionName { get; set; } = null!;
    }
}
