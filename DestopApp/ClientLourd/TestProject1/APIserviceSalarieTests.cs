using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using ClientLourd.Core;
using ClientLourd.MVVM.Model;

public class APIserviceSalarieTests
{
    [Fact]
    public async Task GetSalarieAsync()
    {
        var result = await APIserviceSalarie.GetSalarieAsync();
        Assert.NotNull(result);
        Assert.IsType<List<SalarieModel>>(result);
    }

    [Fact]
    public async Task PostSalarieAsync()
    {
        var salarie = new SalarieModel 
        {
            Nom = "Test1",
            Prenom = "User",
            Email = "test@example.com",
            TelephoneFixe = "123456789",
            TelephonePortable = "987654321",
            siteId = "6797e7374c3451fe31cdd3f0",
            serviceId = "67990527d63e19293923e8c6"
        };
    
        var result = await APIserviceSalarie.PostSalarieAsync(salarie);
    
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteSalarieAsync()
    {
        var salarie = new SalarieModel { Email = "test@example.com" };
        var result = await APIserviceSalarie.DeleteSalarieAsync(salarie);
        Assert.True(result);
    }

    [Fact]
    public async Task PutSalarieAsync()
    {
        var salarie = new SalarieModel { Id = "6797e7374c3451fe31cdd3f0", Nom = "Updated", Prenom = "User", Email = "updated@example.com", siteId = "6797e7374c3451fe31cdd3f0", serviceId = "67990527d63e19293923e8c6" };
        var result = await APIserviceSalarie.PutSalarieAsync(salarie);
        Assert.True(result);
    }
}