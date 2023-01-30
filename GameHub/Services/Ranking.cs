using JogoDaVelha.Controllers;
using HubDeJogos.GameHub.Entities;
using HubDeJogos.GameHub.Repository;
using HubDeJogos.GameHub.Controllers;

namespace HubDeJogos.GameHub.Services
{
    public class Ranking
    {
        private static List<Jogador> ranking = Json.jogadores.OrderBy(jogador => jogador.Pontuacao).ToList();

        public static void AtualizarRanking()
        {
            ranking = Json.jogadores.OrderBy(jogador => jogador.Pontuacao).ThenBy(jogador => jogador.Vitorias).ThenByDescending(jogador => jogador.Derrotas).ToList();
        }

        public static void MostrarRanking()
        {
            Console.Clear();
            Menu.AberturaDoHub();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                    - RANKING DE JOGADORES - ");
            Console.ResetColor();
            AtualizarRanking();
            for (int i = ranking.Count - 1, j = 1; i >= 0; i--, j++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"\n\t{j}º");
                Console.ResetColor();
                Console.WriteLine($" {ranking[i].NomeUsuario}");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"\tPontuação:");
                Console.ResetColor();

                if ((ranking[i].Pontuacao) > 1)
                {
                    Console.WriteLine($" {ranking[i].Pontuacao} pontos");
                }
                else
                {
                    Console.WriteLine($" {ranking[i].Pontuacao} ponto");
                }
            }
            MenuJogoDaVelha.VoltarMenuPrincipal();
        }
    }
}
