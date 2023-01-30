
using JogoDaVelha.Controllers;
using JogoDaVelha.Entities;
using HubDeJogos.GameHub.Repository;
using HubDeJogos.GameHub.Services;

namespace JogoDaVelha.Services
{
    public class Jogar 
    {
        private  static List<string> posicoes = new List<string>();

        public static void MostrarLogados(string Jogador1, string Jogador2)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\tJogador 1: {Jogador1}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\tJogador 2: {Jogador2}");
            Console.ResetColor();
        }

        public static string[,] ChamarTabuleiro()
        {
            string[,] tabuleiro = Tabuleiro.GerarTabuleiro();
            return tabuleiro;
        }

        public static void Iniciar(string Jogador1, string Jogador2)
        {
            RegrasDoJogo();

            string[,] tabuleiro = ChamarTabuleiro();
            string escolhaDaPosicao;
            int rodada = 1;

            while (true)
            {
                Tabuleiro.MostrarTabuleiro(tabuleiro,Jogador1,Jogador2);

                if (rodada % 2 != 0)
                {
                    escolhaDaPosicao = LerEscolhaDoUsuario(Jogador1, "X");
                    Tabuleiro.AlterarTabuleiro(escolhaDaPosicao, tabuleiro, "X");
                    Tabuleiro.MostrarTabuleiro(tabuleiro, Jogador1, Jogador2);

                    if (Tabuleiro.VerificarGanhador(tabuleiro, "X"))
                    {
                        Tabuleiro.MostrarTabuleiro(tabuleiro, Jogador1, Jogador2);

                        Console.ResetColor();
                        Console.Write($"\nParabéns");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($" {Jogador1} ");
                        Console.ResetColor();
                        Console.WriteLine("você ganhou!!!\n");

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("PONTUAÇÃO DA PARTIDA:");
                        Console.ResetColor();
                        Console.Write($"{Jogador1} : ");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("3 pontos");
                        Console.ResetColor();
                        Console.Write($"{Jogador2} : ");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("0 ponto");
                        Console.ResetColor();
                        Json.jogadores.Find(player => player.NomeUsuario == Jogador1).Partidas += 1;
                        Json.jogadores.Find(player => player.NomeUsuario == Jogador2).Partidas += 1;
                        Json.jogadores.Find(player => player.NomeUsuario == Jogador1).Vitorias += 1;
                        Json.jogadores.Find(player => player.NomeUsuario == Jogador2).Derrotas += 1;
                        Json.jogadores.Find(player => player.NomeUsuario == Jogador1).Pontuacao += 3;

                        Ranking.AtualizarRanking();
                        Json.Serializar();
                        posicoes.Clear();
                        MenuJogoDaVelha.VoltarMenuPrincipal();
                        break;
                    }
                    rodada++;
                }

                else
                {
                    escolhaDaPosicao = LerEscolhaDoUsuario(Jogador2, "O");
                    Tabuleiro.AlterarTabuleiro(escolhaDaPosicao, tabuleiro, "O");
                    Tabuleiro.MostrarTabuleiro(tabuleiro, Jogador1, Jogador2);

                    if (Tabuleiro.VerificarGanhador(tabuleiro, "O"))
                    {
                        Console.ResetColor();
                        Console.Write($"\nParabéns");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write($" {Jogador2} ");
                        Console.ResetColor();
                        Console.WriteLine("você ganhou!!!\n");

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("PONTUAÇÃO DA PARTIDA:");
                        Console.ResetColor();
                        Console.Write($"{Jogador2} : ");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("3 pontos");
                        Console.ResetColor();
                        Console.Write($"{Jogador1} : ");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("0 ponto");
                        Json.jogadores.Find(player => player.NomeUsuario == Jogador1).Partidas += 1;
                        Json.jogadores.Find(player => player.NomeUsuario == Jogador2).Partidas += 1;
                        Json.jogadores.Find(player => player.NomeUsuario == Jogador2).Vitorias += 1;
                        Json.jogadores.Find(player => player.NomeUsuario == Jogador1).Derrotas += 1;
                        Json.jogadores.Find(player => player.NomeUsuario == Jogador2).Pontuacao += 3;
                        Ranking.AtualizarRanking();
                        Json.Serializar();
                        posicoes.Clear();
                        MenuJogoDaVelha.VoltarMenuPrincipal();
                        break;
                    }
                    rodada++;

                }

                if (Tabuleiro.VerificarEmpate(tabuleiro))
                {
                    Tabuleiro.MostrarTabuleiro(tabuleiro, Jogador1, Jogador2);
                    Console.ResetColor();

                    Console.WriteLine("\n\nDeu EMPATE, ninguém ganhou!!!\n");

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("PONTUAÇÃO DA PARTIDA:");
                    Console.ResetColor();
                    Console.Write($"{Jogador1} : ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("1 ponto");
                    Console.ResetColor();
                    Console.Write($"{Jogador2} : ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("1 ponto");
                    Console.ResetColor();

                    Json.jogadores.Find(player => player.NomeUsuario == Jogador1).Partidas += 1;
                    Json.jogadores.Find(player => player.NomeUsuario == Jogador2).Partidas += 1;
                    Json.jogadores.Find(player => player.NomeUsuario == Jogador1).Pontuacao += 1;
                    Json.jogadores.Find(player => player.NomeUsuario == Jogador2).Pontuacao += 1;
                    Json.jogadores.Find(player => player.NomeUsuario == Jogador1).Empates += 1;
                    Json.jogadores.Find(player => player.NomeUsuario == Jogador2).Empates += 1;
                    Ranking.AtualizarRanking();
                    Json.Serializar();
                    posicoes.Clear();
                    MenuJogoDaVelha.VoltarMenuPrincipal();
                    break;
                }
            }

        }

        public static string LerEscolhaDoUsuario(string jogador, string vez)
        {
            string posicao;
            Console.ResetColor();

            if (vez == "X")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"  \n\t\t{jogador}");
                Console.Write($" [{vez}]");
                Console.ResetColor();
                Console.WriteLine(" é a sua vez!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"  \n\t\t{jogador}");
                Console.Write($" [{vez}]");
                Console.ResetColor();
                Console.WriteLine(" é a sua vez!");
            }

            Console.Write("\t\t\tDigite a posição: ");
            Console.ResetColor();

            if (vez == "X")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                posicao = Console.ReadLine();
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                posicao = Console.ReadLine();
                Console.ResetColor();
            }

            int number;
            while (posicoes.Contains(posicao) || !int.TryParse(posicao, out number) || number < 1 || number > 9)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tPosição indisponível.");
                Console.ResetColor();
                Console.Write("\t\t\tDigite a posição: ");
                if (vez == "X")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    posicao = Console.ReadLine();
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    posicao = Console.ReadLine();
                    Console.ResetColor();
                }
            }
            posicoes.Add(posicao);
            return posicao;
        }

        public static void RegrasDoJogo()
        {
            Console.Clear();
            MenuJogoDaVelha.Abertura();
            Console.ResetColor();
            Console.WriteLine("                       - REGRAS DO JOGO - ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\n           Antes de iniciar, leia as regras do jogo:");
            Console.ResetColor();

            Console.WriteLine("\n* O tabuleiro  é uma matriz  de três linhas por três colunas.");
            Console.WriteLine("\n* Os jogadores jogam alternadamente, uma marcação por vez, numa lacuna que esteja vazia.");
            Console.WriteLine("\n* O objetivo é conseguir três O ou três X em linha,\n " +
                "quer horizontal, vertical ou diagonal , quando possível, \n" +
                "impedir o adversário de ganhar na próxima jogada.");
            Console.WriteLine("\n* Ao ganhar a partida o jogador ganha 3 pontos. \n" +
                "* Em caso de derrota não recebe pontuação. \n" +
                "* Se terminar em empate, ambos jogadores ganham 1 ponto.");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\n\n         Pressione qualquer tecla para prosseguir...");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();

        }
    }
}
