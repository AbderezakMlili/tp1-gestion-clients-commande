using System;

namespace ProjetGestionClientsCommandes.Models
{
    public class Commande
    {
        public int IdCommande { get; set; }
        public DateTime DateCommande { get; set; }
        public decimal Montant { get; set; }
        public string Description { get; set; }
        public int IdClient { get; set; }
    }
}
