using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace JetstreamSkiserviceAPIMongoDB.Models
{
    /// <summary>
    /// User Model Klasse
    /// </summary>
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("user_id")]
        public string? Id { get; set; }

        [BsonElement("username")]
        [JsonPropertyName("user_username")]
        public string? Username { get; set; }

        [BsonElement("password")]
        [JsonPropertyName("user_password")]
        public string? Password { get; set; }

        [BsonElement("counter")]
        [JsonPropertyName("user_counter")]
        public int Counter { get; set; }

        [BsonElement("role")]
        [JsonIgnore]
        public string? Role { get; set; }
    }
}
