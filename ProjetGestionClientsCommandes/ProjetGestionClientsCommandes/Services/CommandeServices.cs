using System;
using System.Collections.Generic;
using ProjetGestionClientsCommandes.Models;

namespace ProjetGestionClientsCommandes.Services
{
    public class CommandeService
    {
        private List<Commande> commandes = new List<Commande>();
        private int prochainIdCommande = 1;
        private ClientService clientService;

        public CommandeService(ClientService clientService)
        {
            this.clientService = clientService;
        }

        public void AjouterCommande()
        {
            Console.WriteLine("=== Ajouter une commande ===");
            Console.Write("ID du client: ");
            if (int.TryParse(Console.ReadLine(), out int idClient))
            {
                var client = clientService.TrouverClientParId(idClient);
                if (client == null)
                {
                    Console.WriteLine("Client non trouvé.");
                }
                else
                {
                    Console.Write("Date commande (yyyy-MM-dd) : ");
                    if (!DateTime.TryParse(Console.ReadLine(), out DateTime dateCommande))
                    {
                        Console.WriteLine("Date invalide.");
                        Console.ReadKey();
                        return;
                    }

                    Console.Write("Montant : ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal montant))
                    {
                        Console.WriteLine("Montant invalide.");
                        Console.ReadKey();
                        return;
                    }

                    Console.Write("Description : ");
                    string description = Console.ReadLine();

                    Commande nouvelleCommande = new Commande
                    {
                        IdCommande = prochainIdCommande++,
                        IdClient = idClient,
                        DateCommande = dateCommande,
                        Montant = montant,
                        Description = description
                    };

                    commandes.Add(nouvelleCommande);
                    Console.WriteLine("Commande ajoutée !");
                }
            }
            else
            {
                Console.WriteLine("ID client invalide.");
            }
            Console.ReadKey();
        }

        public void ListerCommandesParClient(int idClient)
        {
            var client = clientService.TrouverClientParId(idClient);
            if (client == null)
            {
                Console.WriteLine("Client non trouvé.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"=== Commandes du client {client.Nom} ===");
            var commandesClient = commandes.FindAll(c => c.IdClient == idClient);

            if (commandesClient.Count == 0)
            {
                Console.WriteLine("Aucune commande trouvée.");
            }
            else
            {
                foreach (var cmd in commandesClient)
                {
                    Console.WriteLine($"ID: {cmd.IdCommande} | Date: {cmd.DateCommande:yyyy-MM-dd} | Montant: {cmd.Montant} | Description: {cmd.Description}");
                }
            }
            Console.ReadKey();
        }

        public Commande TrouverCommandeParId(int idCommande)
        {
            return commandes.Find(c => c.IdCommande == idCommande);
        }

        public void ModifierCommande()
        {
            Console.Write("Entrez l'ID de la commande à modifier : ");
            if (int.TryParse(Console.ReadLine(), out int idCommande))
            {
                var cmd = TrouverCommandeParId(idCommande);
                if (cmd == null)
                {
                    Console.WriteLine("Commande non trouvée.");
                }
                else
                {
                    Console.Write("Nouvelle date (yyyy-MM-dd, vide pour garder) : ");
                    string dateStr = Console.ReadLine();
                    if (!string.IsNullOrEmpty(dateStr))
                    {
                        if (DateTime.TryParse(dateStr, out DateTime date))
                        {
                            cmd.DateCommande = date;
                        }
                        else
                        {
                            Console.WriteLine("Date invalide.");
                        }
                    }

                    Console.Write("Nouveau montant (vide pour garder) : ");
                    string montantStr = Console.ReadLine();
                    if (!string.IsNullOrEmpty(montantStr))
                    {
                        if (decimal.TryParse(montantStr, out decimal montant))
                        {
                            cmd.Montant = montant;
                        }
                        else
                        {
                            Console.WriteLine("Montant invalide.");
                        }
                    }

                    Console.Write("Nouvelle description (vide pour garder) : ");
                    string desc = Console.ReadLine();
                    if (!string.IsNullOrEmpty(desc))
                    {
                        cmd.Description = desc;
                    }

                    Console.WriteLine("Commande modifiée !");
                }
            }
            else
            {
                Console.WriteLine("ID invalide.");
            }
            Console.ReadKey();
        }

        public void SupprimerCommande()
        {
            Console.Write("Entrez l'ID de la commande à supprimer : ");
            if (int.TryParse(Console.ReadLine(), out int idCommande))
            {
                var cmd = TrouverCommandeParId(idCommande);
                if (cmd == null)
                {
                    Console.WriteLine("Commande non trouvée.");
                }
                else
                {
                    commandes.Remove(cmd);
                    Console.WriteLine("Commande supprimée !");
                }
            }
            else
            {
                Console.WriteLine("ID invalide.");
            }
            Console.ReadKey();
        }

        public void AfficherCommandesParClient(int idClient)
        {
            var client = clientService.TrouverClientParId(idClient);
            if (client == null)
            {
                Console.WriteLine("Client non trouvé.");
                Console.ReadKey();
                return;
            }

            var commandesClient = commandes.FindAll(c => c.IdClient == idClient);
            decimal total = 0;
            foreach (var cmd in commandesClient)
            {
                total += cmd.Montant;
            }

            Console.WriteLine($"Rapport commandes pour le client {client.Nom} :");
            Console.WriteLine($"Nombre de commandes : {commandesClient.Count}");
            Console.WriteLine($"Montant total : {total} €");
            Console.ReadKey();
        }
    }
}
