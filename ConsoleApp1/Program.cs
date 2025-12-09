using System;
using BCrypt.Net;

class Program
{
    static void Main()
    {
        string nuevaContrasena = "pedrogogenola"; // Define la nueva contraseña
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(nuevaContrasena);

        Console.WriteLine($"Contraseña encriptada: {hashedPassword}");
    }
}
