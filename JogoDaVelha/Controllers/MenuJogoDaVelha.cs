
using HubDeJogos.GameHub.Repository;

namespace JogoDaVelha.Controllers
{
    public class MenuJogoDaVelha
    {
        public static string LogoInicial = @"     

         ░░█ █▀█ █▀▀ █▀█   █▀▄ ▄▀█   █░█ █▀▀ █░░ █░█ ▄▀█
         █▄█ █▄█ █▄█ █▄█   █▄▀ █▀█   ▀▄▀ ██▄ █▄▄ █▀█ █▀█";


        public static void Abertura()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(LogoInicial);
            Console.ResetColor();
        }

        public static void MenuPrincipal()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Abertura();
            Console.ResetColor();
            Console.WriteLine("                    Bem vindo ao Jogo da Velha!\n\n");
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

        public static void VoltarMenuPrincipal()
        {
            Console.ResetColor();
            Console.Write("\n   Pressione qualquer tecla para voltar ao Hub de Jogos.");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
