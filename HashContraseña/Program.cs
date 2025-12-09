using System;
using BCrypt.Net;

class Program
{
    static void Main()
    {
        string passwordPedro = "pedrogogenola";
        string passwordMilton = "milton123";
        string passwordJesus = "jesus123";

        string hashedPedro = BCrypt.Net.BCrypt.HashPassword(passwordPedro);
        string hashedMilton = BCrypt.Net.BCrypt.HashPassword(passwordMilton);
        string hashedJesus = BCrypt.Net.BCrypt.HashPassword(passwordJesus);

        Console.WriteLine($"Pedro: {hashedPedro}");
        Console.WriteLine($"Milton: {hashedMilton}");
        Console.WriteLine($"Jesús: {hashedJesus}");
    }
}
