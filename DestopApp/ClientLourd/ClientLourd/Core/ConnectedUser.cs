
namespace ClientLourd.Core;

public static class ConnectedUser
{
    public static string name { get; set; }
    private static string passwordHash = "$2a$11$AimAbDAzPDtap9I56Ot9s.aJoY5km0G5dNGmTub99EaJ3PL2l8pPe";
    public static Boolean IsAdmin { get; set; }
    
    public static string SetPassword(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password, 11);
    }

    public static bool VerifyPassword(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
    }
    
}