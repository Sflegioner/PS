using Xunit;
using ClientLourd.Core;

namespace TestProject1;

public class LoginTests
{
    [Fact]
    public void TRUELogin()
    {
        string correctPassword = "admin";
        bool isValid = ConnectedUser.VerifyPassword(correctPassword);
        
        Assert.True(isValid);
    }

    [Fact]
    public void FALSELogin()
    {
        string wrongPassword = "wrongpassword";
        bool isValid = ConnectedUser.VerifyPassword(wrongPassword);
        Assert.False(isValid);
    }
}