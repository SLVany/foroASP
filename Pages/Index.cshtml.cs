using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace foro.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string user, string pass)
        {
            login(user,pass);
        }

        private void login(string u, string p)
        {
            using (MySqlConnection c = new MySqlConnection("Server=localhost;Database=foro;Uid=root;Password="))
            {
                MySqlCommand cmd = new MySqlCommand();
                c.Open();
                cmd.Connection = c;
                cmd.CommandText = $"SELECT * FROM users WHERE username='{u}' AND password='{p}'";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Response.Redirect("Topics");
                    }
                    else
                    {
                        ViewData["Mensaje"] = "No se encontro el usuario";
                    }
                }
            }

        }
    }
}