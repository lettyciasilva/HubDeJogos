using JogoDaVelha.Services;
using JogoDaVelha.Controllers;
using HubDeJogos.GameHub.Repository;
using HubDeJogos.GameHub.Controllers;
using HubDeJogos.GameHub.Entities;


namespace HubDeJogos.JogoDaVelha.Start
{
    public class StartGame
    {
        public static void StartingGame()
        {
            Json data = new Json();
            int opcaoMenu = 9;

            string Jogador1 = Json.Jogador1;
            string Jogador2 = Json.Jogador2;


            Console.Clear();
            MenuJogoDaVelha.MenuPrincipal();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            opcaoMenu = int.Parse(Console.ReadLine());
            Console.ResetColor();

            while (opcaoMenu < 0 || opcaoMenu > 2)
            {
                Console.Write("\nDigite a opção desejada: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                opcaoMenu = int.Parse(Console.ReadLine());
                Console.ResetColor();
            }

            switch (opcaoMenu)
            {
                case 0:
                    Menu.MenuDeJogos();
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        int opcao = int.Parse(Console.ReadLine());
                        Console.ResetColor();

                        while (opcao > 2)
                        {
                            Console.Write("\nDigite a opção desejada: ");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            opcao = int.Parse(Console.ReadLine());
                            Console.ResetColor();
                        }

                        if (opcao == 1)
                        {
                            StartingGame();
                        }

                        if (opcao == 2)
                        {
                            Console.WriteLine("SERA INICIALIZADO A BATALHA NAVAL");
                        }

                        else
                        {
                            break;
                        }
                    }
                    break;

                case 1: Jogar.Iniciar(Jogador1, Jogador2); break;
                case 2: Jogador.DetalhesDeUmJogador(); Menu.VoltarAoMenuJogoDaVelha(); break;
            }


        }
    }
}
