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

    public static bool PostSalarie(string Nom, string Prenom, string TelephoneFixe, string TelephonePortable, string Email, string Service, string Site)
    {
        var NewSalarie = new SalarieModel()
        {
            Nom = Nom,
            Prenom = Prenom,
            TelephoneFixe = TelephoneFixe,
            TelephonePortable = TelephonePortable,
            Email = Email,
            Service = Service,
            Site = Site
        };
        var ListAllSalarie = Collection.GetDatabase("ProjectSoloDB").GetCollection<SalarieModel>("Salaries");
        ListAllSalarie.InsertOne(NewSalarie);
        return true;
    }

    public static bool UpdateSalarie(string Email, string Nom, string Prenom, string TelephoneFixe, string TelephonePortable, string Service, string Site)
    {
        var ListAllSalarie = Collection.GetDatabase("ProjectSoloDB").GetCollection<SalarieModel>("Salaries");
        var filter = Builders<SalarieModel>.Filter.Eq(s => s.Email, Email);
        var update = Builders<SalarieModel>.Update
            .Set(s => s.Nom, Nom)
            .Set(s => s.Prenom, Prenom)
            .Set(s => s.TelephoneFixe, TelephoneFixe)
            .Set(s => s.TelephonePortable, TelephonePortable)
            .Set(s => s.Service, Service)
            .Set(s => s.Site, Site);

        var result = ListAllSalarie.UpdateOne(filter, update);
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
