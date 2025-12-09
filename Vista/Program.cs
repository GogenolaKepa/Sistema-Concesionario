using System;
using System.Windows.Forms;
using Modelo;

namespace Vista
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var contexto = new Concesionario())
            {
                contexto.AsegurarUsuarioAdmin();
                contexto.AsegurarUsuarioSubgerente(); // 🔹 Agregamos el usuario "Milton"
            }


            Application.Run(new FormLogin());
        }
    }
}
