using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectSoloAPI.Models;

public class ServiceModel
{
    [BsonId]
    public ObjectId Id { get; set; } 
    [BsonElement("NomService")]
    public string ServiceName { get; set; }
}