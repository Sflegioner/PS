using ClientLourd.MVVM.Model;
using Xunit;
namespace TestProject1;
using ClientLourd.Core; 
public class APIserviceSite
{
    [Fact]
    public async Task GetSitesAsync()
    {
        var result = await ClientLourd.Core.APIserviceSite.GetSitesAsync();
        Assert.NotNull(result);
        Assert.IsType<List<SiteModel>>(result);
    }

    [Fact]
    public async Task PostSiteAsync()
    {
        string siteName = "Test Site";
        bool result = await ClientLourd.Core.APIserviceSite.PostSiteAsync(siteName);
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteSiteAsync()
    {
        string siteName = "Test Site";
        await ClientLourd.Core.APIserviceSite.PostSiteAsync(siteName); 
        bool result = await ClientLourd.Core.APIserviceSite.DeleteSiteAsync(siteName);
        Assert.True(result);
    }
}