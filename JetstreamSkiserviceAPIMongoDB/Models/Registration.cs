using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace JetstreamSkiserviceAPIMongoDB.Models
{
    /// <summary>
    /// Registration Model Klasse
    /// </summary>
    public class Registration
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("registration_id")]
        public string? Id { get; set; }

        [BsonElement("name")]
        [JsonPropertyName("registration_name")]
        public string? Name { get; set; }

        [BsonElement("email")]
        [JsonPropertyName("registration_email")]
        public string? Email { get; set; }

        [BsonElement("phone")]
        [JsonPropertyName("registration_phone")]
        public string? Phone { get; set; }

        [BsonElement("create_date")]
        [JsonPropertyName("registration_create_date")]
        public DateTime CreateDate { get; set; }

        [BsonElement("pickup_date")]
        [JsonPropertyName("registration_pickup_date")]
        public DateTime PickupDate { get; set; }

        [BsonElement("status")]
        [JsonPropertyName("registration_status")]
        public string? Status { get; set; }

        [BsonElement("priority")]
        [JsonPropertyName("registration_priority")]
        public string? Priority { get; set; }

        [BsonElement("service")]
        [JsonPropertyName("registration_service")]
        public string? Service { get; set; }

        [BsonElement("comment")]
        [JsonPropertyName("registration_comment")]
        public string? Comment { get; set; }
    }
}
