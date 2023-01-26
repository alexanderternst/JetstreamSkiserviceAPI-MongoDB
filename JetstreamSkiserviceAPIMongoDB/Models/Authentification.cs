using System.Text.Json.Serialization;

namespace JetstreamSkiserviceAPIMongoDB.Models
{
    /// <summary>
    /// Authentifikation Model Klasse
    /// </summary>
    public class Authentification
    {
        [JsonPropertyName("user_username")]
        public string? Username { get; set; }

        [JsonPropertyName("user_password")]
        public string? Password { get; set; }
    }
}
