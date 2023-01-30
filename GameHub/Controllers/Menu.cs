using System;
using HubDeJogos.GameHub.Repository;

namespace HubDeJogos.GameHub.Controllers
{
    public class Menu
    {
        public static string LogoHub = @"               

           █░█ █░█ █▄▄   █▀▄ █▀▀   ░░█ █▀█ █▀▀ █▀█ █▀
           █▀█ █▄█ █▄█   █▄▀ ██▄   █▄█ █▄█ █▄█ █▄█ ▄█";


        public static void AberturaDoHub()
        {
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine(LogoHub);
            Console.ResetColor();
        }

        public static void MenuHub()
        {
            AberturaDoHub();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                   Bem vindo! É hora de jogar!\n\n");
            Console.ResetColor();
            Console.WriteLine("OPÇÕES DISPONÍVEIS:\n");
            Console.Write("1");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" - ");
            Console.ResetColor();
            Console.WriteLine("Cadastrar Jogador");
            Console.Write("2");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" - ");
            Console.ResetColor();
            Console.WriteLine("Deletar um Jogador");
            Console.Write("3");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" - ");
            Console.ResetColor();
            Console.WriteLine("Detalhes de um Jogador");
            Console.Write("4");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" - ");
            Console.ResetColor();
            Console.WriteLine("Ranking de Jogadores");
            Console.Write("5");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" - ");
            Console.ResetColor();
            Console.WriteLine("Jogos");
            Console.Write("0");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" - ");
            Console.ResetColor();
            Console.WriteLine("Encerrar o Programa");

            Console.Write("\nDigite a opção desejada: ");
        }

        public static void VoltarAoMenu()
        {
            Console.ResetColor();
            Console.Write("\n    Pressione qualquer tecla para voltar ao Hub de Jogos.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void VoltarAoMenuJogoDaVelha()
        {
            Console.ResetColor();
            Console.Write("\n    Pressione qualquer tecla para voltar ao Jogo da Velha.");
            Console.ReadKey();
            Console.Clear();
            JogoDaVelha.Start.StartGame.StartingGame();
        }

        public static string NomeJogador()
        {
            Console.ResetColor();
            Console.Write("\n\tDigite o nome: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string name = Console.ReadLine().ToUpper();
            return name;
            Console.ResetColor();
        }

        public static string SenhaJogador()
        {
            Console.ResetColor();
            Console.Write("\n\tCadastre uma senha (4 digitos): ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string key = GetPassword();
            Console.ResetColor();

            while (key.Length != 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tErro: A senha deve possuir 4 digítos!");
                Console.ResetColor();
                Console.Write("\n\tCadastre uma senha (4 digítos): ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                key = GetPassword();
                Console.ResetColor();
            }
            return key;
            Console.ResetColor();
        }

        public static string JogadorJaCadastrado(string nomeUsuario)
        {
            while (Json.jogadores.Any(player => player.NomeUsuario == nomeUsuario))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tJogador já cadastrado. Insira outro Nome de Usuário.");
                Console.ResetColor();
                nomeUsuario = NomeJogador();
            }
            return nomeUsuario;
        }

        public static string JogadorNaoEncontrado(string nomeUsuario)
        {
            while (!Json.jogadores.Any(player => player.NomeUsuario == nomeUsuario))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tJogador não cadastrado. Tente novamente.");
                Console.ResetColor();
                nomeUsuario = NomeJogador();
            }
            return nomeUsuario;
        }

        public static void Encerrar()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nEncerrando o Programa...");
            Console.ResetColor();
        }

        public static void MenuDeJogos()
        {
            Console.Clear();
            AberturaDoHub();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                       JOGOS DISPONIVEIS!\n\n");
            Console.ResetColor();

            Console.WriteLine("OPÇÕES DISPONÍVEIS:\n");

            Console.Write("1");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" - ");
            Console.ResetColor();
            Console.WriteLine("Jogo da Velha");
            Console.Write("2");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" - ");
            Console.ResetColor();
            Console.WriteLine("Batalha Naval");
            Console.Write("0");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" - ");
            Console.ResetColor();
            Console.WriteLine("Voltar ao Hub de Jogos");

            Console.Write("\nDigite a opção desejada: ");

        }

        public static string GetPassword()
        {
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            Console.WriteLine();
            return pass;
        }



    }








}
