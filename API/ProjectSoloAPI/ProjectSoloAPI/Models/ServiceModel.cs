using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectSoloAPI.Models;

public class ServiceModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("NomService")]
    public string ServiceName { get; set; }
}