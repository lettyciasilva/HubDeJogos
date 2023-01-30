using HubDeJogos.GameHub.Controllers;
using HubDeJogos.GameHub.Entities;
using Newtonsoft.Json;


namespace HubDeJogos.GameHub.Repository
{
    public class Json
    {
        public static string? Jogador1;
        public static string? Jogador2;

        private static string path = "Dados.json";

        public static List<Jogador> jogadores = Desserializar();


        public Json()
        {
            if (!File.Exists(path)) File.Create(path).Close();
        }

        public static void LoginJogadores()
        {
            Console.Clear();
            Menu.AberturaDoHub();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                      - LOGIN DE JOGADORES - ");
            Console.ResetColor();

            Console.Write("\n\n\tDigite o nome do");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" primeiro ");
            Console.ResetColor();
            Console.Write("player: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string jogador1 = Console.ReadLine().ToUpper();
            jogador1 = Menu.JogadorNaoEncontrado(jogador1);

            Console.ResetColor();
            Console.Write("\tSenha de acesso: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string senhadigitada = Menu.GetPassword();
            Console.ResetColor();

            while ((jogadores.Find(player => player.NomeUsuario == jogador1).SenhaUsuario != senhadigitada))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tSenha incorreta. Tente novamente.");
                Console.ResetColor();
                Console.Write("\tSenha de acesso: ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                senhadigitada = Menu.GetPassword();
                Console.ResetColor();
            }
            Jogador1 = jogador1;
            Console.ResetColor();

            Console.Write("\n\n\tDigite o nome do");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" segundo ");
            Console.ResetColor();
            Console.Write("player: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string jogador2 = Console.ReadLine().ToUpper();
            jogador2 = Menu.JogadorNaoEncontrado(jogador2);

            Console.ResetColor();
            Console.Write("\tSenha de acesso: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            senhadigitada = Menu.GetPassword();
            Console.ResetColor();

            while ((jogadores.Find(player => player.NomeUsuario == jogador2).SenhaUsuario != senhadigitada))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tSenha incorreta. Tente novamente.");
                Console.ResetColor();
                Console.Write("\tSenha de acesso: ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                senhadigitada = Menu.GetPassword();
                Console.ResetColor();
            }
            Jogador2 = jogador2;
            Console.ResetColor();

        }

        public static void Adicionar()
        {
            Console.Clear();
            Menu.AberturaDoHub();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                       - CADASTRAR JOGADOR - ");
            Console.ResetColor();
            string nomeUsuario = Menu.NomeJogador();
            nomeUsuario = Menu.JogadorJaCadastrado(nomeUsuario);
            string senhaUsuario = Menu.SenhaJogador();
            Jogador jogador = new Jogador(nomeUsuario, senhaUsuario);
            jogadores.Add(jogador);

            Serializar();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\tJogador {nomeUsuario} cadastrado com sucesso.");
            Console.ResetColor();
            Menu.VoltarAoMenu();
        }

        public static void Remover()
        {
            Console.Clear();
            Menu.AberturaDoHub();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                       - DELETAR JOGADOR - ");
            Console.ResetColor();
            string nomeUsuario = Menu.NomeJogador();
            nomeUsuario = Menu.JogadorNaoEncontrado(nomeUsuario);
            
            string senhaadmin = "0123";
            Console.ResetColor();
            Console.WriteLine("\n\tOBSERVAÇÃO: Para deletar um usuário é necessário");
            Console.WriteLine("\t\tinformar a senha de Administrador!");
            Console.Write("\n\tSenha de Administrador: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            senhaadmin = Menu.GetPassword();
            Console.ResetColor();


            if (senhaadmin != "0123")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tSenha de ADMINISTRADOR incorreta!");
                Console.WriteLine("\tUsuário não deletado!");
                Console.ResetColor();
                Menu.VoltarAoMenu();

            }
            else
            {
                jogadores.RemoveAll(player => player.NomeUsuario == nomeUsuario);
                Serializar();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tJogador deletado com sucesso.");
                Console.ResetColor();
                Menu.VoltarAoMenu();
            }
        }

        public static void Serializar()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, jogadores);
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\t{e.Message}");
                Console.ResetColor();
            }
        }

        public static List<Jogador> Desserializar()
        {
            List<Jogador> jogadores = new List<Jogador>();
            
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string jsonString = sr.ReadToEnd();
                    jogadores = JsonConvert.DeserializeObject<List<Jogador>>(jsonString);
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\t{e.Message}");
                Console.ResetColor();
            }
            return jogadores;
        }

    }
}
