using MongoDB.Bson;
using MongoDB.Driver;
using ProjectSoloAPI.Models;

namespace ProjectSoloAPI.Services;

public class CRUDESalarieAPI
{
    public static MongoClient Collection = MongoDBConnection.GetMongoDBConnection();

    public static List<SalarieModel> GetAllServices()
    {
        var ListAllSalarie = Collection.GetDatabase("ProjectSoloDB").GetCollection<SalarieModel>("Salaries");
        return ListAllSalarie.Find(_ => true).ToList();
    }

    public static bool PostSalarie(string Nom, string Prenom, string TelephoneFixe, string TelephonePortable, string Email, string ServiceId, string SiteId)
    {
        var NewSalarie = new SalarieModel()
        {
            Id = ObjectId.GenerateNewId().ToString(),
            Nom = Nom,
            Prenom = Prenom,
            TelephoneFixe = TelephoneFixe,
            TelephonePortable = TelephonePortable,
            Email = Email,
            ServiceId = ServiceId, 
            SiteId = SiteId  
        };
        var ListAllSalarie = Collection.GetDatabase("ProjectSoloDB").GetCollection<SalarieModel>("Salaries");
        ListAllSalarie.InsertOne(NewSalarie);
        return true;
    }

    public static bool UpdateSalarie(string ID, string Nom, string Prenom, string Email, 
        string TelephoneFixe, string TelephonePortable, 
        string ServiceId, string SiteId)
    {
        var ListAllSalarie = Collection.GetDatabase("ProjectSoloDB").GetCollection<SalarieModel>("Salaries");

        var filter = Builders<SalarieModel>.Filter.Eq(s => s.Id, ID); 
    
        var update = Builders<SalarieModel>.Update
            .Set(s => s.Nom, Nom)
            .Set(s => s.Prenom, Prenom)
            .Set(s => s.Email, Email)
            .Set(s => s.TelephoneFixe, TelephoneFixe)
            .Set(s => s.TelephonePortable, TelephonePortable)
            .Set(s => s.ServiceId, ServiceId)
            .Set(s => s.SiteId, SiteId);

        var result = ListAllSalarie.UpdateOne(filter, update);

        Console.WriteLine($"Matched: {result.MatchedCount}, Modified: {result.ModifiedCount}");

        return result.ModifiedCount > 0;
    }


    public static bool DeleteSalarie(string Email)
    {
        var ListAllSalarie = Collection.GetDatabase("ProjectSoloDB").GetCollection<SalarieModel>("Salaries");
        var filter = Builders<SalarieModel>.Filter.Eq(s => s.Email, Email);
        var result = ListAllSalarie.DeleteOne(filter);
        return result.DeletedCount > 0;
    }
}
