using foro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace foro.Pages
{
    public class TopicsModel : PageModel
    {
        public List<Topic> topics = new List<Topic>();
        public void OnGet()
        {
            listarTopics();
        }
        private void listarTopics()
        {
            using (MySqlConnection c = new MySqlConnection("Server=localhost;Database=foro;Uid=root;Password="))
            {
                MySqlCommand cmd = new MySqlCommand();
                c.Open();
                cmd.Connection = c;
                cmd.CommandText = "SELECT * FROM topics";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        topics.Add(new Topic()
                        {
                            Id = reader.GetInt32("id"),
                            Title = reader.GetString("title"),
                            UserId = reader.GetInt32("user_id"),
                        });
                    }
                }
            }
        }
    }
}
