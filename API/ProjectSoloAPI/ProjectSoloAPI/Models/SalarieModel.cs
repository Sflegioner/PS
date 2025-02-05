using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectSoloAPI.Models;

public class SalarieModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Nom")]
    public string Nom { get; set; } 

    [BsonElement("Prenom")]
    public string Prenom { get; set; } 

    [BsonElement("TelephoneFixe")]
    public string TelephoneFixe { get; set; } 

    [BsonElement("TelephonePortable")]
    public string TelephonePortable { get; set; } 

    [BsonElement("Email")]
    public string Email { get; set; } 

    [BsonElement("Service")]
    [BsonRequired]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ServiceId { get; set; }

    [BsonElement("Site")]
    [BsonRequired] 
    [BsonRepresentation(BsonType.ObjectId)]
    public string SiteId { get; set; }
}