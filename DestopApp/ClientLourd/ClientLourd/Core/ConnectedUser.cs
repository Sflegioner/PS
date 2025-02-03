
namespace ClientLourd.Core;

public static class ConnectedUser
{
    public static string name { get; set; }
    public static Boolean IsAdmin { get; set; }

    public static Boolean ChaeckIfIsAdmin(string userName,string password)
    {
        if (userName == "admin" && password == "admin")
        {
            IsAdmin = true;
            return true;
        }
        else
        {
            IsAdmin = false;
            return false;
        }
    }
}