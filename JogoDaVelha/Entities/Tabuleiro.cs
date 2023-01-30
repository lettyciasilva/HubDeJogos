using JogoDaVelha.Controllers;
using JogoDaVelha.Services;
using HubDeJogos.GameHub.Repository;
using HubDeJogos.GameHub.Entities;

namespace JogoDaVelha.Entities
{
    public class Tabuleiro
    {
        public static string LogoInicial = @"     

         ░░█ █▀█ █▀▀ █▀█   █▀▄ ▄▀█   █░█ █▀▀ █░░ █░█ ▄▀█
         █▄█ █▄█ █▄█ █▄█   █▄▀ █▀█   ▀▄▀ ██▄ █▄▄ █▀█ █▀█";




        public static string[,] GerarTabuleiro()
        {
            string[,] matriz = new string[3, 3];
            int posicao = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matriz[i, j] = posicao.ToString();
                    posicao++;
                }
            }
            return matriz;
        }

        public static void MostrarTabuleiro(string[,] tabuleiro, string Jogador1, string Jogador2)
        {
            int maior;
            string tab;
            maior = 1;
            tab = "_____|";

            string str = string.Concat(Enumerable.Repeat(tab, 3));
            str = str.Remove(str.Length - 1);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(MenuJogoDaVelha.LogoInicial);
            Console.ResetColor();
            Jogar.MostrarLogados(Jogador1,Jogador2);


            Console.WriteLine("\n");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("         \t\t ");
                for (int j = 0; j < 3 - 1; j++)
                {
                    if (tabuleiro[i, j] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("  {0}", tabuleiro[i, j].ToString().PadLeft(maior));
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else if (tabuleiro[i, j] == "O")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("  {0}", tabuleiro[i, j].ToString().PadLeft(maior));
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else Console.Write("  {0}  |", tabuleiro[i, j].ToString().PadLeft(maior));
                }
                if (tabuleiro[i, 3 - 1] == "X")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("  {0}\n", tabuleiro[i, 3 - 1].ToString().PadLeft(maior));
                    Console.ResetColor();
                }
                else if (tabuleiro[i, 3 - 1] == "O")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("  {0}\n", tabuleiro[i, 3 - 1].ToString().PadLeft(maior));
                    Console.ResetColor();
                }
                else Console.Write("  {0}\n", tabuleiro[i, 3 - 1].ToString().PadLeft(maior));
                if (i != 3 - 1)
                {
                    Console.WriteLine("         \t\t {0}", str);
                }

                else
                {
                    Console.WriteLine("         \t\t {0}", str.Replace('_', ' '));
                }
            }
        }

        public static void AlterarTabuleiro(string escolhaDaPosicao, string[,] tabuleiro, string vez)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tabuleiro[i, j] == escolhaDaPosicao)
                    {
                        tabuleiro[i, j] = vez;
                        break;
                    }
                }
            }
        }

        public static bool VerificarGanhador(string[,] tabuleiro, string vez)
        {
            int somaDiagPrin = 0;
            int somaDiagSec = 0;
            for (int i = 0; i < 3; i++)
            {
                int somaLinha = 0;
                int somaColuna = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (tabuleiro[i, j] == vez) somaLinha++;
                    if (tabuleiro[j, i] == vez) somaColuna++;
                    if (i == j && tabuleiro[i, i] == vez) somaDiagPrin++;
                    if (i + j == 3 - 1 && tabuleiro[i, j] == vez) somaDiagSec++;
                }
                if (somaLinha == 3) return true;
                if (somaColuna == 3) return true;
            }
            if (somaDiagPrin == 3) return true;
            if (somaDiagSec == 3) return true;
            return false;
        }

        public static bool VerificarEmpate(string[,] tabuleiro)
        {
            int empate = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tabuleiro[i, j] == "X" || tabuleiro[i, j] == "O")
                        empate++;
                }
            }
            if (empate == 9) return true;
            return false;
        }


    }

}
