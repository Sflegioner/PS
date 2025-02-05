using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectSoloAPI.Models;

public class SiteModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("SiteName")]
    public string SiteName { get; set; }
}