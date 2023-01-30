using HubDeJogos.GameHub.Controllers;
using HubDeJogos.GameHub.Entities;
using HubDeJogos.GameHub.Repository;
using HubDeJogos.BatalhaNaval.Entities;

namespace HubDeJogos.BatalhaNaval.Controllers
{
    public class MenusBatalhaNaval
    {
        public static string LogoBatalha = @"

         █▄▄ ▄▀█ ▀█▀ ▄▀█ █░░ █░█ ▄▀█   █▄░█ ▄▀█ █░█ ▄▀█ █░░
         █▄█ █▀█ ░█░ █▀█ █▄▄ █▀█ █▀█   █░▀█ █▀█ ▀▄▀ █▀█ █▄▄";

        public static string Vencedor = @"
                                # #  ( )
                             ___#_#___|__
                         _  |____________|  _
                  _=====| | |            | | |==== _
         =====| |.---------------------------. | |====
   <----'   .  .  .  .  .  .  .  .   '      ------------/
     \                                                 /
      \_______________________________________________/";

        public static void MenuPrincipal()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(LogoBatalha);
            Console.ResetColor();
            Console.WriteLine("                    Bem vindo ao Batalha Naval!\n\n");
            Console.ResetColor();

            Console.WriteLine("OPÇÕES DISPONÍVEIS:\n");

            Console.Write("1");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" - ");
            Console.ResetColor();
            Console.WriteLine("Novo Jogo");
            Console.Write("2");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" - ");
            Console.ResetColor();
            Console.WriteLine("Detalhes de um Jogador");
            Console.Write("0");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" - ");
            Console.ResetColor();
            Console.WriteLine("Retornar aos Jogos");

            Console.Write("\nDigite a opção desejada: ");
        }

        public static void MenuBatalhaNaval()
        {
            Json data = new Json();
            int opcaoMenu = 9;

            string Jogador1 = Json.Jogador1;
            string Jogador2 = Json.Jogador2;


            Console.Clear();
            MenuPrincipal();

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
                            JogoDaVelha.Start.StartGame.StartingGame();
                        }

                        if (opcao == 2)
                        {
                            MenuBatalhaNaval();
                        }

                        else
                        {
                            break;
                        }
                    }
                    break;

                case 1: TabuleirosBatalhaNaval.RegrasDoJogo(); TabuleirosBatalhaNaval.StartingGame(); break;
                case 2: Jogador.DetalhesDeUmJogador(); VoltarAoMenuBatalhaNaval(); break;
            }


        }

        public static void VoltarAoMenuBatalhaNaval()
        {
            Console.ResetColor();
            Console.Write("\n    Pressione qualquer tecla para voltar ao Batalha Naval.");
            Console.ReadKey();
            Console.Clear();
            MenuBatalhaNaval();
        }





    }
}
