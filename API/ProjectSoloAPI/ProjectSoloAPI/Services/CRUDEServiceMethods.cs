using MongoDB.Bson;
using MongoDB.Driver;
using ProjectSoloAPI.Models;

namespace ProjectSoloAPI.Services;

public class CRUDEServiceMethods
{
    public static MongoClient CollectionSite = MongoDBConnection.GetMongoDBConnection();
    public static List<ServiceModel> GetAllServices()
    {
        var AllServicesList = CollectionSite.GetDatabase("ProjectSoloDB").GetCollection<ServiceModel>("Services");
        return AllServicesList.Find(_ => true).ToList();
    }

    public static Boolean PostService(string ServiceName)
    {
        var AllServicesList = CollectionSite.GetDatabase("ProjectSoloDB").GetCollection<ServiceModel>("Services");
        var ServicesList = new ServiceModel()
        {
            Id = ObjectId.GenerateNewId().ToString(),
            ServiceName = ServiceName,
        };
        AllServicesList.InsertOne(ServicesList);
        return true;
    }
    public static Boolean PutService(string oldServiceName, string newServiceName)
    {
        var AllServicesList = CollectionSite.GetDatabase("ProjectSoloDB").GetCollection<ServiceModel>("Services");
        var updateResult = AllServicesList.UpdateOne(
            x => x.ServiceName == oldServiceName,
            Builders<ServiceModel>.Update.Set(x => x.ServiceName, newServiceName) 
        );
        return true;
    }
    public static Boolean DeleteService(string ServiceName)
    {
        var AllServicesList = CollectionSite.GetDatabase("ProjectSoloDB").GetCollection<ServiceModel>("Services");
        var deleteResult = AllServicesList.DeleteOne(x => x.ServiceName == ServiceName);
        return true;
    }
}