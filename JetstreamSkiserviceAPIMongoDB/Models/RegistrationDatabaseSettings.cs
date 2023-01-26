namespace JetstreamSkiserviceAPIMongoDB.Models
{
    /// <summary>
    /// Klasse für Konfiguration/Datenbankverbindung
    /// </summary>
    public class RegistrationDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string RegistrationCollectionName { get; set; } = null!;

        public string UserCollectionName { get; set; } = null!;
    }
}
