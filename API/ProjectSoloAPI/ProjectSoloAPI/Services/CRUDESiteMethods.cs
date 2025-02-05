using Microsoft.AspNetCore.Authorization;
using MongoDB.Bson;
using MongoDB.Driver;
using ProjectSoloAPI.Models;

namespace ProjectSoloAPI.Services;

public static class CRUDESiteMethods
{
    public static MongoClient CollectionSite = MongoDBConnection.GetMongoDBConnection();
    
    public static List<SiteModel> GetAllSite()
    {
        var AllSites = CollectionSite.GetDatabase("ProjectSoloDB").GetCollection<SiteModel>("Sites");
        return AllSites.Find(_ => true).ToList();
    }
    public static Boolean PostSite(string SiteName)
    {
        var AllSites = CollectionSite.GetDatabase("ProjectSoloDB").GetCollection<SiteModel>("Sites");
        var site = new SiteModel()
        {
            Id = ObjectId.GenerateNewId().ToString(),
            SiteName = SiteName
        };
        AllSites.InsertOne(site);
        return true;
    }
    public static Boolean PutSite(string oldSiteName, string newSiteName)
    {
        var AllSites = CollectionSite.GetDatabase("ProjectSoloDB").GetCollection<SiteModel>("Sites");
        var updateResult = AllSites.UpdateOne(
            x => x.SiteName == oldSiteName,
            Builders<SiteModel>.Update.Set(x => x.SiteName, newSiteName) 
        );
        return true;
    }
    public static Boolean DeleteSite(string SiteName)
    {
        var AllSites = CollectionSite.GetDatabase("ProjectSoloDB").GetCollection<SiteModel>("Sites");
        var deleteResult = AllSites.DeleteOne(x => x.SiteName == SiteName);
        return deleteResult.DeletedCount > 0;
    }
}
