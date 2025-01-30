using ProjectSoloAPI.Services;
using ProjectSoloAPI.RoutesAPI;
MongoDBConnection.CreateDatabaseAndCollection();//Create DB and Collections

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer(); //Swagger 
builder.Services.AddSwaggerGen();//Swagger 

var app = builder.Build();
//-------------------------Map for API Route-----------------------------------------------//
app.MapSiteRoutes();
app.MapSeviceRoutes();
app.MapSalarieRoutes();

//-------------------------Map for API Route-----------------------------------------------//
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); //Swagger 
    app.UseSwaggerUI();//Swagger 
    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.Run();
