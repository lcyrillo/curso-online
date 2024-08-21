namespace CursoOnline.Infrastructure.Helpers;

public static class SenhaHelper
{
    public static string GerarSenhaProvisoria()
    {
        int lenght = 10;

        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";
        var random = new Random();
        string password = new string(Enumerable.Repeat(chars, lenght)
            .Select(s => s[random.Next(s.Length)]).ToArray());

        return password;
    }
}
