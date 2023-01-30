using HubDeJogos.GameHub.Controllers;
using HubDeJogos.GameHub.Repository;

namespace HubDeJogos.GameHub.Entities
{
    public class Jogador
    {
        public string NomeUsuario { get; set; }
        public string SenhaUsuario { get; set; }    
        public int Partidas { get; set; }
        public int Pontuacao { get; set; }
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }
        public int Empates { get; set; }

        public Jogador(string nomeUsuario, string senhaUsuario)
        {
            NomeUsuario = nomeUsuario;
            SenhaUsuario = senhaUsuario;
            Partidas = 0;
            Pontuacao = 0;
            Vitorias = 0;
            Derrotas = 0;
            Empates = 0;
        }

        public static void DetalhesDeUmJogador()
        {
            Console.Clear();
            Menu.AberturaDoHub();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                    - DETALHES DE UM JOGADOR - ");
            Console.ResetColor();
            string nomeUsuario = Menu.NomeJogador();

            while (!Json.jogadores.Any(player => player.NomeUsuario == nomeUsuario))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tJogador não cadastrado. Tente novamente.");
                Console.ResetColor();
                nomeUsuario = Menu.NomeJogador();
            }

            Console.ResetColor();
            Console.Write($"\n\tPartidas:");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($" {Json.jogadores.Find(player => player.NomeUsuario == nomeUsuario).Partidas}");

            Console.ResetColor();
            Console.Write($"\tPontos:");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($" {Json.jogadores.Find(player => player.NomeUsuario == nomeUsuario).Pontuacao}");

            Console.ResetColor();
            Console.Write($"\tVitórias:");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($" {Json.jogadores.Find(player => player.NomeUsuario == nomeUsuario).Vitorias}");

            Console.ResetColor();
            Console.Write($"\tDerrotas:");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($" {Json.jogadores.Find(player => player.NomeUsuario == nomeUsuario).Derrotas}");

            Console.ResetColor();
            Console.Write($"\tEmpates:");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($" {Json.jogadores.Find(player => player.NomeUsuario == nomeUsuario).Empates}");
            Console.ResetColor();

        }

    }

}
