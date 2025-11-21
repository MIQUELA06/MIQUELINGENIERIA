using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MIQUELINGENIERIA.Models;
using MySql.Data.MySqlClient;

namespace MIQUELINGENIERIA.Pages
{
    public class RegistroModel : PageModel
    {
        [BindProperty]
        public Usuario Usuario { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            string connectionString = "Server=localhost;Database=registrodb;Uid=root;Pwd=cisco123;";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO usuarios 
                    (Nombres, Apellidos, FechaNacimiento, Correo, Telefono, Direccion, Sexo) 
                    VALUES (@Nombres, @Apellidos, @FechaNacimiento, @Correo, @Telefono, @Direccion, @Sexo)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombres", Usuario.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", Usuario.Apellidos);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", Usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Correo", Usuario.Correo);
                    cmd.Parameters.AddWithValue("@Telefono", Usuario.Telefono);
                    cmd.Parameters.AddWithValue("@Direccion", Usuario.Direccion);
                    cmd.Parameters.AddWithValue("@Sexo", Usuario.Sexo);
                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToPage("Registro");
        }
    }
}
