using System;
using ProjetGestionClientsCommandes.Services;

namespace ProjetGestionClientsCommandes
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientService clientService = new ClientService();
            CommandeService commandeService = new CommandeService(clientService);

            bool quitter = false;

            while (!quitter)
            {
                Console.Clear();
                Console.WriteLine("=== Gestion Clients & Commandes ===");
                Console.WriteLine("1. Ajouter un client");
                Console.WriteLine("2. Lister les clients");
                Console.WriteLine("3. Ajouter une commande");
                Console.WriteLine("4. Lister les commandes d’un client");
                Console.WriteLine("5. Modifier un client");
                Console.WriteLine("6. Supprimer un client");
                Console.WriteLine("7. Modifier une commande");
                Console.WriteLine("8. Supprimer une commande");
                Console.WriteLine("9. Rapport : Commandes d’un client");
                Console.WriteLine("0. Quitter");
                Console.Write("Choix : ");

                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        clientService.AjouterClient();
                        break;
                    case "2":
                        clientService.ListerClients();
                        break;
                    case "3":
                        commandeService.AjouterCommande();
                        break;
                    case "4":
                        Console.Write("Entrez l'ID du client : ");
                        if (int.TryParse(Console.ReadLine(), out int idClient))
                        {
                            commandeService.ListerCommandesParClient(idClient);
                        }
                        else
                        {
                            Console.WriteLine("ID invalide.");
                            Console.ReadKey();
                        }
                        break;
                    case "5":
                        clientService.ModifierClient();
                        break;
                    case "6":
                        clientService.SupprimerClient();
                        break;
                    case "7":
                        commandeService.ModifierCommande();
                        break;
                    case "8":
                        commandeService.SupprimerCommande();
                        break;
                    case "9":
                        Console.Write("Entrez l'ID du client pour le rapport : ");
                        if (int.TryParse(Console.ReadLine(), out int idClientRapport))
                        {
                            commandeService.AfficherCommandesParClient(idClientRapport);
                        }
                        else
                        {
                            Console.WriteLine("ID invalide.");
                            Console.ReadKey();
                        }
                        break;
                    case "0":
                        quitter = true;
                        break;
                    default:
                        Console.WriteLine("Choix invalide.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
