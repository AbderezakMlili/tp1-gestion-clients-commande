using System;

namespace ProjetGestionClientsCommandes.Models
{
    public class Client
    {
        public int IdClient { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}
