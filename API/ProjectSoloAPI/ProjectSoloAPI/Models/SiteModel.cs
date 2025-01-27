using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectSoloAPI.Models;

public class SiteModel
{
    [BsonId]
    public ObjectId Id { get; set; } 
    [BsonElement("SiteName")]
    public string SiteName { get; set; }
}