using HubDeJogos.BatalhaNaval.Controllers;
using HubDeJogos.GameHub.Controllers;
using HubDeJogos.GameHub.Repository;
using HubDeJogos.GameHub.Services;


namespace HubDeJogos.BatalhaNaval.Entities
{
    public class TabuleirosBatalhaNaval
    {

        static char[] linhas = new char[10] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        static int[] colunas = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static char[,] tabuleiro_jogador1 = new char[10, 10];
        static char[,] tabuleiro_jogador2 = new char[10, 10];
        static bool haVencedor = false;
        static bool[] barcosJogador1 = new bool[4] { false, false, false, false };
        static bool[] barcosJogador2 = new bool[4] { false, false, false, false };
        static char cordX = '0';
        static int cordY = 0;
        static int jogador1 = 13;
        static int jogador2 = 13;
        static string rodada = "jogador1";
        static bool prontoJogador1 = false;
        static bool prontoJogador2 = false;


        string Jogador1 = Json.Jogador1;
        string Jogador2 = Json.Jogador2;

        public static void IniciarMatriz()
        {
            for (int f = 0; f < linhas.Length; f++)
            {
                for (int c = 0; c < colunas.Length; c++)
                {
                    tabuleiro_jogador1[f, c] = ' ';
                    tabuleiro_jogador2[f, c] = ' ';
                }
            }
        }

        public static void TabuleiroJogador1(string Jogador1)
        {
            Console.Clear();
            Console.WriteLine(MenusBatalhaNaval.LogoBatalha);
            Console.Write("\n                      TABULEIRO DE: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Jogador1}\n");
            Console.WriteLine("       1   2   3   4   5   6   7   8   9   10");
            Console.ResetColor();
            Console.WriteLine("     ┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐");
            for (int f = 0; f < linhas.Length; f++)
            {
                Console.Write("   ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{linhas[f]}");
                Console.ResetColor();
                Console.Write(" │");
                for (int c = 0; c < colunas.Length; c++)
                {
                    if (c != 10)
                    {
                        Console.Write(" " + tabuleiro_jogador1[f, c] + " │");
                    }
                }
                Console.WriteLine();
                if (f != 9)
                    Console.WriteLine("     ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤  ");
            }
            Console.WriteLine("     └───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘");
        }


        public static void TabuleiroJogador2(string Jogador2)
        {
            Console.Clear();
            Console.WriteLine(MenusBatalhaNaval.LogoBatalha);
            Console.Write("\n                      TABULEIRO DE: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{Jogador2}\n");
            Console.WriteLine("       1   2   3   4   5   6   7   8   9   10");
            Console.ResetColor();
            Console.WriteLine("     ┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐");
            for (int f = 0; f < linhas.Length; f++)
            {
                Console.Write("   ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{linhas[f]}");
                Console.ResetColor();
                Console.Write(" │");
                for (int c = 0; c < colunas.Length; c++)
                {
                    if (c != 10)
                    {
                        Console.Write(" " + tabuleiro_jogador2[f, c] + " │");
                    }
                }
                Console.WriteLine();
                if (f != 9)
                    Console.WriteLine("     ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤  ");
            }
            Console.WriteLine("     └───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘");
        }


        public static void colocarBarcos(int op)
        {

            switch (op)
            {
                case 4:
                    if (barcosJogador1[op - 1] == false)
                    {
                        Console.ResetColor();
                        Console.WriteLine("Colocar Porta Aviões 44444");
                        Console.Write("Linha (A - J): ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        cordX = Convert.ToChar(Console.ReadLine().ToUpper());
                        Console.ResetColor();
                        Console.Write("Coluna (1 - 10): ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        cordY = Convert.ToInt32(Console.ReadLine());
                        Console.ResetColor();
                        if (cordY >= 1 && cordY <= 6)
                        {
                            if (tabuleiro_jogador1[valor(cordX), (cordY - 1)] == ' ' && tabuleiro_jogador1[valor(cordX), (cordY)] == ' ' && tabuleiro_jogador1[valor(cordX), (cordY + 1)] == ' '
                                && tabuleiro_jogador1[valor(cordX), (cordY + 2)] == ' ' && tabuleiro_jogador1[valor(cordX), (cordY + 3)] == ' ')
                            {
                                tabuleiro_jogador1[valor(cordX), (cordY - 1)] = '4'; 
                                tabuleiro_jogador1[valor(cordX), (cordY)] = '4';
                                tabuleiro_jogador1[valor(cordX), (cordY + 1)] = '4';
                                tabuleiro_jogador1[valor(cordX), (cordY + 2)] = '4';
                                tabuleiro_jogador1[valor(cordX), (cordY + 3)] = '4';
                                barcosJogador1[op - 1] = true;
                            }
                        }
                    }
                    break;
                case 3:
                    if (barcosJogador1[op - 1] == false)
                    {
                        Console.ResetColor();
                        Console.WriteLine("Colocar Cruzador 333");
                        Console.Write("Linha (A - J): ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        cordX = Convert.ToChar(Console.ReadLine().ToUpper());
                        Console.ResetColor();
                        Console.Write("Coluna (1 - 10): ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        cordY = Convert.ToInt32(Console.ReadLine());
                        Console.ResetColor();
                        if (cordY >= 1 && cordY <= 8)
                        {
                            if (tabuleiro_jogador1[valor(cordX), (cordY - 1)] == ' ' && tabuleiro_jogador1[valor(cordX), (cordY)] == ' ' && tabuleiro_jogador1[valor(cordX), (cordY + 1)] == ' ')
                            {
                                tabuleiro_jogador1[valor(cordX), (cordY - 1)] = '3';
                                tabuleiro_jogador1[valor(cordX), (cordY)] = '3';
                                tabuleiro_jogador1[valor(cordX), (cordY + 1)] = '3';
                                barcosJogador1[op - 1] = true;
                            }
                        }
                    }
                    break;
                case 2:
                    if (barcosJogador1[op - 1] == false)
                    {
                        Console.ResetColor();
                        Console.WriteLine("Colocar Submarino 222");
                        Console.Write("Linha (A - J): ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        cordX = Convert.ToChar(Console.ReadLine().ToUpper());
                        Console.ResetColor();
                        Console.Write("Coluna (1 - 10): ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        cordY = Convert.ToInt32(Console.ReadLine());
                        Console.ResetColor();
                        if (cordY >= 1 && cordY <= 8)
                        {
                            if (tabuleiro_jogador1[valor(cordX), (cordY - 1)] == ' ' && tabuleiro_jogador1[valor(cordX), (cordY)] == ' ' && tabuleiro_jogador1[valor(cordX), (cordY + 1)] == ' ')
                            {
                                tabuleiro_jogador1[valor(cordX), (cordY - 1)] = '2'; 
                                tabuleiro_jogador1[valor(cordX), (cordY)] = '2';
                                tabuleiro_jogador1[valor(cordX), (cordY + 1)] = '2';
                                barcosJogador1[op - 1] = true;
                            }
                        }
                    }
                    break;
                case 1:
                    if (barcosJogador1[op - 1] == false)
                    {
                        Console.ResetColor();
                        Console.WriteLine("Colocar Destroyer 11");
                        Console.Write("Linha (A - J): ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        cordX = Convert.ToChar(Console.ReadLine().ToUpper());
                        Console.ResetColor();
                        Console.Write("Coluna (1 - 10): ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        cordY = Convert.ToInt32(Console.ReadLine());
                        Console.ResetColor();
                        if (cordY >= 1 && cordY <= 8)
                        {
                            if (tabuleiro_jogador1[valor(cordX), (cordY - 1)] == ' ' && tabuleiro_jogador1[valor(cordX), (cordY)] == ' ')
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                tabuleiro_jogador1[valor(cordX), (cordY - 1)] = '1'; 
                                tabuleiro_jogador1[valor(cordX), (cordY)] = '1';
                                barcosJogador1[op - 1] = true;
                            }
                        }
                    }
                    break;
            }
        }

        public static void colocarBarcosJogador2(int op)
        {


            switch (op)
            {
                case 4:
                    if (barcosJogador2[op - 1] == false)
                    {
                        Console.ResetColor();
                        Console.WriteLine("Colocar Porta Aviões 44444");
                        Console.Write("Linha (A - J): ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        cordX = Convert.ToChar(Console.ReadLine().ToUpper());
                        Console.ResetColor();
                        Console.Write("Coluna (1 - 10): ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        cordY = Convert.ToInt32(Console.ReadLine());
                        Console.ResetColor();
                        if (cordY >= 1 && cordY <= 6)
                        {
                            if (tabuleiro_jogador2[valor(cordX), (cordY - 1)] == ' ' && tabuleiro_jogador2[valor(cordX), (cordY)] == ' ' && tabuleiro_jogador2[valor(cordX), (cordY + 1)] == ' '
                                && tabuleiro_jogador2[valor(cordX), (cordY + 2)] == ' ' && tabuleiro_jogador2[valor(cordX), (cordY + 3)] == ' ')
                            {
                                tabuleiro_jogador2[valor(cordX), (cordY - 1)] = '4'; 
                                tabuleiro_jogador2[valor(cordX), (cordY)] = '4';
                                tabuleiro_jogador2[valor(cordX), (cordY + 1)] = '4';
                                tabuleiro_jogador2[valor(cordX), (cordY + 2)] = '4';
                                tabuleiro_jogador2[valor(cordX), (cordY + 3)] = '4';
                                barcosJogador2[op - 1] = true;
                            }
                        }
                    }
                    break;
                case 3:
                    if (barcosJogador2[op - 1] == false)
                    {
                        Console.ResetColor();
                        Console.WriteLine("Colocar Cruzador 333");
                        Console.Write("Linha (A - J): ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        cordX = Convert.ToChar(Console.ReadLine().ToUpper());
                        Console.ResetColor();
                        Console.Write("Coluna (1 - 10): ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        cordY = Convert.ToInt32(Console.ReadLine());
                        Console.ResetColor();
                        if (cordY >= 1 && cordY <= 8)
                        {
                            if (tabuleiro_jogador2[valor(cordX), (cordY - 1)] == ' ' && tabuleiro_jogador2[valor(cordX), (cordY)] == ' ' && tabuleiro_jogador2[valor(cordX), (cordY + 1)] == ' ')
                            {
                                tabuleiro_jogador2[valor(cordX), (cordY - 1)] = '3'; 
                                tabuleiro_jogador2[valor(cordX), (cordY)] = '3';
                                tabuleiro_jogador2[valor(cordX), (cordY + 1)] = '3';
                                barcosJogador2[op - 1] = true;
                            }
                        }
                    }
                    break;
                case 2:
                    if (barcosJogador2[op - 1] == false)
                    {
                        Console.ResetColor();
                        Console.WriteLine("Colocar Submarino 222");
                        Console.Write("Linha (A - J): ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        cordX = Convert.ToChar(Console.ReadLine().ToUpper());
                        Console.ResetColor();
                        Console.Write("Coluna (1 - 10): ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        cordY = Convert.ToInt32(Console.ReadLine());
                        Console.ResetColor();
                        if (cordY >= 1 && cordY <= 8)
                        {
                            if (tabuleiro_jogador2[valor(cordX), (cordY - 1)] == ' ' && tabuleiro_jogador2[valor(cordX), (cordY)] == ' ' && tabuleiro_jogador2[valor(cordX), (cordY + 1)] == ' ')
                            {
                                tabuleiro_jogador2[valor(cordX), (cordY - 1)] = '2'; 
                                tabuleiro_jogador2[valor(cordX), (cordY)] = '2';
                                tabuleiro_jogador2[valor(cordX), (cordY + 1)] = '2';
                                barcosJogador2[op - 1] = true;
                            }
                        }
                    }
                    break;
                case 1:
                    if (barcosJogador2[op - 1] == false)
                    {
                        Console.ResetColor();
                        Console.WriteLine("Colocar Destroyer 11");
                        Console.Write("Linha (A - J): ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        cordX = Convert.ToChar(Console.ReadLine().ToUpper());
                        Console.ResetColor();
                        Console.Write("Coluna (1 - 10): ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        cordY = Convert.ToInt32(Console.ReadLine());
                        Console.ResetColor();
                        if (cordY >= 1 && cordY <= 8)
                        {
                            if (tabuleiro_jogador2[valor(cordX), (cordY - 1)] == ' ' && tabuleiro_jogador2[valor(cordX), (cordY)] == ' ')
                            {
                                tabuleiro_jogador2[valor(cordX), (cordY - 1)] = '1'; 
                                tabuleiro_jogador2[valor(cordX), (cordY)] = '1';
                                barcosJogador2[op - 1] = true;
                            }
                        }
                    }
                    break;
            }
        }


        public static int valor(char X)
        {
            switch (X)
            {
                case 'A':
                    return 0;
                    break;
                case 'B':
                    return 1;
                    break;
                case 'C':
                    return 2;
                    break;
                case 'D':
                    return 3;
                    break;
                case 'E':
                    return 4;
                    break;
                case 'F':
                    return 5;
                    break;
                case 'G':
                    return 6;
                    break;
                case 'H':
                    return 7;
                    break;
                case 'I':
                    return 8;
                    break;
                case 'J':
                    return 9;
                    break;
                default: return -1;

            }

        }

        public static void tipoBarcosJogador1(string Jogador1)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"    {Jogador1} coloque seus barcos em posição!");
                Console.ResetColor();
                Console.WriteLine("1- Destroyer  2- Submarino  3- Cruzador  4- Porta Aviões");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("  *");
                Console.ResetColor();
                Console.Write(" Escolha um tipo de barco (1-4) : ");
                Console.ForegroundColor = ConsoleColor.Green;
                colocarBarcos(Convert.ToInt32(Console.ReadLine()));
                Console.ResetColor();

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("    ┌───────────────────────────────────────────────┐");
                Console.WriteLine("    │    PARAMETRO INSERIDO É INCORRETO !!!!!!!!!   │");
                Console.WriteLine("    └───────────────────────────────────────────────┘");
                Console.ResetColor();
                Thread.Sleep(3000);
            }
        }

        public static void tipoBarcosJogador2(string Jogador2)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"    {Jogador2} coloque seus barcos em posição!");
                Console.ResetColor();
                Console.WriteLine("1- Destroyer  2- Submarino  3- Cruzador  4- Porta Aviões");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("  *");
                Console.ResetColor();
                Console.ResetColor();
                Console.Write(" Escolha um tipo de barco (1-4) : ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                colocarBarcosJogador2(Convert.ToInt32(Console.ReadLine()));
                Console.ResetColor();

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("    ┌───────────────────────────────────────────────┐");
                Console.WriteLine("    │    PARAMETRO INSERIDO É INCORRETO !!!!!!!!!   │");
                Console.WriteLine("    └───────────────────────────────────────────────┘");
                Thread.Sleep(3000);
                Console.ResetColor();
            }
        }

        public static void JogarRodadas(String rodada, string Jogador1, string Jogador2, char[] linhas, int[] colunas,
        char[,] tabuleiro_jogador1, char[,] tabuleiro_jogador2, char cordX, int cordY)
        {
            Console.Clear();
            do
            {
                if (rodada == "jogador1")
                {
                    Console.Clear();
                    TabuleirosBatalhaNaval.TabuleiroJogador1(Jogador1);
                    Console.WriteLine();
                    Console.WriteLine("                TABULEIRO DE COMBATE");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("       1   2   3   4   5   6   7   8   9   10");
                    Console.ResetColor();
                    Console.WriteLine("     ┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐");
                    for (int f = 0; f < linhas.Length; f++)
                    {
                        Console.Write("   ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{linhas[f]}");
                        Console.ResetColor();
                        Console.Write(" │");
                        for (int c = 0; c < colunas.Length; c++)
                        {
                            if (c != 10)
                            {
                                if (tabuleiro_jogador2[f, c] == 'O' || tabuleiro_jogador2[f, c] == 'X')
                                    Console.Write(" " + tabuleiro_jogador2[f, c] + " │");
                                else
                                    Console.Write("   │");
                            }
                        }
                        Console.WriteLine();
                        if (f != 9)
                            Console.WriteLine("     ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤  ");
                    }
                    Console.WriteLine("     └───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘");
                    Console.ResetColor();
                    Console.Write("     DISPARAR - VEZ DE: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Jogador1}");
                    Console.ResetColor();
                    Console.WriteLine("Onde deseja atacar?");
                    Console.Write("     Linha (A - J): ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    cordX = Convert.ToChar(Console.ReadLine().ToUpper());
                    Console.ResetColor();
                    Console.Write("     Coluna (1 - 10): ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    cordY = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();
                    if (tabuleiro_jogador2[TabuleirosBatalhaNaval.valor(cordX), (cordY - 1)] == ' ')
                        tabuleiro_jogador2[TabuleirosBatalhaNaval.valor(cordX), (cordY - 1)] = 'O';
                    else
                        if (tabuleiro_jogador2[TabuleirosBatalhaNaval.valor(cordX), (cordY - 1)] != ' ' || tabuleiro_jogador2[TabuleirosBatalhaNaval.valor(cordX), (cordY - 1)] != 'O')
                    {                                                                                                             
                        tabuleiro_jogador2[TabuleirosBatalhaNaval.valor(cordX), (cordY - 1)] = 'X';
                        jogador1--;

                        if (jogador1 == 0)
                        {
                            haVencedor = true;
                            break;
                        }

                    }

                }
                rodada = "jogador2";
                Console.Clear();

                if (rodada == "jogador2")
                {
                    Console.Clear();
                    TabuleirosBatalhaNaval.TabuleiroJogador2(Jogador2);
                    Console.WriteLine();
                    Console.WriteLine("                TABULEIRO DE COMBATE");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("       1   2   3   4   5   6   7   8   9   10");
                    Console.ResetColor();
                    Console.WriteLine("     ┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐");
                    for (int f = 0; f < linhas.Length; f++)
                    {
                        Console.Write("   ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write($"{linhas[f]}");
                        Console.ResetColor();
                        Console.Write(" │");
                        for (int c = 0; c < colunas.Length; c++)
                        {
                            if (c != 10)
                            {
                                if (tabuleiro_jogador1[f, c] == 'O' || tabuleiro_jogador1[f, c] == 'X')
                                    Console.Write(" " + tabuleiro_jogador1[f, c] + " │");
                                else
                                    Console.Write("   │");
                            }
                        }
                        Console.WriteLine();
                        if (f != 9)
                            Console.WriteLine("     ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤  ");
                    }
                    Console.WriteLine("     └───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘");
                    Console.ResetColor();
                    Console.Write("     DISPARAR - VEZ DE: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{Jogador2}");
                    Console.ResetColor();
                    Console.WriteLine("Onde deseja atacar?");
                    Console.Write("     Linha (A - J): ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    cordX = Convert.ToChar(Console.ReadLine().ToUpper());
                    Console.ResetColor();
                    Console.Write("     Coluna (1 - 10): ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    cordY = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();
                    if (tabuleiro_jogador1[TabuleirosBatalhaNaval.valor(cordX), (cordY - 1)] == ' ')
                        tabuleiro_jogador1[TabuleirosBatalhaNaval.valor(cordX), (cordY - 1)] = 'O';
                    else
                        if (tabuleiro_jogador1[TabuleirosBatalhaNaval.valor(cordX), (cordY - 1)] != ' ' || tabuleiro_jogador1[TabuleirosBatalhaNaval.valor(cordX), (cordY - 1)] != 'O')
                    {                                                                                                              
                        tabuleiro_jogador1[TabuleirosBatalhaNaval.valor(cordX), (cordY - 1)] = 'X';
                        jogador2--;

                        if (jogador2 == 0)
                        {
                            haVencedor = true;
                            break;

                        }
                    }
                }
                rodada = "jogador1";
                Console.Clear();

            } while (haVencedor == false);

            if (jogador1 == 0)
            {
                Array.Clear(tabuleiro_jogador1, 0, tabuleiro_jogador1.Length);
                Array.Clear(tabuleiro_jogador2, 0, tabuleiro_jogador2.Length);
                Console.Clear();
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

                Console.WriteLine(MenusBatalhaNaval.Vencedor);

            }
            else if (jogador2 == 0)
            {
                Array.Clear(tabuleiro_jogador1, 0, tabuleiro_jogador1.Length);
                Array.Clear(tabuleiro_jogador2, 0, tabuleiro_jogador2.Length);
                Console.Clear();
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
                Console.ResetColor();
                Json.jogadores.Find(player => player.NomeUsuario == Jogador1).Partidas += 1;
                Json.jogadores.Find(player => player.NomeUsuario == Jogador2).Partidas += 1;
                Json.jogadores.Find(player => player.NomeUsuario == Jogador2).Vitorias += 1;
                Json.jogadores.Find(player => player.NomeUsuario == Jogador1).Derrotas += 1;
                Json.jogadores.Find(player => player.NomeUsuario == Jogador2).Pontuacao += 3;
                Ranking.AtualizarRanking();
                Json.Serializar();


                Console.WriteLine(MenusBatalhaNaval.Vencedor);

            }
        }


        public static void StartingGame()
        {
            string Jogador1 = Json.Jogador1;
            string Jogador2 = Json.Jogador2;


            TabuleirosBatalhaNaval.IniciarMatriz();
            do 
            {
                Console.Clear();
                TabuleirosBatalhaNaval.TabuleiroJogador1(Jogador1);
                TabuleirosBatalhaNaval.tipoBarcosJogador1(Jogador1);
                if (barcosJogador1[0] && barcosJogador1[1] && barcosJogador1[2] && barcosJogador1[3])
                {
                    prontoJogador1 = true;
                    Console.Clear();
                    TabuleirosBatalhaNaval.TabuleiroJogador1(Jogador1);
                }
            } while (!prontoJogador1);

            do 
            {
                Console.Clear();
                TabuleirosBatalhaNaval.TabuleiroJogador2(Jogador2);
                TabuleirosBatalhaNaval.tipoBarcosJogador2(Jogador2);
                if (barcosJogador2[0] && barcosJogador2[1] && barcosJogador2[2] && barcosJogador2[3])
                {
                    Console.Clear();
                    prontoJogador2 = true;
                    TabuleirosBatalhaNaval.TabuleiroJogador2(Jogador2);
                }
            } while (!prontoJogador2);


            do
            {
                Console.Clear();
                TabuleirosBatalhaNaval.JogarRodadas(rodada, Jogador1, Jogador2, linhas, colunas, tabuleiro_jogador1, tabuleiro_jogador2, cordX, cordY);


            } while (haVencedor = false);

            Menu.VoltarAoMenu();
            Menu.MenuHub();
        }

        public static void RegrasDoJogo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(MenusBatalhaNaval.LogoBatalha);
            Console.ResetColor();
            Console.WriteLine("                       - REGRAS DO JOGO - ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\n           Antes de iniciar, leia as regras do jogo:");
            Console.ResetColor();

            Console.WriteLine("\n* O tabuleiro  é uma matriz  de dez linhas por dez colunas.");
            Console.WriteLine("\n* Cada jogador distribui seus navios e não deve revelar ao \noponente as suas posições.");
            Console.WriteLine("\n* Os jogadores jogam alternadamente, uma marcação por vez, numa lacuna que esteja vazia.");
            Console.WriteLine("\n* Após cada um dos tiros, o oponente avisará se acertou e, \nnesse caso, qual navio foi atingido. " +
                "Se ele for afundado, \nesse fato também deverá ser informado.");
            Console.WriteLine("\n* Um navio é afundado quando todas as casas que formam esse \nnavio forem atingidas.");
            Console.WriteLine("\n* O jogo termina quando um dos jogadores afundar todas os \nnavios do seu oponente.");
            Console.WriteLine("\n* Ao ganhar a partida o jogador ganha 3 pontos. \n" +
                "* Em caso de derrota não recebe pontuação. \n");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\n         Pressione qualquer tecla para prosseguir...");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();

        }




    }
}
