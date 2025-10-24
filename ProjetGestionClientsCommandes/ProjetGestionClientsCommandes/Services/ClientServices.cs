using System;
using System.Collections.Generic;
using ProjetGestionClientsCommandes.Models;

namespace ProjetGestionClientsCommandes.Services
{
    public class ClientService
    {
        private List<Client> clients = new List<Client>();
        private int prochainId = 1;

        public void AjouterClient()
        {
            Console.WriteLine("=== Ajouter un client ===");
            Console.Write("Nom: ");
            string nom = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Téléphone: ");
            string tel = Console.ReadLine();

            Client nouveauClient = new Client
            {
                IdClient = prochainId++,
                Nom = nom,
                Email = email,
                Telephone = tel
            };

            clients.Add(nouveauClient);
            Console.WriteLine("Client ajouté avec succès !");
            Console.ReadKey();
        }

        public void ListerClients()
        {
            Console.WriteLine("=== Liste des clients ===");
            if (clients.Count == 0)
            {
                Console.WriteLine("Aucun client enregistré.");
            }
            else
            {
                foreach (var client in clients)
                {
                    Console.WriteLine($"ID: {client.IdClient} | Nom: {client.Nom} | Email: {client.Email} | Téléphone: {client.Telephone}");
                }
            }
            Console.ReadKey();
        }

        public Client TrouverClientParId(int id)
        {
            return clients.Find(c => c.IdClient == id);
        }

        public void ModifierClient()
        {
            Console.Write("Entrez l'ID du client à modifier : ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var client = TrouverClientParId(id);
                if (client == null)
                {
                    Console.WriteLine("Client non trouvé.");
                }
                else
                {
                    Console.Write("Nouveau nom (laisser vide pour garder): ");
                    string nom = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nom)) client.Nom = nom;

                    Console.Write("Nouveau email (laisser vide pour garder): ");
                    string email = Console.ReadLine();
                    if (!string.IsNullOrEmpty(email)) client.Email = email;

                    Console.Write("Nouveau téléphone (laisser vide pour garder): ");
                    string tel = Console.ReadLine();
                    if (!string.IsNullOrEmpty(tel)) client.Telephone = tel;

                    Console.WriteLine("Client modifié !");
                }
            }
            else
            {
                Console.WriteLine("ID invalide.");
            }
            Console.ReadKey();
        }

        public void SupprimerClient()
        {
            Console.Write("Entrez l'ID du client à supprimer : ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var client = TrouverClientParId(id);
                if (client == null)
                {
                    Console.WriteLine("Client non trouvé.");
                }
                else
                {
                    clients.Remove(client);
                    Console.WriteLine("Client supprimé !");
                }
            }
            else
            {
                Console.WriteLine("ID invalide.");
            }
            Console.ReadKey();
        }

        public List<Client> ObtenirTousClients()
        {
            return clients;
        }
    }
}
