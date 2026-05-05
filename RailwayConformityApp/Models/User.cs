using RailwayConformityApp.Enums;

namespace RailwayConformityApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public UserRole Role { get; set; }

        public User(int id, string name, UserRole role)
        {
            Id = id;
            Username = name;
            Role = role;
        }
    }
}