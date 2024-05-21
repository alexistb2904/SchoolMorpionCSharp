using System.Security.Cryptography;

void Morpion(int type, int difficulty = 0)
{
    string[,] tabJeu = new string[3, 3];
    string Player1 = "X";
    string Player2 = "O";
    int tour = 0;
    int playerAction = new Random().Next(0, 1);
    bool finished = false;
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            tabJeu[i, j] = " ";
        }
    }
    void AfficherTableau()
    {
        if (type == 2) {
        Console.WriteLine("Au Tour de " + (playerAction == 0 ? "Joueur 1 (" + Player1 + ")" : "Joueur 2 (" + Player2 + ")"));
        } else
        {
            Console.WriteLine("Au Tour de " + (playerAction == 0 ? "Joueur 1 (" + Player1 + ")" : "Ordinateur (" + Player2 + ")"));
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (j == 2)
                {
                    Console.Write(tabJeu[i, j]);
                }
                else
                {
                    Console.Write(tabJeu[i, j] + " | ");
                }
            }
            if (i < 2)
            {
                Console.Write('\n');
                Console.WriteLine("---------");
            }
        }
        Console.Write('\n');
    }
    void checkWin()
    {
        if (tour > 9)
        {
            Console.WriteLine(tour);
            Console.WriteLine("Match nul 1");
            finished = true;
        }
        for (int i = 0; i < 2; i++)
        {
            string playerToCheck = i == 0 ? Player1 : Player2;
            for (int j = 0; j < 3; j++)
            {
                if (tabJeu[j, 0] == playerToCheck && tabJeu[j, 1] == playerToCheck && tabJeu[j, 2] == playerToCheck)
                {
                    if (type == 2)
                    {
                        Console.WriteLine("Le joueur " + (i + 1) + " a gagné");
                    } else
                    {
                        if (i == 0)
                        {
                            Console.WriteLine("Le joueur " + (i + 1) + " a gagné");
                        } else
                        {
                            Console.WriteLine("L'ordinateur a gagné");
                        }
                    }
                    finished = true;
                }
                if (tabJeu[0, j] == playerToCheck && tabJeu[1, j] == playerToCheck && tabJeu[2, j] == playerToCheck)
                {
                    if (type == 2)
                    {
                        Console.WriteLine("Le joueur " + (i + 1) + " a gagné");
                    }
                    else
                    {
                        if (i == 0)
                        {
                            Console.WriteLine("Le joueur " + (i + 1) + " a gagné");
                        }
                        else
                        {
                            Console.WriteLine("L'ordinateur a gagné");
                        }
                    }
                    finished = true;
                }

            }
            if (tabJeu[0, 0] == playerToCheck && tabJeu[1, 1] == playerToCheck && tabJeu[2, 2] == playerToCheck)
            {
                if (type == 2)
                {
                    Console.WriteLine("Le joueur " + (i + 1) + " a gagné");
                }
                else
                {
                    if (i == 0)
                    {
                        Console.WriteLine("Le joueur " + (i + 1) + " a gagné");
                    }
                    else
                    {
                        Console.WriteLine("L'ordinateur a gagné");
                    }
                }
                finished = true;
            }
            if (tabJeu[0, 2] == playerToCheck && tabJeu[1, 1] == playerToCheck && tabJeu[2, 0] == playerToCheck)
            {
                if (type == 2)
                {
                    Console.WriteLine("Le joueur " + (i + 1) + " a gagné");
                }
                else
                {
                    if (i == 0)
                    {
                        Console.WriteLine("Le joueur " + (i + 1) + " a gagné");
                    }
                    else
                    {
                        Console.WriteLine("L'ordinateur a gagné");
                    }
                }
                finished = true;
            }
        }

    }
    AfficherTableau();
    void ComputerPlay(int difficulty)
    {
        if (tour < 9)
        {
            if (difficulty == 1) 
            {
                ComputerPlayRandom();
                playerAction = (playerAction == 0 ? 1 : 0);
                tour++;
                Console.Clear();
                AfficherTableau();
                checkWin();
            }
            else if (difficulty == 2)
            {
                ComputerPlayDefensive();
                playerAction = (playerAction == 0 ? 1 : 0);
                tour++;
                Console.Clear();
                AfficherTableau();
                checkWin();
            } 
            else if (difficulty == 3)
            {
                if (new Random().Next(2) == 0) // 50% chance of defensive play
                {
                    ComputerPlayDefensive();
                }
                else
                {
                    ComputerPlayRandom();
                }
                playerAction = (playerAction == 0 ? 1 : 0);
                tour++;
                Console.Clear();
                AfficherTableau();
                checkWin();
            }
        }
    }

    bool checkForFakeWin(string player)
    {
        if (tour > 9)
        {
            return false;
        }
        string playerToCheck = player;
        for (int j = 0; j < 3; j++)
        {
            if (tabJeu[j, 0] == playerToCheck && tabJeu[j, 1] == playerToCheck && tabJeu[j, 2] == playerToCheck)
            {
                return true;
            }
            if (tabJeu[0, j] == playerToCheck && tabJeu[1, j] == playerToCheck && tabJeu[2, j] == playerToCheck)
            {
                return true;
            }

        }
        if (tabJeu[0, 0] == playerToCheck && tabJeu[1, 1] == playerToCheck && tabJeu[2, 2] == playerToCheck)
        {
            return true;
        }
        if (tabJeu[0, 2] == playerToCheck && tabJeu[1, 1] == playerToCheck && tabJeu[2, 0] == playerToCheck)
        {
            return true;
        }
        return false;
    }

    void ComputerPlayRandom()
    {
        int x = new Random().Next(0, 3);
        int y = new Random().Next(0, 3);
        if (tabJeu[x, y] == " ")
        {
            tabJeu[x, y] = Player2;
        }
        else
        {
            ComputerPlay(difficulty);
        }
    }

    void ComputerPlayDefensive()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (tabJeu[i, j] == " ")
                {
                    tabJeu[i, j] = Player2;
                    if (checkForFakeWin(Player2))
                    {
                        return;
                    }
                    tabJeu[i, j] = " ";
                }
            }
        }
        if (tabJeu[1, 1] == " ")
        {
            tabJeu[1, 1] = Player2;

        }
        else if (tabJeu[0, 0] == " " || tabJeu[0, 2] == " " || tabJeu[2, 0] == " " || tabJeu[2, 2] == " ")
        {
            bool cornerTaken = false;
            int[] corners = { 0, 0, 0, 2, 2, 0, 2, 2 };
            int randomCorner = new Random().Next(corners.Length - 1);
            if (tabJeu[corners[randomCorner], corners[randomCorner + 1]] == " ")
            {
                cornerTaken = true;
                tabJeu[corners[randomCorner], corners[randomCorner + 1]] = Player2;
            }
            
            while (!cornerTaken)
            {
                randomCorner = new Random().Next(corners.Length - 1);
                if (tabJeu[corners[randomCorner], corners[randomCorner + 1]] == " ")
                {
                    cornerTaken = true;
                    tabJeu[corners[randomCorner], corners[randomCorner + 1]] = Player2;
                }
            }

        }
        else
        {
            ComputerPlayRandom();
        }
    }
    while (tour < 9 && finished != true)
    {
        int[,] paveNumerique = new int[3, 3]
        {
            {7, 8, 9},
            {4, 5, 6},
            {1, 2, 3}
        };
        int numberGiven = -1;
        if (playerAction == 1 && type == 1)
        {
            ComputerPlay(difficulty);
        }
        else
        {
            while (numberGiven < 0 || numberGiven > 9)
            {
                Console.WriteLine("Entrez un nombre entre 1 et 9");
                Console.WriteLine("7 | 8 | 9");
                Console.WriteLine("---------");
                Console.WriteLine("4 | 5 | 6");
                Console.WriteLine("---------");
                Console.WriteLine("1 | 2 | 3");
                while (!int.TryParse(Console.ReadLine(), out numberGiven))
                {
                    Console.WriteLine("Entrez un nombre entre 1 et 9");
                    Console.WriteLine("7 | 8 | 9");
                    Console.WriteLine("---------");
                    Console.WriteLine("4 | 5 | 6");
                    Console.WriteLine("---------");
                    Console.WriteLine("1 | 2 | 3");
                }
            }

            int x = -1;
            int y = -1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (paveNumerique[i, j] == numberGiven)
                    {
                        x = i;
                        y = j;
                        break;
                    }
                }
                if (x != -1 && y != -1)
                    break;
            }

            if (tabJeu[x, y] == " ")
            {
                tabJeu[x, y] = (playerAction == 0 ? Player1 : Player2);
                playerAction = (playerAction == 0 ? 1 : 0);
                tour++;
                Console.Clear();
                AfficherTableau();
                checkWin();

            }
            else
            {
                Console.WriteLine("Case déjà prise");
            }
        }
        
        
    }
    if (tour > 9 && finished == false)
    {
        Console.WriteLine("Match nul");
    }
}

void starting()
{
    int choix;
    do
    {
        Console.WriteLine("1 - Jouer contre un ordinateur");
        Console.WriteLine("2 - Jouer contre un joueur");
        Console.WriteLine("3 - Quitter");
        while (!int.TryParse(Console.ReadLine(), out choix))
        {
            Console.WriteLine("1 - Jouer contre un ordinateur");
            Console.WriteLine("2 - Jouer contre un joueur");
            Console.WriteLine("3 - Quitter");
        }
        int choix2;
        switch (choix)
        {
            case 1:
                Console.WriteLine("1 - Aléatoire");
                Console.WriteLine("2 - Défensif");
                Console.WriteLine("3 - Offensif");
                while (!int.TryParse(Console.ReadLine(), out choix2))
                {
                    Console.WriteLine("1 - Aléatoire");
                    Console.WriteLine("2 - Défensif");
                    Console.WriteLine("3 - Offensif");
                }
                switch (choix2)
                {
                    case 1:
                        Morpion(choix, choix2);
                        break;
                    case 2:
                        Morpion(choix, choix2);
                        break;
                    case 3:
                        Morpion(choix, choix2);
                        break;
                    default:
                        Console.WriteLine("Choix invalide");
                        break;
                }
                break;
            case 2:
                Morpion(choix);
                break;
            case 3:
                break;
            default:
                Console.WriteLine("Choix invalide");
                break;
        }   
    } while (choix != 3);
}

starting();