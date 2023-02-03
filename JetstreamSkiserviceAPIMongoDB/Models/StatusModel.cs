using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace JetstreamSkiserviceAPIMongoDB.Models
{
    public class StatusModel
    {
        [BsonElement("status")]
        [JsonPropertyName("registration_status")]
        public string? Status { get; set; }
    }
}
