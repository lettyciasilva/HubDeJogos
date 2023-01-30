using HubDeJogos.GameHub.Controllers;
using HubDeJogos.GameHub.Entities;
using HubDeJogos.GameHub.Repository;
using HubDeJogos.GameHub.Services;
using HubDeJogos.BatalhaNaval.Controllers;

namespace HubDeJogos.GameHub
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.Title = "HUB de Jogos - Lettycia Cristina";
            Json data = new Json();

            int opcaoHub = 8;

            do
            {
                Console.Clear();
                Menu.MenuHub();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                opcaoHub = int.Parse(Console.ReadLine());
                Console.ResetColor();

                while (opcaoHub < 0 || opcaoHub > 5)
                {
                    Console.Write("\nDigite a opção desejada: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    opcaoHub = int.Parse(Console.ReadLine());
                    Console.ResetColor();
                }

                switch (opcaoHub)
                {
                    case 0: Menu.Encerrar(); break;
                    case 1: Json.Adicionar(); break;
                    case 2: Json.Remover(); break;
                    case 3: Jogador.DetalhesDeUmJogador(); Menu.VoltarAoMenu(); break;
                    case 4: Ranking.MostrarRanking(); break;

                    case 5:
                        {
                            Console.Clear();
                            Json.LoginJogadores();
                            Menu.MenuDeJogos();
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
                                JogoDaVelha.Start.StartGame.StartingGame();
                            }

                            if (opcao == 2)
                            {
                                MenusBatalhaNaval.MenuBatalhaNaval();
                            }

                            else
                            {
                                break;
                            }

                        }
                        break;

                }


            } while (opcaoHub != 0);

        }

    }


}