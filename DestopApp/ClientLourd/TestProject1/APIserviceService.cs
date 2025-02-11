using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientLourd.Core;
using ClientLourd.MVVM.Model;
using Xunit;

public class APIserviceServiceTests
{
    [Fact]
    public async Task GetServicesAsync_ReturnsList()
    {
        var result = await APIserviceService.GetServicesAsync();
        Assert.NotNull(result);
        Assert.IsType<List<ServiceModel>>(result);
    }

    [Fact]
    public async Task PostServiceAsync_ReturnsTrue_WhenSuccess()
    {
        string serviceName = "TestService_" + Guid.NewGuid();
        bool result = await APIserviceService.PostServiceAsync(serviceName);
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteServiceAsync_ReturnsTrue_WhenSuccess()
    {
        string serviceName = "ToDelete_" + Guid.NewGuid();
        await APIserviceService.PostServiceAsync(serviceName); 
        bool result = await APIserviceService.DeleteServiceAsync(serviceName);
        Assert.True(result);
    }
}