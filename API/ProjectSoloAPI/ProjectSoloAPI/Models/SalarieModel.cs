using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectSoloAPI.Models;

public class SalarieModel
{
    [BsonId]
    public ObjectId Id { get; set; } 

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
    public string Service { get; set; } 

    [BsonElement("Site")]
    public string Site { get; set; } 
    
}