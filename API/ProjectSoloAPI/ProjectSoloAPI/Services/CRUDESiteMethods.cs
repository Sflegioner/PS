using MongoDB.Driver;
using ProjectSoloAPI.Models;

namespace ProjectSoloAPI.Services;

public class CRUDESiteMethods
{
    public static MongoClient CollectionSite = MongoDBConnection.GetMongoDBConnection();
    
    public static void GetAllSite()
    {
        CollectionSite.GetDatabase("ProjectSoloDB").GetCollection<SiteModel>("Sites");
    }

    /*
    public static SiteModel PutSite(int id)
    {
        
    }

    public static SiteModel DeleteSite(int id)
    {
        
    }*/
}
