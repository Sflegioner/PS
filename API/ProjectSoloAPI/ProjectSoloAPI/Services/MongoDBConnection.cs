using MongoDB.Driver;

namespace ProjectSoloAPI.Services;
using Models;

public sealed class MongoDBConnection
{
    private static MongoClient _database;

    public static MongoClient GetMongoDBConnection()
    {
        if (_database == null)
        {
            _database = new MongoClient("mongodb://localhost:27017");
        }
        return _database;
    }
    public static bool CreateDatabaseAndCollection()
    {
       var client = GetMongoDBConnection();
       var database = client.GetDatabase("ProjectSoloDB");
      if (!database.ListCollections().Any())
      {
           database.CreateCollection("Sites");
           database.CreateCollection("Services");
           database.CreateCollection("Salaries");   
      }
       Console.WriteLine("Collection created!");
       return true;
    }
}