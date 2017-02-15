using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje2
{
    class Game
    {
        static void Main(string[] args)
        {
            int choice;
            bool Flag = true;
            while (Flag == true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine(" (                      (                )   ");
                Console.WriteLine(" )\\ )                   )\\ )  (       ( /(   ");
                Console.WriteLine("(()/( (    (   (   (   (()/(  )\\ )    )\\())  ");
                Console.WriteLine(" /(_)))\\   )\\  )\\  )\\   /(_))(()/(   ((_)\\   ");
                Console.WriteLine("(_)) ((_) ((_)((_)((_) (_))   /(_))_   ((_)  ");
                Console.WriteLine("| _ \\| __|\\ \\ / / | __|| _ \\ (_)) __| / _ \\  ");
                Console.WriteLine("|   /| _|  \\ V /  | _| |   /   | (_ || (_) | ");
                Console.WriteLine("|_|_\\|___|  \\_/   |___||_|_\\    \\___| \\___/  ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("             Press 1 for 1x16");
                Console.WriteLine("             Press 2 for 8x8");
                Console.WriteLine("             Press 3 for Exit");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1://1x16
                        {

                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Clear();
                            int a = 0;
                            int counter1 = 0;
                            int i, c = 0, cn = 0;
                            int si = 0, be = 0; // siyah taş sayacı ve beyaz taş sayacı
                            int x = 0;
                            bool BO = false, flag = false, flag1 = false;
                            bool k = false, l = false, p = false, s = false;
                            bool flag3 = true;//To Control Conversion 
                            bool flag2 = false;
                            bool flag4 = true;//To Control Conversion
                            int[] vl = new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                            int n = 0;
                            int j = 0;
                            int t = j + 1;
                            int r = 0;
                            int StoneCounterHuman = 0;
                            int StoneCounterAI = 0;
                            int corner = 0;
                            int RoundCounter = 0;
                            while (c < 9)
                            {
                                BO = false;
                                Console.Clear();
                                Console.WriteLine("  0 0 0 0 0 0 0 0 0 1 1 1 1 1 1 1");
                                Console.WriteLine("  1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6");
                                Console.Write("+ - - - - - - - - - - - - - - - - +");
                                Console.WriteLine("Round   : " + RoundCounter);
                                Console.Write("| ");
                                for (i = 0; i < 4; i++)
                                {
                                    if (vl[i] == 0) { Console.Write(". "); }
                                    else if (vl[i] == 1) { Console.Write("o "); }
                                    else if (vl[i] == 2) { Console.Write("x "); }

                                }

                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                                for (i = 4; i < 11; i++)
                                {
                                    if (vl[i] == 0) { Console.Write(". "); }
                                    else if (vl[i] == 1) { Console.Write("o "); }
                                    else if (vl[i] == 2) { Console.Write("x "); }

                                }

                                if (vl[i] == 0) { Console.Write("."); }
                                else if (vl[i] == 1) { Console.Write("o"); }
                                else if (vl[i] == 2) { Console.Write("x"); }
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write(" ");
                                for (i = 12; i < 16; i++)
                                {
                                    if (vl[i] == 0) { Console.Write(". "); }
                                    else if (vl[i] == 1) { Console.Write("o "); }
                                    else if (vl[i] == 2) { Console.Write("x "); }

                                }
                                Console.Write("|");
                                Console.WriteLine("Human   : " + StoneCounterHuman);

                                Console.Write("+ - - - - - - - - - - - - - - - - +");
                                Console.WriteLine("Computer: " + StoneCounterAI);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;

                                if (vl[0] != 0 && vl[1] != 0 && vl[2] != 0 && vl[3] != 0 && vl[4] != 0 && vl[5] != 0 && vl[6] != 0 && vl[7] != 0 && vl[8] != 0 && vl[9] != 0
                                    && vl[10] != 0 && vl[11] != 0 && vl[12] != 0 && vl[13] != 0 && vl[14] != 0 && vl[15] != 0) break;
                                else
                                {
                                    Console.Write("Enter a:");
                                    a = Convert.ToInt32(Console.ReadLine());



                                    while (flag == false)//For the Safe Zone
                                    {

                                        if (a < 5 || a > 12)
                                        {
                                            Console.WriteLine("You can't put stone to out of safe area!");
                                            Console.WriteLine("Please try again");
                                            Console.Write("Enter a:");
                                            a = Convert.ToInt32(Console.ReadLine());

                                        }
                                        else { flag = true; }
                                    }

                                    while (BO == false)//Wrong Entry Alarm
                                    {
                                        n = a - 1;

                                        if (n > 3 && n < 12)
                                        {
                                            if (vl[n] == 0)
                                            {
                                                BO = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Wrong entry!");
                                                Console.Write("Enter a:");
                                                a = Convert.ToInt32(Console.ReadLine());
                                            }
                                        }
                                        else if (n == 3 || n == 2 || n == 12 || n == 13)
                                        {
                                            if (vl[n] == 0 && (vl[n + 2] != 0 || vl[n + 1] != 0 || vl[n - 2] != 0 || vl[n - 1] != 0))
                                            {
                                                BO = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Wrong entry!");
                                                Console.Write("Enter a:");
                                                a = Convert.ToInt32(Console.ReadLine());
                                            }
                                        }
                                        else if (n == 1)
                                        {
                                            if (vl[n] == 0 && (vl[n + 2] != 0 || vl[n + 1] != 0 || vl[n - 1] != 0))
                                            {
                                                BO = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Wrong entry!");
                                                Console.Write("Enter a:");
                                                a = Convert.ToInt32(Console.ReadLine());
                                            }
                                        }
                                        else if (n == 0)
                                        {
                                            if (vl[n] == 0 && (vl[n + 2] != 0 || vl[n + 1] != 0))
                                            {
                                                BO = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Wrong entry!");
                                                Console.Write("Enter a:");
                                                a = Convert.ToInt32(Console.ReadLine());
                                            }
                                        }
                                        else if (n == 14)
                                        {
                                            if (vl[n] == 0 && (vl[n - 2] != 0 || vl[n - 1] != 0 || vl[n + 1] != 0))
                                            {
                                                BO = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Wrong entry!");
                                                Console.Write("Enter a:");
                                                a = Convert.ToInt32(Console.ReadLine());
                                            }
                                        }
                                        else if (n == 15)
                                        {
                                            if (vl[n] == 0 && (vl[n - 2] != 0 || vl[n - 1] != 0))
                                            {
                                                BO = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Wrong entry!");
                                                Console.Write("Enter a:");
                                                a = Convert.ToInt32(Console.ReadLine());
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Wrong entry!");
                                            Console.Write("Enter a:");
                                            a = Convert.ToInt32(Console.ReadLine());
                                        }
                                    }

                                    BO = false;
                                    vl[a - 1] = 1;//Player chose.

                                    for (j = a - 1; j < 13; j++)//Conversion. Section 1 - Part 1
                                    {                           // Sections are the same algorithm.

                                        if (vl[j] == 1)//For the Player
                                        {
                                            for (t = j + 1; t <= 15 && flag3 == true && flag4 == true; t++)
                                            {
                                                if (vl[t] == 2) { counter1++; }//If there is black stone, increase 1 to counter 1
                                                else if (vl[t] == 0) { flag3 = false; }//If there is a blank
                                                else if (vl[t] == 1) { flag4 = false; }//If there is white stone
                                            }
                                            if (counter1 > 0 && flag3 == true && flag4 == false)
                                            {
                                                for (r = counter1; r > 0; r--)
                                                {
                                                    vl[j + r] = 1;
                                                }

                                            }
                                        }

                                        else if (vl[j] == 2)//For the AI
                                        {
                                            for (t = j + 1; t <= 15 && flag3 == true && flag4 == true; t++)
                                            {
                                                if (vl[t] == 1) { counter1++; }
                                                else if (vl[t] == 0) { flag3 = false; }
                                                else if (vl[t] == 2) { flag4 = false; }
                                            }
                                            if (counter1 > 0 && flag3 == true && flag4 == false)
                                            {
                                                for (r = counter1; r > 0; r--)
                                                {
                                                    vl[j + r] = 2;
                                                }

                                            }
                                        }
                                        flag3 = true;
                                        flag4 = true;
                                        counter1 = 0;

                                    }
                                    for (j = 0; j < (a - 1); j++)//Conversion Section 1 - Part 2
                                    {

                                        if (vl[j] == 1)
                                        {
                                            for (t = j + 1; t <= 15 && flag3 == true && flag4 == true; t++)
                                            {
                                                if (vl[t] == 2) { counter1++; }
                                                else if (vl[t] == 0) { flag3 = false; }
                                                else if (vl[t] == 1) { flag4 = false; }
                                            }
                                            if (counter1 > 0 && flag3 == true && flag4 == false)
                                            {
                                                for (r = counter1; r > 0; r--)
                                                {
                                                    vl[j + r] = 1;
                                                }

                                            }
                                        }

                                        else if (vl[j] == 2)
                                        {
                                            for (t = j + 1; t <= 15 && flag3 == true && flag4 == true; t++)
                                            {
                                                if (vl[t] == 1) { counter1++; }
                                                else if (vl[t] == 0) { flag3 = false; }
                                                else if (vl[t] == 2) { flag4 = false; }
                                            }
                                            if (counter1 > 0 && flag3 == true && flag4 == false)
                                            {
                                                for (r = counter1; r > 0; r--)
                                                {
                                                    vl[j + r] = 2;
                                                }

                                            }
                                        }
                                        flag3 = true;
                                        flag4 = true;
                                        counter1 = 0;

                                    }
                                    StoneCounterAI = 0;
                                    StoneCounterHuman = 0;
                                    for (i = 0; i < vl.Length; i++)
                                    {

                                        if (vl[i] == 1) { StoneCounterHuman++; }
                                        if (vl[i] == 2) { StoneCounterAI++; }

                                    }
                                    RoundCounter++;
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    Console.Clear();

                                    Console.WriteLine("  0 0 0 0 0 0 0 0 0 1 1 1 1 1 1 1");//Second Output
                                    Console.WriteLine("  1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6");
                                    Console.Write("+ - - - - - - - - - - - - - - - - +");
                                    Console.WriteLine("Round   : " + RoundCounter);
                                    Console.Write("| ");
                                    for (i = 0; i < 4; i++)
                                    {
                                        if (vl[i] == 0) { Console.Write(". "); }
                                        else if (vl[i] == 1) { Console.Write("o "); }
                                        else if (vl[i] == 2) { Console.Write("x "); }

                                    }

                                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                                    for (i = 4; i < 11; i++)
                                    {
                                        if (vl[i] == 0) { Console.Write(". "); }
                                        else if (vl[i] == 1) { Console.Write("o "); }
                                        else if (vl[i] == 2) { Console.Write("x "); }

                                    }

                                    if (vl[i] == 0) { Console.Write("."); }
                                    else if (vl[i] == 1) { Console.Write("o"); }
                                    else if (vl[i] == 2) { Console.Write("x"); }
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Write(" ");
                                    for (i = 12; i < 16; i++)
                                    {
                                        if (vl[i] == 0) { Console.Write(". "); }
                                        else if (vl[i] == 1) { Console.Write("o "); }
                                        else if (vl[i] == 2) { Console.Write("x "); }

                                    }
                                    Console.Write("|");
                                    Console.WriteLine("Human   : " + StoneCounterHuman);
                                    Console.Write("+ - - - - - - - - - - - - - - - - +");
                                    Console.WriteLine("Computer: " + StoneCounterAI);
                                    Console.ReadKey();

                                    Random rnd = new Random();

                                    if ((vl[0] == 0 && (vl[1] != 0 || vl[2] != 0)) && (vl[15] == 0 && (vl[14] != 0 || vl[13] != 0)))//AI Algorithm To Capture Corner
                                    {
                                        corner = rnd.Next(1, 3);

                                        if (corner == 1)
                                        {
                                            vl[0] = 2;
                                            flag1 = true;
                                            flag2 = true;
                                            s = true;
                                            l = true;
                                        }

                                        else if (corner == 2)
                                        {
                                            vl[15] = 2;
                                            flag1 = true;
                                            flag2 = true;
                                            s = true;
                                            l = true;
                                        }

                                    }
                                    else if (vl[0] == 0 && (vl[1] != 0 || vl[2] != 0))//AI Algorithm To Capture Left Corner
                                    {
                                        vl[0] = 2;
                                        flag1 = true;
                                        flag2 = true;
                                        s = true;
                                        l = true;
                                    }
                                    else if (vl[15] == 0 && (vl[14] != 0 || vl[13] != 0))//AI Algorithm To Capture Right Corner
                                    {
                                        vl[15] = 2;
                                        flag1 = true;
                                        flag2 = true;
                                        s = true;
                                        l = true;
                                    }

                                    if (k == false)
                                    {
                                        if ((vl[4] == 1 || vl[5] == 1) && vl[3] == 0) //AI Algorithm To Not Loose Left Corner
                                        {
                                            vl[3] = 2;
                                            flag1 = true;
                                            flag2 = true;
                                            k = true;
                                            s = true;
                                            l = true;
                                        }
                                    }
                                    if (p == false)
                                    {
                                        if ((vl[10] == 1 || vl[11] == 1) && vl[12] == 0)//AI Algorithm To Not Loose Right Corner
                                        {
                                            vl[12] = 2;
                                            flag1 = true;
                                            flag2 = true;
                                            p = true;
                                            l = true;
                                            s = true;
                                        }
                                    }

                                    if (l == false) //AI Algorithm To Capture The Rival Stones
                                    {
                                        for (int q = 3; q <= 10; q++)
                                        {
                                            if (vl[q] == 2 && vl[q + 1] == 1)
                                            {
                                                if (cn == 0)
                                                {
                                                    cn++;
                                                }
                                            }
                                            else if (cn > 0 && vl[q] == 1 && vl[q + 1] == 1)
                                            {
                                                if (vl[q + 1] != 0 && vl[q] != 0)
                                                {
                                                    {
                                                        cn++;
                                                    }
                                                }
                                            }
                                            else if (vl[q] == 1 && vl[q + 1] == 0 && cn > 0)
                                            {
                                                vl[q + 1] = 2;
                                                flag1 = true;
                                                flag2 = true;
                                                s = true;
                                                l = true;
                                                break;
                                            }
                                            else
                                            {
                                                cn = 0;
                                                continue;
                                            }
                                        }
                                        cn = 0;
                                        if (l == false) //AI Algorithm To Capture The Rival Stones
                                        {
                                            for (int q = 12; q >= 5; q--)
                                            {
                                                if (vl[q] == 2 && vl[q - 1] == 1)
                                                {
                                                    if (cn == 0)
                                                    {
                                                        cn++;
                                                    }
                                                }
                                                else if (cn > 0 && vl[q] == 1 && vl[q - 1] == 1)
                                                {
                                                    if (vl[q - 1] != 0 && vl[q] != 0)
                                                    {
                                                        {
                                                            cn++;
                                                        }
                                                    }
                                                }
                                                else if (vl[q] == 1 && vl[q - 1] == 0 && cn > 0)
                                                {
                                                    vl[q - 1] = 2;
                                                    flag1 = true;
                                                    flag2 = true;
                                                    s = true;
                                                    break;
                                                }
                                                else
                                                {
                                                    cn = 0;
                                                    continue;
                                                }
                                            }
                                        }
                                    }

                                    cn = 0;
                                    l = false;


                                    if (flag1 == false)
                                    {
                                        if (vl[3] == 1 && vl[12] != 1) // //AI Algorithm To Generate Random Position To Not Loose The Corners
                                        {
                                            while (BO == false)
                                            {
                                                if (vl[5] == 0)
                                                {
                                                    while (BO == false)
                                                    {
                                                        x = rnd.Next(5, 12);

                                                        if (vl[x] == 0)
                                                        {
                                                            vl[x] = 2;
                                                            flag2 = true;
                                                            s = true;
                                                            BO = true;
                                                        }
                                                        else if (vl[5] != 0 && vl[6] != 0 && vl[7] != 0 && vl[8] != 0 && vl[9] != 0 && vl[10] != 0 && vl[11] != 0
                                                           ) { BO = true; }
                                                    }
                                                }
                                                else
                                                {
                                                    while (BO == false)
                                                    {
                                                        x = rnd.Next(4, 12);

                                                        if (vl[x] == 0)
                                                        {
                                                            vl[x] = 2;
                                                            flag2 = true;
                                                            s = true;
                                                            BO = true;
                                                        }
                                                        else if (vl[4] != 0 && vl[5] != 0 && vl[6] != 0 && vl[7] != 0 && vl[8] != 0 && vl[9] != 0 && vl[10] != 0 && vl[11] != 0
                                                           ) { BO = true; }
                                                    }
                                                }
                                            }
                                        }

                                        if (vl[12] == 1 && vl[3] != 1)
                                        {
                                            while (BO == false)
                                            {
                                                x = rnd.Next(4, 11);

                                                if (vl[x] == 0)
                                                {
                                                    vl[x] = 2;
                                                    BO = true;
                                                    s = true;
                                                }

                                                else if (vl[4] != 0 && vl[5] != 0 && vl[6] != 0 && vl[7] != 0 && vl[8] != 0 && vl[9] != 0 && vl[10] != 0
                                                              ) { BO = true; }
                                            }
                                        }
                                        else
                                        {
                                            while (BO == false)
                                            {
                                                x = rnd.Next(4, 12);

                                                if (vl[x] == 0)
                                                {
                                                    vl[x] = 2;
                                                    flag2 = true;
                                                    s = true;
                                                    BO = true;
                                                }
                                                else if (vl[4] != 0 && vl[5] != 0 && vl[6] != 0 && vl[7] != 0 && vl[8] != 0 && vl[9] != 0 && vl[10] != 0 && vl[11] != 0
                                                   ) { BO = true; }
                                            }
                                        }

                                        BO = false;

                                        if (s == false) //AI Algorithm To Capture The Rival Stones
                                        {
                                            for (int u = 0; u <= 14; u++)
                                            {
                                                if (vl[u] == 2 && vl[u + 1] == 1)
                                                {
                                                    if (cn == 0)
                                                    {
                                                        cn++;
                                                    }
                                                }
                                                else if (cn > 0 && vl[u] == 1 && vl[u + 1] == 1)
                                                {
                                                    if (vl[u + 1] != 0 && vl[u] != 0)
                                                    {
                                                        {
                                                            cn++;
                                                        }
                                                    }
                                                }
                                                else if (vl[u] == 1 && vl[u + 1] == 0 && cn > 0)
                                                {
                                                    vl[u + 1] = 2;
                                                    flag2 = true;
                                                    s = true;
                                                    break;
                                                }

                                                else
                                                {
                                                    cn = 0;
                                                    continue;
                                                }
                                            }
                                        }

                                        cn = 0;

                                        if (s == false) //AI Algorithm To Capture The Rival Stones
                                        {
                                            for (int u = 15; u >= 1; u--)
                                            {
                                                if (vl[u] == 2 && vl[u - 1] == 1)
                                                {
                                                    if (cn == 0)
                                                    {
                                                        cn++;
                                                    }
                                                }
                                                else if (cn > 0 && vl[u] == 1 && vl[u - 1] == 1)
                                                {
                                                    if (vl[u + 1] != 0 && vl[u] != 0)
                                                    {
                                                        {
                                                            cn++;
                                                        }
                                                    }
                                                }
                                                else if (vl[u] == 1 && vl[u - 1] == 0 && cn > 0)
                                                {
                                                    vl[u - 1] = 2;
                                                    flag2 = true;
                                                    break;
                                                }
                                                else
                                                {
                                                    cn = 0;
                                                    continue;
                                                }
                                            }
                                        }

                                        s = false;

                                        if (flag2 == false) // //AI Algorithm To Generate Random position To Fill The Array
                                        {
                                            while (BO == false)
                                            {
                                                x = rnd.Next(0, 16);
                                                if ((x < 4 && x > 1) || (x > 11 && x < 14))
                                                {
                                                    if (vl[x] == 0 && ((vl[x - 2] == 1 || vl[x - 2] == 2 || vl[x - 1] == 1 || vl[x - 1] == 2) || (vl[x + 2] == 1 || vl[x + 2] == 2 || vl[x + 1] == 1 || vl[x + 1] == 2)))
                                                    {
                                                        vl[x] = 2;
                                                        BO = true;
                                                    }
                                                }
                                                if (x > 3 && x < 12)
                                                {
                                                    if (vl[x] == 0)
                                                    {
                                                        vl[x] = 2;
                                                        BO = true;
                                                    }
                                                }
                                                else if (x < 2)
                                                {
                                                    if (vl[x] == 0 && (vl[x + 2] == 1 || vl[x + 2] == 2))
                                                    {
                                                        vl[x] = 2;
                                                        BO = true;
                                                    }
                                                }
                                                else if (x > 13)
                                                {
                                                    if (vl[x] == 0 && (vl[x - 2] == 1 || vl[x - 2] == 2))
                                                    {
                                                        vl[x] = 2;
                                                        BO = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    flag1 = false;
                                    flag2 = false;
                                    flag3 = true;
                                    flag4 = true;
                                    counter1 = 0;
                                }
                                for (j = x; j <= 13; j++)//Conversion Section 2 - Part:1
                                {
                                    if (vl[j] == 1)//For the Player
                                    {
                                        for (t = j + 1; t <= 15 && flag3 == true && flag4 == true; t++)
                                        {
                                            if (vl[t] == 2) { counter1++; }
                                            else if (vl[t] == 0) { flag3 = false; }
                                            else if (vl[t] == 1) { flag4 = false; }
                                        }
                                        if (counter1 > 0 && flag3 == true && flag4 == false)
                                        {
                                            for (r = counter1; r > 0; r--)
                                            {
                                                vl[j + r] = 1;
                                            }
                                        }
                                    }
                                    else if (vl[j] == 2)//For the AI
                                    {
                                        for (t = j + 1; a <= 15 && flag3 == true && flag4 == true; t++)
                                        {
                                            if (vl[t] == 1) { counter1++; }
                                            else if (vl[t] == 0) { flag3 = false; }
                                            else if (vl[t] == 2) { flag4 = false; }
                                        }
                                        if (counter1 > 0 && flag3 == true && flag4 == false)
                                        {
                                            for (r = counter1; r > 0; r--)
                                            {
                                                vl[j + r] = 2;
                                            }
                                        }
                                    }
                                    flag3 = true;
                                    flag4 = true;
                                    counter1 = 0;

                                }
                                for (j = 0; j < x; j++)//Conversion Section 2 - Part 2
                                {
                                    if (vl[j] == 1)
                                    {
                                        for (t = j + 1; t <= 15 && flag3 == true && flag4 == true; t++)
                                        {
                                            if (vl[t] == 2) { counter1++; }
                                            else if (vl[t] == 0) { flag3 = false; }
                                            else if (vl[t] == 1) { flag4 = false; }
                                        }
                                        if (counter1 > 0 && flag3 == true && flag4 == false)
                                        {
                                            for (r = counter1; r > 0; r--)
                                            {
                                                vl[j + r] = 1;
                                            }

                                        }
                                    }
                                    else if (vl[j] == 2)
                                    {
                                        for (t = j + 1; a <= 15 && flag3 == true && flag4 == true; t++)
                                        {
                                            if (vl[t] == 1) { counter1++; }
                                            else if (vl[t] == 0) { flag3 = false; }
                                            else if (vl[t] == 2) { flag4 = false; }
                                        }
                                        if (counter1 > 0 && flag3 == true && flag4 == false)
                                        {
                                            for (r = counter1; r > 0; r--)
                                            {
                                                vl[j + r] = 2;
                                            }
                                        }
                                    }
                                    flag3 = true;
                                    flag4 = true;
                                    counter1 = 0;

                                }
                                StoneCounterAI = 0;
                                StoneCounterHuman = 0;
                                for (i = 0; i < vl.Length; i++)
                                {

                                    if (vl[i] == 1) { StoneCounterHuman++; }
                                    if (vl[i] == 2) { StoneCounterAI++; }

                                }
                                RoundCounter++;
                                cn = 0;
                                c++;
                            }

                            for (int g = 0; g < 16; g++)
                            {
                                if (vl[g] == 1)
                                    be++;
                                else if (vl[g] == 2)
                                    si++;
                            }

                            Console.WriteLine();

                            if (be > si)
                                Console.WriteLine("Winner is player!");
                            else if (si > be)
                                Console.WriteLine("Winner is computer!");
                            else if (si == be)
                                Console.WriteLine("Tie!");

                            Console.WriteLine();
                            Console.WriteLine("Computer score: " + si);
                            Console.WriteLine("Player score: " + be);

                            Console.ReadLine();
                        } break;

                    case 2:
                        {
                            int c = 0;//For the Main Loop
                            int corner = 0, center = 0;
                            int x2 = 0, y2 = 0;
                            bool flago1 = false, flago2 = false, flago3 = false;
                            bool flago13 = false, flago12 = false, flago11 = false;
                            bool asd = false;
                            bool saf = false;
                            bool turn1 = true;//For the Conversion
                            bool turn2 = true;//For the Conversion
                            bool turn3 = true, turn4 = true; //For the Conversion
                            bool turn5 = true, turn6 = true;//For the Conversion
                            int trcounter1 = 0;//Conversion Counter
                            int trcounter2 = 0;//Conversion Counter
                            int trcounter3 = 0;//Conversion Counter
                            int tri = 0;//Conversion int that can be equal to player's x coordinate chose or 0
                            int trj = 0;//Conversion int that can be equal to player's y coordinate chose or 0
                            int tr1 = 0;//Conversion int
                            int tr2 = 0;//Conversion int
                            int StoneCounterHuman = 0;
                            int StoneCounterAI = 0;
                            int RoundCounter = 0;

                            int[,] a = new int[8, 8] {{0,0,0,0,0,0,0,0},
                                                  {0,0,0,0,0,0,0,0},
                                                  {0,0,0,0,0,0,0,0},
                                                  {0,0,0,0,0,0,0,0},
                                                  {0,0,0,0,0,0,0,0},
                                                  {0,0,0,0,0,0,0,0},
                                                  {0,0,0,0,0,0,0,0},
                                                  {0,0,0,0,0,0,0,0}};


                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;

                            while (c <= 32)//Main Loop
                            {
                                Console.Clear();

                                Console.WriteLine("   1 2 3 4 5 6 7 8  ");//Begining of the first board output
                                Console.Write(" + - - - - - - - - +");
                                Console.WriteLine("Round   : " + RoundCounter);
                                Console.Write("1| ");

                                for (int i = 0; i < 1; i++)
                                {
                                    for (int j = 0; j < a.GetLength(1); j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }
                                    Console.Write("|");
                                }
                                Console.WriteLine("Human   : " + StoneCounterHuman);
                                Console.Write("2| ");

                                for (int i = 1; i < 2; i++)
                                {
                                    for (int j = 0; j < a.GetLength(1); j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }
                                    Console.Write("|");
                                }
                                Console.WriteLine("Computer: " + StoneCounterAI);
                                Console.Write("3| ");

                                for (int i = 2; i < 3; i++)
                                {
                                    for (int j = 0; j < 2; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }

                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                                for (int i = 2; i < 3; i++)
                                {
                                    for (int j = 2; j < 5; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                for (int i = 2; i < 3; i++)
                                {
                                    for (int j = 5; j < 6; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write("."); }
                                        else if (a[i, j] == 1) { Console.Write("o"); }
                                        else if (a[i, j] == 2) { Console.Write("x"); }
                                    }

                                }
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write(" ");
                                for (int i = 2; i < 3; i++)
                                {
                                    for (int j = 6; j < 8; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                Console.WriteLine("|");
                                Console.Write("4| ");
                                for (int i = 3; i < 4; i++)
                                {
                                    for (int j = 0; j < 2; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                                for (int i = 3; i < 4; i++)
                                {
                                    for (int j = 2; j < 5; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                for (int i = 3; i < 4; i++)
                                {
                                    for (int j = 5; j < 6; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write("."); }
                                        else if (a[i, j] == 1) { Console.Write("o"); }
                                        else if (a[i, j] == 2) { Console.Write("x"); }
                                    }

                                }
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write(" ");
                                for (int i = 3; i < 4; i++)
                                {
                                    for (int j = 6; j < 8; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                Console.WriteLine("|");
                                Console.Write("5| ");
                                for (int i = 4; i < 5; i++)
                                {
                                    for (int j = 0; j < 2; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                                for (int i = 4; i < 5; i++)
                                {
                                    for (int j = 2; j < 5; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                for (int i = 4; i < 5; i++)
                                {
                                    for (int j = 5; j < 6; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write("."); }
                                        else if (a[i, j] == 1) { Console.Write("o"); }
                                        else if (a[i, j] == 2) { Console.Write("x"); }
                                    }

                                }
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write(" ");
                                for (int i = 4; i < 5; i++)
                                {
                                    for (int j = 6; j < 8; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                Console.WriteLine("|");
                                Console.Write("6| ");
                                for (int i = 5; i < 6; i++)
                                {
                                    for (int j = 0; j < 2; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                                for (int i = 5; i < 6; i++)
                                {
                                    for (int j = 2; j < 5; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                for (int i = 5; i < 6; i++)
                                {
                                    for (int j = 5; j < 6; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write("."); }
                                        else if (a[i, j] == 1) { Console.Write("o"); }
                                        else if (a[i, j] == 2) { Console.Write("x"); }
                                    }

                                }
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write(" ");
                                for (int i = 5; i < 6; i++)
                                {
                                    for (int j = 6; j < 8; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                Console.WriteLine("|");
                                Console.Write("7| ");
                                for (int i = 6; i < 7; i++)
                                {
                                    for (int j = 0; j < a.GetLength(1); j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }
                                    Console.WriteLine("|");
                                }

                                Console.Write("8| ");

                                for (int i = 7; i < 8; i++)
                                {
                                    for (int j = 0; j < a.GetLength(1); j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }
                                    Console.WriteLine("|");
                                }

                                Console.WriteLine(" + - - - - - - - - +");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;

                            geri:
                                Console.Write("Enter x: ");
                                int x = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter y: ");
                                int y = Convert.ToInt32(Console.ReadLine());

                                while (saf == false)//Wrong Entry Controller(Alarm)
                                {
                                    if (x > 8 || x < 1 || y > 8 || y < 1)
                                    {
                                        Console.WriteLine("Wrong entry");
                                        Console.ReadLine();
                                        Console.Write("Enter x:");
                                        x = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Enter y: ");
                                        y = Convert.ToInt32(Console.ReadLine());
                                    }
                                    else
                                    { saf = true; }

                                }
                                saf = false;

                                while (asd == false)// Safe Area Controller
                                {
                                    if (x < 3 || (x == 3 && (y < 3 || y > 6)) || (x == 4 && (y < 3 || y > 6)) || (x == 5 && (y < 3 || y > 6)) || (x == 6 && (y < 3 || y > 6)) || x > 6)
                                    {
                                        Console.WriteLine("You can't put stone to out of safe area!");
                                        Console.WriteLine("Please try again");
                                        Console.Write("Enter x:");
                                        x = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Enter y: ");
                                        y = Convert.ToInt32(Console.ReadLine());
                                    }
                                    else
                                    {
                                        asd = true;

                                    }
                                }

                                if (c >= 1 && a[x - 1, y - 1] != 0)//Empty Place Controller
                                {
                                    Console.WriteLine("this place isn't empty. please choose another place");
                                    Console.ReadLine();
                                    goto geri;
                                }

                                else if (c >= 1 && (((x == 1 && y == 1) && a[x - 1, y] == 0 && a[x - 1, y + 1] == 0 && a[x, y - 1] == 0 && a[x, y] == 0 && a[x + 1, y - 1] == 0 && a[x + 1, y + 1] == 0) || ((x == 1 && y == 2) && a[x - 1, y - 2] == 0 && a[x, y - 2] == 0 && a[x, y - 1] == 0 && a[x + 1, y - 1] == 0 && a[x + 1, y + 1] == 0 && a[x, y] == 0 && a[x - 1, y] == 0 && a[x - 1, y + 1] == 0) || ((x == 1 && y == 7) && a[x - 1, y - 3] == 0 && a[x, y - 2] == 0 && a[x, y - 1] == 0 && a[x + 1, y - 1] == 0 && a[x + 1, y - 3] == 0 && a[x, y] == 0 && a[x - 1, y] == 0 && a[x - 1, y - 2] == 0) || ((x == 1 && y == 8) && a[x - 1, y - 2] == 0 && a[x - 1, y - 3] == 0 && a[x, y - 1] == 0 && a[x, y - 2] == 0 && a[x + 1, y - 1] == 0 && a[x + 1, y - 3] == 0) || ((x == 1 && (y == 3 || y == 4 || y == 5 || y == 6)) && a[x - 1, y - 3] == 0 && a[x - 1, y - 2] == 0 && a[x - 1, y] == 0 && a[x - 1, y + 1] == 0 && a[x, y - 2] == 0 && a[x, y - 1] == 0 && a[x, y] == 0 && a[x + 1, y - 3] == 0 && a[x + 1, y - 1] == 0 && a[x + 1, y + 1] == 0)
                                    || ((x == 2 && y == 1) && a[x - 1, y] == 0 && a[x - 1, y + 1] == 0 && a[x, y - 1] == 0 && a[x, y] == 0 && a[x + 1, y - 1] == 0 && a[x + 1, y + 1] == 0 && a[x - 2, y - 1] == 0 && a[x - 2, y] == 0) || ((x == 2 && y == 2) && a[x - 1, y] == 0 && a[x - 1, y + 1] == 0 && a[x, y - 1] == 0 && a[x, y] == 0 && a[x + 1, y - 1] == 0 && a[x + 1, y + 1] == 0 && a[x - 2, y - 1] == 0 && a[x - 2, y] == 0 && a[x - 2, y - 2] == 0 && a[x - 1, y - 2] == 0 && a[x, y - 2] == 0) || ((x == 2 && (y == 3 || y == 4 || y == 5 || y == 6)) && a[x - 1, y] == 0 && a[x - 1, y + 1] == 0 && a[x, y - 1] == 0 && a[x, y] == 0 && a[x + 1, y - 1] == 0 && a[x + 1, y + 1] == 0 && a[x - 2, y - 1] == 0 && a[x - 2, y] == 0 && a[x - 2, y - 2] == 0 && a[x - 1, y - 2] == 0 && a[x, y - 2] == 0 && a[x - 1, y - 3] == 0 && a[x + 1, y - 3] == 0) || ((x == 2 && y == 7) && a[x - 1, y] == 0 && a[x, y - 1] == 0 && a[x, y] == 0 && a[x + 1, y - 1] == 0 && a[x - 2, y - 1] == 0 && a[x - 2, y] == 0 && a[x - 2, y - 2] == 0 && a[x - 1, y - 2] == 0 && a[x, y - 2] == 0 && a[x - 1, y - 3] == 0 && a[x + 1, y - 3] == 0) || ((x == 2 && y == 8) && a[x - 1, y - 2] == 0 && a[x - 1, y - 3] == 0 && a[x, y - 1] == 0 && a[x, y - 2] == 0 && a[x + 1, y - 1] == 0 && a[x + 1, y - 3] == 0 && a[x - 2, y - 2] == 0 && a[x - 2, y - 1] == 0)
                                    || (((x == 3 || x == 4 || x == 5 || x == 6) && y == 1) && a[x - 1, y] == 0 && a[x - 1, y + 1] == 0 && a[x, y - 1] == 0 && a[x, y] == 0 && a[x + 1, y - 1] == 0 && a[x + 1, y + 1] == 0 && a[x - 2, y - 1] == 0 && a[x - 2, y] == 0 && a[x - 3, y - 1] == 0 && a[x - 3, y + 1] == 0) || (((x == 3 || x == 4 || x == 5 || x == 6) && y == 2) && a[x - 1, y] == 0 && a[x - 1, y + 1] == 0 && a[x, y - 1] == 0 && a[x, y] == 0 && a[x + 1, y - 1] == 0 && a[x + 1, y + 1] == 0 && a[x - 2, y - 1] == 0 && a[x - 2, y] == 0 && a[x - 3, y - 1] == 0 && a[x - 3, y + 1] == 0 && a[x - 2, y - 2] == 0 && a[x - 1, y - 2] == 0 && a[x, y - 2] == 0) || (((x == 3 || x == 4 || x == 5 || x == 6) && y == 7) && a[x - 1, y] == 0 && a[x, y - 1] == 0 && a[x, y] == 0 && a[x + 1, y - 1] == 0 && a[x - 2, y - 1] == 0 && a[x - 2, y] == 0 && a[x - 2, y - 2] == 0 && a[x - 1, y - 2] == 0 && a[x, y - 2] == 0 && a[x - 1, y - 3] == 0 && a[x + 1, y - 3] == 0 && a[x - 3, y - 3] == 0 && a[x - 3, y - 1] == 0) || (((x == 3 || x == 4 || x == 5 || x == 6) && y == 8) && a[x - 1, y - 2] == 0 && a[x - 1, y - 3] == 0 && a[x, y - 1] == 0 && a[x, y - 2] == 0 && a[x + 1, y - 1] == 0 && a[x + 1, y - 3] == 0 && a[x - 2, y - 2] == 0 && a[x - 2, y - 1] == 0 && a[x - 3, y - 3] == 0 && a[x - 3, y - 1] == 0)
                                    || ((x == 7 && y == 1) && a[x - 3, y - 1] == 0 && a[x - 3, y + 1] == 0 && a[x - 2, y - 1] == 0 && a[x - 2, y] == 0 && a[x - 1, y] == 0 && a[x - 1, y + 1] == 0 && a[x, y - 1] == 0 && a[x, y] == 0) || ((x == 7 && y == 2) && a[x - 3, y - 1] == 0 && a[x - 3, y + 1] == 0 && a[x - 2, y - 1] == 0 && a[x - 2, y] == 0 && a[x - 1, y] == 0 && a[x - 1, y + 1] == 0 && a[x, y - 1] == 0 && a[x, y] == 0 && a[x - 2, y - 2] == 0 && a[x - 1, y - 2] == 0 && a[x, y - 2] == 0) || ((x == 7 && (y == 3 || y == 4 || y == 5 || y == 6)) && a[x - 3, y - 1] == 0 && a[x - 3, y + 1] == 0 && a[x - 2, y - 1] == 0 && a[x - 2, y] == 0 && a[x - 1, y] == 0 && a[x - 1, y + 1] == 0 && a[x, y - 1] == 0 && a[x, y] == 0 && a[x - 2, y - 2] == 0 && a[x - 1, y - 2] == 0 && a[x, y - 2] == 0 && a[x - 3, y - 3] == 0 && a[x - 1, y - 3] == 0) || ((x == 7 && y == 7) && a[x - 3, y - 1] == 0 && a[x - 2, y - 1] == 0 && a[x - 2, y] == 0 && a[x - 1, y] == 0 && a[x, y - 1] == 0 && a[x, y] == 0 && a[x - 2, y - 2] == 0 && a[x - 1, y - 2] == 0 && a[x, y - 2] == 0 && a[x - 3, y - 3] == 0 && a[x - 1, y - 3] == 0) || ((x == 7 && y == 8) && a[x - 3, y - 1] == 0 && a[x - 2, y - 1] == 0 && a[x, y - 1] == 0 && a[x - 2, y - 2] == 0 && a[x - 1, y - 2] == 0 && a[x, y - 2] == 0 && a[x - 3, y - 3] == 0 && a[x - 1, y - 3] == 0)
                                    || ((x == 8 && y == 1) && a[x - 3, y - 1] == 0 && a[x - 3, y + 1] == 0 && a[x - 2, y - 1] == 0 && a[x - 2, y] == 0 && a[x - 1, y] == 0 && a[x - 1, y + 1] == 0) || ((x == 8 && y == 2) && a[x - 3, y - 1] == 0 && a[x - 3, y + 1] == 0 && a[x - 2, y - 1] == 0 && a[x - 2, y] == 0 && a[x - 1, y] == 0 && a[x - 1, y + 1] == 0 && a[x - 1, y - 2] == 0 && a[x - 2, y - 2] == 0) || ((x == 8 && (y == 3 || y == 4 || y == 5 || y == 6)) && a[x - 3, y - 1] == 0 && a[x - 3, y + 1] == 0 && a[x - 2, y - 1] == 0 && a[x - 2, y] == 0 && a[x - 1, y] == 0 && a[x - 1, y + 1] == 0 && a[x - 1, y - 2] == 0 && a[x - 2, y - 2] == 0 && a[x - 3, y - 3] == 0 && a[x - 1, y - 3] == 0) || ((x == 8 && y == 7) && a[x - 3, y - 1] == 0 && a[x - 2, y - 1] == 0 && a[x - 2, y] == 0 && a[x - 1, y] == 0 && a[x - 1, y - 2] == 0 && a[x - 2, y - 2] == 0 && a[x - 3, y - 3] == 0 && a[x - 1, y - 3] == 0) || ((x == 8 && y == 8) && a[x - 3, y - 1] == 0 && a[x - 2, y - 1] == 0 && a[x - 1, y - 2] == 0 && a[x - 2, y - 2] == 0 && a[x - 3, y - 3] == 0 && a[x - 1, y - 3] == 0)))
                                {
                                    Console.WriteLine("wrong entry. please choose different place");

                                    goto geri;
                                }
                                else
                                {
                                    a[x - 1, y - 1] = 1;
                                    c++;
                                }



                                for (tri = x - 1; tri < 8; tri++)// Horizontal scan and Conversion. Section 1 - Part 1
                                {
                                    for (trj = y - 1; trj < 8; trj++)
                                    {

                                        if (a[tri, trj] == 1)//For the Player
                                        {
                                            for (tr2 = trj + 1; tr2 <= 7 && turn1 == true && turn2 == true; tr2++)
                                            {
                                                if (a[tri, tr2] == 2) { trcounter1++; }
                                                else if (a[tri, tr2] == 0) { turn1 = false; }
                                                else if (a[tri, tr2] == 1) { turn2 = false; }
                                            }
                                            if (trcounter1 > 0 && turn1 == true && turn2 == false)
                                            {
                                                for (int r = trcounter1; r > 0; r--)
                                                {
                                                    a[tri, trj + r] = 1;
                                                }

                                            }
                                        }

                                        else if (a[tri, trj] == 2)//For the AI
                                        {
                                            for (tr2 = trj + 1; tr2 <= 7 && turn1 == true && turn2 == true; tr2++)
                                            {
                                                if (a[tri, tr2] == 1) { trcounter1++; }
                                                else if (a[tri, tr2] == 0) { turn1 = false; }
                                                else if (a[tri, tr2] == 2) { turn2 = false; }
                                            }
                                            if (trcounter1 > 0 && turn1 == true && turn2 == false)
                                            {
                                                for (int r = trcounter1; r > 0; r--)
                                                {
                                                    a[tri, trj + r] = 2;
                                                }

                                            }
                                        }
                                        trcounter1 = 0;
                                        turn1 = true;
                                        turn2 = true;
                                    }

                                }//Finish of the H scan. Part 1.
                                trcounter1 = 0;
                                turn1 = true;
                                turn2 = true;

                                for (trj = y - 1; trj < 8; trj++)//Vertical Scan and Conversion. Section 1 Part 1
                                {
                                    for (tri = x - 1; tri < 8; tri++)
                                    {

                                        if (a[tri, trj] == 1)//For the Player
                                        {
                                            for (tr1 = tri + 1; tr1 <= 7 && turn1 == true && turn2 == true; tr1++)
                                            {
                                                if (a[tr1, trj] == 2) { trcounter1++; }
                                                else if (a[tr1, trj] == 0) { turn1 = false; }
                                                else if (a[tr1, trj] == 1) { turn2 = false; }
                                            }


                                            if (trcounter1 > 0 && turn1 == true && turn2 == false)
                                            {
                                                for (int r = trcounter1; r > 0; r--)
                                                {
                                                    a[tri + r, trj] = 1;
                                                }
                                                trcounter1 = 0;


                                            }

                                        }

                                        else if (a[tri, trj] == 2)//For the AI
                                        {
                                            for (tr1 = tri + 1; tr1 <= 7 && turn1 == true && turn2 == true; tr1++)
                                            {
                                                if (a[tr1, trj] == 1) { trcounter1++; }
                                                else if (a[tr1, trj] == 0) { turn1 = false; }
                                                else if (a[tr1, trj] == 2) { turn2 = false; }
                                            }

                                            if (trcounter1 > 0 && turn1 == true && turn2 == false)
                                            {
                                                for (int r = trcounter1; r > 0; r--)
                                                {
                                                    a[tri + r, trj] = 2;
                                                }
                                                trcounter1 = 0;
                                            }

                                        }
                                        trcounter1 = 0;

                                        turn1 = true;
                                        turn2 = true;
                                    }

                                }//Finish of the Vert. Scan. Part 1
                                trcounter1 = 0;
                                turn1 = true;
                                turn2 = true;

                                for (trj = y - 1; trj < 8; trj++)//Diagonally Scan and Conversion. Section 1 - Part1 
                                {
                                    for (tri = 0; tri < 8; tri++)
                                    {
                                        if (a[tri, trj] == 1)//For the PLayer
                                        {
                                            tr1 = tri + 1;
                                            tr2 = trj + 1;
                                            while ((tr1 <= 7 && tr2 <= 7) && turn3 == true && turn4 == true)
                                            {

                                                if (a[tr1, tr2] == 2) { trcounter2++; }
                                                else if (a[tr1, tr2] == 0) { turn3 = false; }
                                                else if (a[tr1, tr2] == 1) { turn4 = false; }

                                                tr1++;
                                                tr2++;

                                            }
                                            tr1 = tri - 1;
                                            tr2 = trj + 1;
                                            while ((tr1 >= 0 && tr2 <= 7) && turn5 == true && turn6 == true)
                                            {

                                                if (a[tr1, tr2] == 2) { trcounter3++; }
                                                else if (a[tr1, tr2] == 0) { turn5 = false; }
                                                else if (a[tr1, tr2] == 1) { turn6 = false; }

                                                tr1--;
                                                tr2++;

                                            }
                                            if (trcounter2 > 0 && turn3 == true && turn4 == false)
                                            {
                                                for (int r = trcounter2; r > 0; r--)
                                                {
                                                    a[tri + r, trj + r] = 1;


                                                }
                                                trcounter2 = 0;

                                            }
                                            if (trcounter3 > 0 && turn5 == true && turn6 == false)
                                            {
                                                for (int r = trcounter3; r > 0; r--)
                                                {
                                                    a[tri - r, trj + r] = 1;


                                                }
                                                trcounter3 = 0;

                                            }
                                        }
                                        else if (a[tri, trj] == 2)//For the AI
                                        {
                                            tr1 = tri + 1;
                                            tr2 = trj + 1;

                                            while ((tr1 <= 7 && tr2 <= 7) && turn3 == true && turn4 == true)
                                            {

                                                if (a[tr1, tr2] == 1) { trcounter2++; }
                                                else if (a[tr1, tr2] == 0) { turn3 = false; }
                                                else if (a[tr1, tr2] == 2) { turn4 = false; }

                                                tr1++;
                                                tr2++;

                                            }
                                            tr1 = tri - 1;
                                            tr2 = trj + 1;
                                            while ((tr1 >= 0 && tr2 <= 7) && turn5 == true && turn6 == true)
                                            {

                                                if (a[tr1, tr2] == 1) { trcounter3++; }
                                                else if (a[tr1, tr2] == 0) { turn5 = false; }
                                                else if (a[tr1, tr2] == 2) { turn6 = false; }

                                                tr1--;
                                                tr2++;

                                            }
                                            if (trcounter2 > 0 && turn3 == true && turn4 == false)
                                            {
                                                for (int r = trcounter2; r > 0; r--)
                                                {
                                                    a[tri + r, trj + r] = 2;
                                                }
                                                trcounter2 = 0;

                                            }
                                            if (trcounter3 > 0 && turn5 == true && turn6 == false)
                                            {
                                                for (int r = trcounter3; r > 0; r--)
                                                {
                                                    a[tri - r, trj + r] = 2;
                                                }
                                                trcounter3 = 0;
                                            }
                                        }
                                        trcounter2 = 0;
                                        trcounter3 = 0;
                                        turn3 = true;
                                        turn4 = true;
                                        turn5 = true;
                                        turn6 = true;
                                    }

                                }

                                for (tri = 0; tri <= x - 1; tri++)//Horizontal Scan and Conversion. Section 1 - Part 2
                                {
                                    for (trj = 0; trj <= y - 1; trj++)
                                    {

                                        if (a[tri, trj] == 1)
                                        {
                                            for (tr2 = trj + 1; tr2 <= 7 && turn1 == true && turn2 == true; tr2++)
                                            {
                                                if (a[tri, tr2] == 2) { trcounter1++; }
                                                else if (a[tri, tr2] == 0) { turn1 = false; }
                                                else if (a[tri, tr2] == 1) { turn2 = false; }
                                            }
                                            if (trcounter1 > 0 && turn1 == true && turn2 == false)
                                            {
                                                for (int r = trcounter1; r > 0; r--)
                                                {
                                                    a[tri, trj + r] = 1;
                                                }
                                                trcounter1 = 0;
                                            }
                                        }

                                        else if (a[tri, trj] == 2)
                                        {
                                            for (tr2 = trj + 1; tr2 <= 7 && turn1 == true && turn2 == true; tr2++)
                                            {
                                                if (a[tri, tr2] == 1) { trcounter1++; }
                                                else if (a[tri, tr2] == 0) { turn1 = false; }
                                                else if (a[tri, tr2] == 2) { turn2 = false; }
                                            }
                                            if (trcounter1 > 0 && turn1 == true && turn2 == false)
                                            {
                                                for (int r = trcounter1; r > 0; r--)
                                                {
                                                    a[tri, trj + r] = 2;
                                                }
                                                trcounter1 = 0;
                                            }
                                        }
                                        trcounter1 = 0;
                                        turn1 = true;
                                        turn2 = true;
                                    }

                                }//Finish of the H scan. Part 2
                                trcounter1 = 0;

                                turn1 = true;
                                turn2 = true;

                                for (trj = 0; trj <= y - 1; trj++)//Vertical Scan and Conversion. Section 1 -Part2
                                {
                                    for (tri = 0; tri <= x - 1; tri++)
                                    {

                                        if (a[tri, trj] == 1)//For the Player
                                        {
                                            for (tr1 = tri + 1; tr1 <= 7 && turn1 == true && turn2 == true; tr1++)
                                            {
                                                if (a[tr1, trj] == 2) { trcounter1++; }
                                                else if (a[tr1, trj] == 0) { turn1 = false; }
                                                else if (a[tr1, trj] == 1) { turn2 = false; }
                                            }



                                            if (trcounter1 > 0 && turn1 == true && turn2 == false)
                                            {
                                                for (int r = trcounter1; r > 0; r--)
                                                {
                                                    a[tri + r, trj] = 1;
                                                }
                                                trcounter1 = 0;


                                            }

                                        }

                                        else if (a[tri, trj] == 2)//For the AI
                                        {
                                            for (tr1 = tri + 1; tr1 <= 7 && turn1 == true && turn2 == true; tr1++)
                                            {
                                                if (a[tr1, trj] == 1) { trcounter1++; }
                                                else if (a[tr1, trj] == 0) { turn1 = false; }
                                                else if (a[tr1, trj] == 2) { turn2 = false; }
                                            }

                                            if (trcounter1 > 0 && turn1 == true && turn2 == false)
                                            {
                                                for (int r = trcounter1; r > 0; r--)
                                                {
                                                    a[tri + r, trj] = 2;
                                                }
                                                trcounter1 = 0;
                                            }

                                        }
                                        trcounter1 = 0;

                                        turn1 = true;
                                        turn2 = true;

                                    }

                                } //Finish of the Vert. Scan. Part2


                                for (trj = 0; trj <= y - 1; trj++)//Diagonally Scan and Conversion. Section 1 - Part2
                                {
                                    for (tri = 0; tri < 8; tri++)
                                    {
                                        if (a[tri, trj] == 1)//For the Player
                                        {
                                            tr1 = tri + 1;
                                            tr2 = trj + 1;
                                            while ((tr1 <= 7 && tr2 <= 7) && turn3 == true && turn4 == true)
                                            {

                                                if (a[tr1, tr2] == 2) { trcounter2++; }
                                                else if (a[tr1, tr2] == 0) { turn3 = false; }
                                                else if (a[tr1, tr2] == 1) { turn4 = false; }

                                                tr1++;
                                                tr2++;

                                            }
                                            tr1 = tri - 1;
                                            tr2 = trj + 1;
                                            while ((tr1 >= 0 && tr2 <= 7) && turn5 == true && turn6 == true)
                                            {

                                                if (a[tr1, tr2] == 2) { trcounter3++; }
                                                else if (a[tr1, tr2] == 0) { turn5 = false; }
                                                else if (a[tr1, tr2] == 1) { turn6 = false; }

                                                tr1--;
                                                tr2++;

                                            }
                                            if (trcounter2 > 0 && turn3 == true && turn4 == false)
                                            {
                                                for (int r = trcounter2; r > 0; r--)
                                                {
                                                    a[tri + r, trj + r] = 1;


                                                }
                                                trcounter2 = 0;

                                            }
                                            if (trcounter3 > 0 && turn5 == true && turn6 == false)
                                            {
                                                for (int r = trcounter3; r > 0; r--)
                                                {
                                                    a[tri - r, trj + r] = 1;


                                                }
                                                trcounter3 = 0;

                                            }
                                        }
                                        else if (a[tri, trj] == 2)//For the AI
                                        {
                                            tr1 = tri + 1;
                                            tr2 = trj + 1;

                                            while ((tr1 <= 7 && tr2 <= 7) && turn3 == true && turn4 == true)
                                            {

                                                if (a[tr1, tr2] == 1) { trcounter2++; }
                                                else if (a[tr1, tr2] == 0) { turn3 = false; }
                                                else if (a[tr1, tr2] == 2) { turn4 = false; }

                                                tr1++;
                                                tr2++;

                                            }
                                            tr1 = tri - 1;
                                            tr2 = trj + 1;
                                            while ((tr1 >= 0 && tr2 <= 7) && turn5 == true && turn6 == true)
                                            {

                                                if (a[tr1, tr2] == 1) { trcounter3++; }
                                                else if (a[tr1, tr2] == 0) { turn5 = false; }
                                                else if (a[tr1, tr2] == 2) { turn6 = false; }

                                                tr1--;
                                                tr2++;

                                            }
                                            if (trcounter2 > 0 && turn3 == true && turn4 == false)
                                            {
                                                for (int r = trcounter2; r > 0; r--)
                                                {
                                                    a[tri + r, trj + r] = 2;
                                                }
                                                trcounter2 = 0;

                                            }
                                            if (trcounter3 > 0 && turn5 == true && turn6 == false)
                                            {
                                                for (int r = trcounter3; r > 0; r--)
                                                {
                                                    a[tri - r, trj + r] = 2;
                                                }
                                                trcounter3 = 0;
                                            }
                                        }
                                        trcounter2 = 0;
                                        trcounter3 = 0;
                                        turn3 = true;
                                        turn4 = true;
                                        turn5 = true;
                                        turn6 = true;
                                    }

                                }

                                trcounter1 = 0;

                                turn1 = true;
                                turn2 = true;
                                turn3 = true;
                                turn4 = true;
                                turn5 = true;
                                turn6 = true;
                                StoneCounterHuman = 0;
                                StoneCounterAI = 0;
                                for (int i = 0; i < a.GetLength(0); i++)
                                {
                                    for (int j = 0; j < a.GetLength(1); j++)
                                    {
                                        if (a[i, j] == 1) { StoneCounterHuman++; }
                                        if (a[i, j] == 2) { StoneCounterAI++; }
                                    }
                                }
                                RoundCounter++;
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.Clear();
                                //Second Part
                                Console.WriteLine("   1 2 3 4 5 6 7 8  ");
                                Console.Write(" + - - - - - - - - +");
                                Console.WriteLine("Round   : " + RoundCounter);
                                Console.Write("1| ");

                                for (int i = 0; i < 1; i++)
                                {
                                    for (int j = 0; j < a.GetLength(1); j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }
                                    Console.Write("|");
                                }
                                Console.WriteLine("Human   : " + StoneCounterHuman);

                                Console.Write("2| ");

                                for (int i = 1; i < 2; i++)
                                {
                                    for (int j = 0; j < a.GetLength(1); j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }
                                    Console.Write("|");
                                }
                                Console.WriteLine("Computer: " + StoneCounterAI);
                                Console.Write("3| ");

                                for (int i = 2; i < 3; i++)
                                {
                                    for (int j = 0; j < 2; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }

                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                                for (int i = 2; i < 3; i++)
                                {
                                    for (int j = 2; j < 5; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                for (int i = 2; i < 3; i++)
                                {
                                    for (int j = 5; j < 6; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write("."); }
                                        else if (a[i, j] == 1) { Console.Write("o"); }
                                        else if (a[i, j] == 2) { Console.Write("x"); }
                                    }

                                }
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write(" ");
                                for (int i = 2; i < 3; i++)
                                {
                                    for (int j = 6; j < 8; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                Console.WriteLine("|");
                                Console.Write("4| ");
                                for (int i = 3; i < 4; i++)
                                {
                                    for (int j = 0; j < 2; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                                for (int i = 3; i < 4; i++)
                                {
                                    for (int j = 2; j < 5; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                for (int i = 3; i < 4; i++)
                                {
                                    for (int j = 5; j < 6; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write("."); }
                                        else if (a[i, j] == 1) { Console.Write("o"); }
                                        else if (a[i, j] == 2) { Console.Write("x"); }
                                    }

                                }
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write(" ");
                                for (int i = 3; i < 4; i++)
                                {
                                    for (int j = 6; j < 8; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                Console.WriteLine("|");
                                Console.Write("5| ");
                                for (int i = 4; i < 5; i++)
                                {
                                    for (int j = 0; j < 2; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                                for (int i = 4; i < 5; i++)
                                {
                                    for (int j = 2; j < 5; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                for (int i = 4; i < 5; i++)
                                {
                                    for (int j = 5; j < 6; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write("."); }
                                        else if (a[i, j] == 1) { Console.Write("o"); }
                                        else if (a[i, j] == 2) { Console.Write("x"); }
                                    }

                                }
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write(" ");
                                for (int i = 4; i < 5; i++)
                                {
                                    for (int j = 6; j < 8; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                Console.WriteLine("|");
                                Console.Write("6| ");
                                for (int i = 5; i < 6; i++)
                                {
                                    for (int j = 0; j < 2; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                                for (int i = 5; i < 6; i++)
                                {
                                    for (int j = 2; j < 5; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                for (int i = 5; i < 6; i++)
                                {
                                    for (int j = 5; j < 6; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write("."); }
                                        else if (a[i, j] == 1) { Console.Write("o"); }
                                        else if (a[i, j] == 2) { Console.Write("x"); }
                                    }

                                }
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write(" ");
                                for (int i = 5; i < 6; i++)
                                {
                                    for (int j = 6; j < 8; j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }

                                }
                                Console.WriteLine("|");
                                Console.Write("7| ");
                                for (int i = 6; i < 7; i++)
                                {
                                    for (int j = 0; j < a.GetLength(1); j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }
                                    Console.WriteLine("|");
                                }

                                Console.Write("8| ");

                                for (int i = 7; i < 8; i++)
                                {
                                    for (int j = 0; j < a.GetLength(1); j++)
                                    {
                                        if (a[i, j] == 0) { Console.Write(". "); }
                                        else if (a[i, j] == 1) { Console.Write("o "); }
                                        else if (a[i, j] == 2) { Console.Write("x "); }
                                    }
                                    Console.WriteLine("|");
                                }

                                Console.WriteLine(" + - - - - - - - - +");

                                Random rnd = new Random();
                                Console.WriteLine("Press 'Enter' for next round");

                                if ((a[0, 0] == 0 && (a[0, 1] != 0 || a[0, 2] != 0 || a[1, 0] != 0 || a[2, 0] != 0 || a[1, 1] != 0 || a[2, 2] != 0)) || // AI Algorithm To Control For Corners (First Priority)
                                    (a[7, 0] == 0 && (a[5, 0] != 0 || a[6, 0] != 0 || a[7, 1] != 0 || a[7, 2] != 0 || a[6, 1] != 0 || a[5, 2] != 0)) ||
                                    (a[0, 7] == 0 && (a[0, 6] != 0 || a[0, 5] != 0 || a[1, 7] != 0 || a[2, 7] != 0 || a[1, 6] != 0 || a[2, 5] != 0)) ||
                                    (a[7, 7] == 0 && (a[6, 6] != 0 || a[5, 5] != 0 || a[7, 6] != 0 || a[7, 5] != 0 || a[6, 7] != 0 || a[5, 7] != 0)))
                                {
                                    while (flago1 == false)
                                    {
                                        corner = rnd.Next(1, 5);

                                        switch (corner)
                                        {
                                            case 1:
                                                if (a[0, 0] == 0 && (a[0, 1] != 0 || a[0, 2] != 0 || a[1, 0] != 0 || a[2, 0] != 0 || a[1, 1] != 0 || a[2, 2] != 0))
                                                {
                                                    a[0, 0] = 2;
                                                    flago1 = true; flago13 = true; flago12 = true; flago11 = false; flago2 = true; flago3 = true;
                                                }
                                                break;

                                            case 2:
                                                if (a[7, 0] == 0 && (a[5, 0] != 0 || a[6, 0] != 0 || a[7, 1] != 0 || a[7, 2] != 0 || a[6, 1] != 0 || a[5, 2] != 0))
                                                {
                                                    a[7, 0] = 2;
                                                    flago1 = true; flago13 = true; flago12 = true; flago11 = false; flago2 = true; flago3 = true;
                                                }
                                                break;

                                            case 3:
                                                if (a[0, 7] == 0 && (a[0, 6] != 0 || a[0, 5] != 0 || a[1, 7] != 0 || a[2, 7] != 0 || a[1, 6] != 0 || a[2, 5] != 0))
                                                {
                                                    a[0, 7] = 2;
                                                    flago1 = true; flago13 = true; flago12 = true; flago11 = false; flago2 = true; flago3 = true;
                                                }
                                                break;

                                            case 4:
                                                if (a[7, 7] == 0 && (a[6, 6] != 0 || a[5, 5] != 0 || a[7, 6] != 0 || a[7, 5] != 0 || a[6, 7] != 0 || a[5, 7] != 0))
                                                {
                                                    a[7, 7] = 2;
                                                    flago1 = true; flago13 = true; flago12 = true; flago11 = false; flago2 = true; flago3 = true;
                                                }
                                                break;
                                        }
                                    }
                                }
                                flago1 = false;

                                if (flago11 == false) // AI Algorithm To Control For Opposite Edges If it Has a Stone On The Edge
                                {
                                    for (int k = 1; k <= 6; k++)
                                    {
                                        if (k == 1)//to not get index out
                                        {
                                            if ((a[0, k] == 2 && a[7, k] == 0) && (a[7, k + 1] != 0 || a[6, k] != 0 || a[5, k] != 0 ||
                                              a[6, k + 1] != 0 || a[5, k + 2] != 0 || a[7, k - 1] != 0 || a[6, k - 1] != 0))
                                            {
                                                if (a[7, 0] == 0 && (k == 1 || k == 2)) { flago11 = false; }
                                                else
                                                {
                                                    a[7, k] = 2;
                                                    flago13 = true; flago12 = true; flago2 = true; flago3 = true;
                                                    break;
                                                }
                                            }

                                            if ((a[7, k] == 2 && a[0, k] == 0) && (a[0, k + 1] != 0 || a[1, k] != 0 || a[2, k] != 0 ||
                                                a[1, k + 1] != 0 || a[1, k - 1] != 0 || a[2, k - 2] != 0 || a[0, k - 1] != 0 || a[0, k - 2] != 0))
                                            {
                                                if (a[0, 0] == 0 && (k == 1 || k == 2)) { flago11 = false; }
                                                else
                                                {
                                                    a[0, k] = 2;
                                                    flago13 = true; flago12 = true; flago2 = true; flago3 = true;
                                                    break;
                                                }
                                            }

                                            if ((a[k, 0] == 2 && a[k, 7] == 0) && (a[k, 6] != 0 || a[k, 7] != 0 || a[k - 1, 7] != 0 ||
                                                a[k + 1, 7] != 0 || a[k + 2, 7] != 0 || a[k - 1, 6] != 0 || a[k + 1, 6] != 0 || a[k + 2, 5] != 0))
                                            {
                                                if (a[0, 7] == 0 && (k == 1 || k == 2)) { flago11 = false; }
                                                else
                                                {
                                                    a[k, 7] = 2;
                                                    flago13 = true; flago12 = true; flago2 = true; flago3 = true;
                                                    break;
                                                }
                                            }

                                            if ((a[k, 7] == 2 && a[k, 0] == 0) && (a[k, 1] != 0 || a[k, 2] != 0 || a[k - 1, 1] != 0 ||
                                                a[k + 1, 1] != 0 || a[k + 2, 2] != 0 || a[k - 1, 0] != 0 || a[k + 1, 0] != 0 || a[k + 2, 0] != 0))
                                            {
                                                if (a[0, 0] == 0 && (k == 1 || k == 2)) { flago11 = false; }
                                                else
                                                {
                                                    a[k, 0] = 2;
                                                    flago13 = true; flago12 = true; flago2 = true; flago3 = true;
                                                    break;
                                                }
                                            }
                                        }
                                        else if (k == 6) // to not get index out
                                        {
                                            if ((a[0, k] == 2 && a[7, k] == 0) && (a[7, k + 1] != 0 || a[6, k] != 0 || a[5, k] != 0 ||
                                                a[6, k + 1] != 0 || a[7, k - 1] != 0 || a[7, k - 2] != 0 || a[6, k - 1] != 0 || a[5, k - 2] != 0))
                                            {
                                                if (a[7, 7] == 0 && (k == 6 || k == 5)) { flago11 = false; }
                                                else
                                                {
                                                    a[7, k] = 2;
                                                    flago13 = true; flago12 = true; flago2 = true; flago3 = true;
                                                    break;
                                                }
                                            }

                                            if ((a[7, k] == 2 && a[0, k] == 0) && (a[0, k + 1] != 0 || a[1, k] != 0 || a[2, k] != 0 ||
                                                a[1, k + 1] != 0 || a[1, k - 1] != 0 || a[2, k - 2] != 0 || a[0, k - 1] != 0 || a[0, k - 2] != 0))
                                            {
                                                if (a[0, 7] == 0 && (k == 6 || k == 5)) { flago11 = false; }
                                                else
                                                {
                                                    a[0, k] = 2;
                                                    flago13 = true; flago12 = true; flago2 = true; flago3 = true;
                                                    break;
                                                }
                                            }

                                            if ((a[k, 0] == 2 && a[k, 7] == 0) && (a[k, 6] != 0 || a[k, 7] != 0 || a[k - 1, 7] != 0 || a[k - 2, 7] != 0 ||
                                                a[k + 1, 7] != 0 || a[k - 1, 6] != 0 || a[k - 2, 5] != 0 || a[k + 1, 6] != 0))
                                            {
                                                if (a[7, 7] == 0 && (k == 6 || k == 5)) { flago11 = false; }
                                                else
                                                {
                                                    a[k, 7] = 2;
                                                    flago13 = true; flago12 = true; flago2 = true; flago3 = true;
                                                    break;
                                                }
                                            }

                                            if ((a[k, 7] == 2 && a[k, 0] == 0) && (a[k, 1] != 0 || a[k, 2] != 0 || a[k - 1, 1] != 0 || a[k - 2, 2] != 0 ||
                                                a[k + 1, 1] != 0 || a[k - 1, 0] != 0 || a[k - 2, 0] != 0 || a[k + 1, 0] != 0))
                                            {
                                                if (a[7, 0] == 0 && (k == 6 || k == 5)) { flago11 = false; }
                                                else
                                                {
                                                    a[k, 0] = 2;
                                                    flago13 = true; flago12 = true; flago2 = true; flago3 = true;
                                                    break;
                                                }
                                            }
                                        }
                                        if (k < 7 && k > 1) // to not get index out
                                        {
                                            if ((a[0, k] == 2 && a[7, k] == 0) && (a[7, k + 1] != 0 || a[7, k + 2] != 0 || a[6, k] != 0 || a[5, k] != 0 ||
                                                a[6, k + 1] != 0 || a[5, k + 2] != 0 || a[7, k - 1] != 0 || a[7, k - 2] != 0 || a[6, k - 1] != 0 || a[5, k - 2] != 0))
                                            {
                                                if (a[7, 0] == 0 && (k == 1 || k == 2)) { flago11 = false; }
                                                else if (a[7, 7] == 0 && (k == 6 || k == 5)) { flago11 = false; }
                                                else
                                                {
                                                    a[7, k] = 2;
                                                    flago13 = true; flago12 = true; flago2 = true; flago3 = true;
                                                    break;
                                                }
                                            }

                                            if ((a[7, k] == 2 && a[0, k] == 0) && (a[0, k + 1] != 0 || a[0, k + 2] != 0 || a[1, k] != 0 || a[2, k] != 0 ||
                                                a[1, k + 1] != 0 || a[2, k + 2] != 0 || a[1, k - 1] != 0 || a[2, k - 2] != 0 || a[0, k - 1] != 0 || a[0, k - 2] != 0))
                                            {
                                                if (a[0, 0] == 0 && (k == 1 || k == 2)) { flago11 = false; }
                                                else if (a[0, 7] == 0 && (k == 6 || k == 5)) { flago11 = false; }
                                                else
                                                {
                                                    a[0, k] = 2;
                                                    flago13 = true; flago12 = true; flago2 = true; flago3 = true;
                                                    break;
                                                }
                                            }

                                            if ((a[k, 0] == 2 && a[k, 7] == 0) && (a[k, 6] != 0 || a[k, 7] != 0 || a[k - 1, 7] != 0 || a[k - 2, 7] != 0 ||
                                                a[k + 1, 7] != 0 || a[k + 2, 7] != 0 || a[k - 1, 6] != 0 || a[k - 2, 5] != 0 || a[k + 1, 6] != 0 || a[k + 2, 5] != 0))
                                            {
                                                if (a[0, 7] == 0 && (k == 1 || k == 2)) { flago11 = false; }
                                                else if (a[7, 7] == 0 && (k == 6 || k == 5)) { flago11 = false; }
                                                else
                                                {
                                                    a[k, 7] = 2;
                                                    flago13 = true; flago12 = true; flago2 = true; flago3 = true;
                                                    break;
                                                }
                                            }

                                            if ((a[k, 7] == 2 && a[k, 0] == 0) && (a[k, 1] != 0 || a[k, 2] != 0 || a[k - 1, 1] != 0 || a[k - 2, 2] != 0 ||
                                                a[k + 1, 1] != 0 || a[k + 2, 2] != 0 || a[k - 1, 0] != 0 || a[k - 2, 0] != 0 || a[k + 1, 0] != 0 || a[k + 2, 0] != 0))
                                            {
                                                if (a[0, 0] == 0 && (k == 1 || k == 2)) { flago11 = false; }
                                                else if (a[7, 0] == 0 && (k == 6 || k == 5)) { flago11 = false; }
                                                else
                                                {
                                                    a[k, 0] = 2;
                                                    flago13 = true; flago12 = true; flago2 = true; flago3 = true;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                flago11 = false;

                                if (flago13 == false) // AI Algorithm To Control For Edges If Player Played To Edge Of The Safe Area
                                {

                                    if ((x - 1 == 2 || x - 1 == 1) && y - 1 == 3 && a[0, 3] == 0)
                                    {
                                        a[0, 3] = 2; flago12 = true; flago2 = true; flago3 = true;
                                    }
                                    else if ((x - 1 == 2 || x - 1 == 1) && y - 1 == 4 && a[0, 4] == 0)
                                    {
                                        a[0, 4] = 2; flago12 = true; flago2 = true; flago3 = true;
                                    }
                                    else if (x - 1 == 3 && (y - 1 == 1 || y - 1 == 2) && a[3, 0] == 0)
                                    {
                                        a[3, 0] = 2; flago12 = true; flago2 = true; flago3 = true;
                                    }
                                    else if (x - 1 == 4 && (y - 1 == 1 || y - 1 == 2) && a[4, 0] == 0)
                                    {
                                        a[4, 0] = 2; flago12 = true; flago2 = true; flago3 = true;
                                    }
                                    else if (x - 1 == 3 && (y - 1 == 5 || y - 1 == 6) && a[3, 7] == 0)
                                    {
                                        a[3, 7] = 2; flago12 = true; flago2 = true; flago3 = true;
                                    }
                                    else if (x - 1 == 4 && (y - 1 == 5 || y - 1 == 6) && a[4, 7] == 0)
                                    {
                                        a[4, 7] = 2; flago12 = true; flago2 = true; flago3 = true;
                                    }
                                    else if ((x - 1 == 5 || x - 1 == 6) && y - 1 == 3 && a[7, 3] == 0)
                                    {
                                        a[7, 3] = 2; flago12 = true; flago2 = true; flago3 = true;
                                    }
                                    else if ((x - 1 == 5 || x - 1 == 6) && y - 1 == 4 && a[7, 4] == 0)
                                    {
                                        a[7, 4] = 2; flago12 = true; flago2 = true; flago3 = true;
                                    }

                                }
                                flago13 = false;

                                if (a[3, 3] == 0 || a[3, 4] == 0 || a[4, 4] == 0 || a[4, 3] == 0) // AI Algorithm Plays The Center Of The Safe Area To Take First Edge Or Corner
                                {
                                    while (flago12 == false)
                                    {
                                        center = rnd.Next(1, 5);

                                        switch (center)
                                        {
                                            case 1:
                                                if (a[3, 3] == 0)
                                                {
                                                    a[3, 3] = 2;
                                                    flago12 = true; flago2 = true; flago3 = true;
                                                }
                                                break;

                                            case 2:
                                                if (a[3, 4] == 0)
                                                {
                                                    a[3, 4] = 2;
                                                    flago12 = true; flago2 = true; flago3 = true;
                                                }
                                                break;

                                            case 3:
                                                if (a[4, 3] == 0)
                                                {
                                                    a[4, 3] = 2;
                                                    flago12 = true; flago2 = true; flago3 = true;
                                                }
                                                break;

                                            case 4:
                                                if (a[4, 4] == 0)
                                                {
                                                    a[4, 4] = 2;
                                                    flago12 = true; flago2 = true; flago3 = true;
                                                }
                                                break;
                                        }
                                    }
                                }
                                flago12 = false;

                                if (flago2 == false) // AI Algorithm Controls The Array Except Corner Areas To Take A Position
                                {
                                    for (int k = 3; k <= 4; k++)
                                    {
                                        for (int l = 0; l <= 7; l++)
                                        {
                                            if (a[k, l] == 0)
                                            {
                                                flago2 = false;
                                                break;
                                            }
                                            else
                                                flago2 = true;
                                        }
                                        if (flago2 == false) { break; }
                                    }

                                    if (flago2 == true)
                                    {
                                        for (int k = 0; k <= 7; k++)
                                        {
                                            for (int l = 3; l <= 4; l++)
                                            {
                                                if (a[k, l] == 0)
                                                {
                                                    flago2 = false;
                                                    break;
                                                }
                                                else
                                                    flago2 = true;
                                            }
                                            if (flago2 == false) { break; }
                                        }
                                    }
                                }

                                while (flago2 == false) // AI Algorithm Plays Randomly Except Corner Areas To Not Loose The Corners
                                {
                                    x2 = rnd.Next(0, 8);
                                    y2 = rnd.Next(0, 8);

                                    if ((x2 == 3 || x2 == 4) && a[x2, y2] == 0)
                                    {
                                        for (int k = 0; k <= 7; k++)
                                        {
                                            for (int l = 0; l <= 7; l++)
                                            {
                                                if (a[k, l] != 0 && ((k - x2 == 2 && l - y2 == -1) || (k - x2 == 1 && l - y2 == 1) || (k - x2 == -1 && l - y2 == -1) || (k - x2 == -2 && l - y2 == -2) ||
                                                    (k - x2 == 2 && l - y2 == 0) || (k - x2 == 1 && l - y2 == 0) || (k - x2 == -2 && l - y2 == 0) || (k - x2 == -1 && l - y2 == 0) ||
                                                    (k - x2 == 0 && l - y2 == 1) || (k - x2 == 0 && l - y2 == 2) || (k - x2 == 0 && l - y2 == -1) || (k - x2 == 0 && l - y2 == -2)))
                                                {
                                                    a[x2, y2] = 2;
                                                    flago2 = true;
                                                    flago3 = true;
                                                    break;
                                                }
                                                else
                                                    flago2 = false;
                                            }
                                            if (flago2 == true) { break; } // to breaking out from the outter 'for'
                                        }
                                    }
                                    else if ((y2 == 3 || y2 == 4) && a[x2, y2] == 0)
                                    {
                                        for (int k = 0; k <= 7; k++)
                                        {
                                            for (int l = 0; l <= 7; l++)
                                            {
                                                if (a[k, l] != 0 && ((k - x2 == 2 && l - y2 == -1) || (k - x2 == 1 && l - y2 == 1) || (k - x2 == -1 && l - y2 == -1) || (k - x2 == -2 && l - y2 == -2) ||
                                                    (k - x2 == 2 && l - y2 == 0) || (k - x2 == 1 && l - y2 == 0) || (k - x2 == -2 && l - y2 == 0) || (k - x2 == -1 && l - y2 == 0) ||
                                                    (k - x2 == 0 && l - y2 == 1) || (k - x2 == 0 && l - y2 == 2) || (k - x2 == 0 && l - y2 == -1) || (k - x2 == 0 && l - y2 == -2)))
                                                {
                                                    a[x2, y2] = 2;
                                                    flago2 = true;
                                                    flago3 = true;
                                                    break;
                                                }
                                                else
                                                    flago2 = false;
                                            }
                                            if (flago2 == true) { break; }
                                        }
                                    }
                                    else
                                        flago2 = false;
                                }
                                flago2 = false;

                                while (flago3 == false) // AI Algorithm Plays Randomly 
                                {
                                    x2 = rnd.Next(0, 8);
                                    y2 = rnd.Next(0, 8);

                                    if (a[x2, y2] == 0)
                                    {
                                        a[x2, y2] = 2;
                                        flago3 = true;
                                    }
                                    else
                                        flago3 = false;

                                }

                                flago3 = false;

                                for (tri = x - 1; tri < 8; tri++)//Horizontal Scan and Conversion. Section 2 - Part 1
                                {
                                    for (trj = y - 1; trj < 8; trj++)
                                    {

                                        if (a[tri, trj] == 1)
                                        {
                                            for (tr2 = trj + 1; tr2 <= 7 && turn1 == true && turn2 == true; tr2++)
                                            {
                                                if (a[tri, tr2] == 2) { trcounter1++; }
                                                else if (a[tri, tr2] == 0) { turn1 = false; }
                                                else if (a[tri, tr2] == 1) { turn2 = false; }
                                            }
                                            if (trcounter1 > 0 && turn1 == true && turn2 == false)
                                            {
                                                for (int r = trcounter1; r > 0; r--)
                                                {
                                                    a[tri, trj + r] = 1;
                                                }

                                            }
                                        }

                                        else if (a[tri, trj] == 2)
                                        {
                                            for (tr2 = trj + 1; tr2 <= 7 && turn1 == true && turn2 == true; tr2++)
                                            {
                                                if (a[tri, tr2] == 1) { trcounter1++; }
                                                else if (a[tri, tr2] == 0) { turn1 = false; }
                                                else if (a[tri, tr2] == 2) { turn2 = false; }
                                            }
                                            if (trcounter1 > 0 && turn1 == true && turn2 == false)
                                            {
                                                for (int r = trcounter1; r > 0; r--)
                                                {
                                                    a[tri, trj + r] = 2;
                                                }

                                            }
                                        }
                                        trcounter1 = 0;
                                        turn1 = true;
                                        turn2 = true;
                                    }

                                }//Finish of the H scan. Part 1
                                trcounter1 = 0;
                                turn1 = true;
                                turn2 = true;

                                for (trj = y - 1; trj < 8; trj++)//Vertical Scan and Conversion. Section 2 - Part 1
                                {
                                    for (tri = x - 1; tri < 8; tri++)
                                    {

                                        if (a[tri, trj] == 1)//For the White
                                        {
                                            for (tr1 = tri + 1; tr1 <= 7 && turn1 == true && turn2 == true; tr1++)
                                            {
                                                if (a[tr1, trj] == 2) { trcounter1++; }
                                                else if (a[tr1, trj] == 0) { turn1 = false; }
                                                else if (a[tr1, trj] == 1) { turn2 = false; }
                                            }


                                            if (trcounter1 > 0 && turn1 == true && turn2 == false)
                                            {
                                                for (int r = trcounter1; r > 0; r--)
                                                {
                                                    a[tri + r, trj] = 1;
                                                }
                                                trcounter1 = 0;


                                            }

                                        }

                                        else if (a[tri, trj] == 2)//For the Black
                                        {
                                            for (tr1 = tri + 1; tr1 <= 7 && turn1 == true && turn2 == true; tr1++)
                                            {
                                                if (a[tr1, trj] == 1) { trcounter1++; }
                                                else if (a[tr1, trj] == 0) { turn1 = false; }
                                                else if (a[tr1, trj] == 2) { turn2 = false; }
                                            }

                                            if (trcounter1 > 0 && turn1 == true && turn2 == false)
                                            {
                                                for (int r = trcounter1; r > 0; r--)
                                                {
                                                    a[tri + r, trj] = 2;
                                                }
                                                trcounter1 = 0;
                                            }

                                        }
                                        trcounter1 = 0;

                                        turn1 = true;
                                        turn2 = true;
                                    }

                                }//Finish of the Vert. Scan. P1
                                trcounter1 = 0;
                                turn1 = true;
                                turn2 = true;

                                for (trj = y - 1; trj < 8; trj++)//Diagonally Scan and Conversion. Section 2 - Part 1
                                {
                                    for (tri = 0; tri < 8; tri++)
                                    {
                                        if (a[tri, trj] == 1)//For the Player
                                        {
                                            tr1 = tri + 1;
                                            tr2 = trj + 1;
                                            while ((tr1 <= 7 && tr2 <= 7) && turn3 == true && turn4 == true)
                                            {

                                                if (a[tr1, tr2] == 2) { trcounter2++; }
                                                else if (a[tr1, tr2] == 0) { turn3 = false; }
                                                else if (a[tr1, tr2] == 1) { turn4 = false; }

                                                tr1++;
                                                tr2++;

                                            }
                                            tr1 = tri - 1;
                                            tr2 = trj + 1;
                                            while ((tr1 >= 0 && tr2 <= 7) && turn5 == true && turn6 == true)
                                            {

                                                if (a[tr1, tr2] == 2) { trcounter3++; }
                                                else if (a[tr1, tr2] == 0) { turn5 = false; }
                                                else if (a[tr1, tr2] == 1) { turn6 = false; }

                                                tr1--;
                                                tr2++;

                                            }
                                            if (trcounter2 > 0 && turn3 == true && turn4 == false)
                                            {
                                                for (int r = trcounter2; r > 0; r--)
                                                {
                                                    a[tri + r, trj + r] = 1;


                                                }
                                                trcounter2 = 0;

                                            }
                                            if (trcounter3 > 0 && turn5 == true && turn6 == false)
                                            {
                                                for (int r = trcounter3; r > 0; r--)
                                                {
                                                    a[tri - r, trj + r] = 1;


                                                }
                                                trcounter3 = 0;

                                            }
                                        }
                                        else if (a[tri, trj] == 2)//For the AI
                                        {
                                            tr1 = tri + 1;
                                            tr2 = trj + 1;

                                            while ((tr1 <= 7 && tr2 <= 7) && turn3 == true && turn4 == true)
                                            {

                                                if (a[tr1, tr2] == 1) { trcounter2++; }
                                                else if (a[tr1, tr2] == 0) { turn3 = false; }
                                                else if (a[tr1, tr2] == 2) { turn4 = false; }

                                                tr1++;
                                                tr2++;

                                            }
                                            tr1 = tri - 1;
                                            tr2 = trj + 1;
                                            while ((tr1 >= 0 && tr2 <= 7) && turn5 == true && turn6 == true)
                                            {

                                                if (a[tr1, tr2] == 1) { trcounter3++; }
                                                else if (a[tr1, tr2] == 0) { turn5 = false; }
                                                else if (a[tr1, tr2] == 2) { turn6 = false; }

                                                tr1--;
                                                tr2++;

                                            }
                                            if (trcounter2 > 0 && turn3 == true && turn4 == false)
                                            {
                                                for (int r = trcounter2; r > 0; r--)
                                                {
                                                    a[tri + r, trj + r] = 2;
                                                }
                                                trcounter2 = 0;

                                            }
                                            if (trcounter3 > 0 && turn5 == true && turn6 == false)
                                            {
                                                for (int r = trcounter3; r > 0; r--)
                                                {
                                                    a[tri - r, trj + r] = 2;
                                                }
                                                trcounter3 = 0;
                                            }
                                        }
                                        trcounter2 = 0;
                                        trcounter3 = 0;
                                        turn3 = true;
                                        turn4 = true;
                                        turn5 = true;
                                        turn6 = true;
                                    }

                                }

                                for (tri = 0; tri <= x - 1; tri++)//Horizontal Scan and Conversion. Section 2 - Part 2
                                {
                                    for (trj = 0; trj <= y - 1; trj++)
                                    {

                                        if (a[tri, trj] == 1)
                                        {
                                            for (tr2 = trj + 1; tr2 <= 7 && turn1 == true && turn2 == true; tr2++)
                                            {
                                                if (a[tri, tr2] == 2) { trcounter1++; }
                                                else if (a[tri, tr2] == 0) { turn1 = false; }
                                                else if (a[tri, tr2] == 1) { turn2 = false; }
                                            }
                                            if (trcounter1 > 0 && turn1 == true && turn2 == false)
                                            {
                                                for (int r = trcounter1; r > 0; r--)
                                                {
                                                    a[tri, trj + r] = 1;
                                                }
                                                trcounter1 = 0;
                                            }
                                        }

                                        else if (a[tri, trj] == 2)
                                        {
                                            for (tr2 = trj + 1; tr2 <= 7 && turn1 == true && turn2 == true; tr2++)
                                            {
                                                if (a[tri, tr2] == 1) { trcounter1++; }
                                                else if (a[tri, tr2] == 0) { turn1 = false; }
                                                else if (a[tri, tr2] == 2) { turn2 = false; }
                                            }
                                            if (trcounter1 > 0 && turn1 == true && turn2 == false)
                                            {
                                                for (int r = trcounter1; r > 0; r--)
                                                {
                                                    a[tri, trj + r] = 2;
                                                }
                                                trcounter1 = 0;
                                            }
                                        }
                                        trcounter1 = 0;
                                        turn1 = true;
                                        turn2 = true;
                                    }

                                }//Finish of the H scan.P2
                                trcounter1 = 0;

                                turn1 = true;
                                turn2 = true;

                                for (trj = 0; trj <= y - 1; trj++)//Vertical Scan and Conversion. Section 2 - Part 2
                                {
                                    for (tri = 0; tri <= x - 1; tri++)
                                    {

                                        if (a[tri, trj] == 1)////For the Player
                                        {
                                            for (tr1 = tri + 1; tr1 <= 7 && turn1 == true && turn2 == true; tr1++)
                                            {
                                                if (a[tr1, trj] == 2) { trcounter1++; }
                                                else if (a[tr1, trj] == 0) { turn1 = false; }
                                                else if (a[tr1, trj] == 1) { turn2 = false; }
                                            }



                                            if (trcounter1 > 0 && turn1 == true && turn2 == false)
                                            {
                                                for (int r = trcounter1; r > 0; r--)
                                                {
                                                    a[tri + r, trj] = 1;
                                                }
                                                trcounter1 = 0;


                                            }

                                        }

                                        else if (a[tri, trj] == 2)//For the AI
                                        {
                                            for (tr1 = tri + 1; tr1 <= 7 && turn1 == true && turn2 == true; tr1++)
                                            {
                                                if (a[tr1, trj] == 1) { trcounter1++; }
                                                else if (a[tr1, trj] == 0) { turn1 = false; }
                                                else if (a[tr1, trj] == 2) { turn2 = false; }
                                            }

                                            if (trcounter1 > 0 && turn1 == true && turn2 == false)
                                            {
                                                for (int r = trcounter1; r > 0; r--)
                                                {
                                                    a[tri + r, trj] = 2;
                                                }
                                                trcounter1 = 0;
                                            }

                                        }
                                        trcounter1 = 0;

                                        turn1 = true;
                                        turn2 = true;

                                    }

                                } //Finish of the Vert. Scan. P2


                                for (trj = 0; trj <= y - 1; trj++)//Diagonally Scan and Conversion. Section 2 - Part 2
                                {
                                    for (tri = 0; tri < 8; tri++)
                                    {
                                        if (a[tri, trj] == 1)////For the Player
                                        {
                                            tr1 = tri + 1;
                                            tr2 = trj + 1;
                                            while ((tr1 <= 7 && tr2 <= 7) && turn3 == true && turn4 == true)
                                            {

                                                if (a[tr1, tr2] == 2) { trcounter2++; }
                                                else if (a[tr1, tr2] == 0) { turn3 = false; }
                                                else if (a[tr1, tr2] == 1) { turn4 = false; }

                                                tr1++;
                                                tr2++;

                                            }
                                            tr1 = tri - 1;
                                            tr2 = trj + 1;
                                            while ((tr1 >= 0 && tr2 <= 7) && turn5 == true && turn6 == true)
                                            {

                                                if (a[tr1, tr2] == 2) { trcounter3++; }
                                                else if (a[tr1, tr2] == 0) { turn5 = false; }
                                                else if (a[tr1, tr2] == 1) { turn6 = false; }

                                                tr1--;
                                                tr2++;

                                            }
                                            if (trcounter2 > 0 && turn3 == true && turn4 == false)
                                            {
                                                for (int r = trcounter2; r > 0; r--)
                                                {
                                                    a[tri + r, trj + r] = 1;


                                                }
                                                trcounter2 = 0;

                                            }
                                            if (trcounter3 > 0 && turn5 == true && turn6 == false)
                                            {
                                                for (int r = trcounter3; r > 0; r--)
                                                {
                                                    a[tri - r, trj + r] = 1;


                                                }
                                                trcounter3 = 0;

                                            }
                                        }
                                        else if (a[tri, trj] == 2)//For the AI
                                        {
                                            tr1 = tri + 1;
                                            tr2 = trj + 1;

                                            while ((tr1 <= 7 && tr2 <= 7) && turn3 == true && turn4 == true)
                                            {

                                                if (a[tr1, tr2] == 1) { trcounter2++; }
                                                else if (a[tr1, tr2] == 0) { turn3 = false; }
                                                else if (a[tr1, tr2] == 2) { turn4 = false; }

                                                tr1++;
                                                tr2++;

                                            }
                                            tr1 = tri - 1;
                                            tr2 = trj + 1;
                                            while ((tr1 >= 0 && tr2 <= 7) && turn5 == true && turn6 == true)
                                            {

                                                if (a[tr1, tr2] == 1) { trcounter3++; }
                                                else if (a[tr1, tr2] == 0) { turn5 = false; }
                                                else if (a[tr1, tr2] == 2) { turn6 = false; }

                                                tr1--;
                                                tr2++;

                                            }
                                            if (trcounter2 > 0 && turn3 == true && turn4 == false)
                                            {
                                                for (int r = trcounter2; r > 0; r--)
                                                {
                                                    a[tri + r, trj + r] = 2;
                                                }
                                                trcounter2 = 0;

                                            }
                                            if (trcounter3 > 0 && turn5 == true && turn6 == false)
                                            {
                                                for (int r = trcounter3; r > 0; r--)
                                                {
                                                    a[tri - r, trj + r] = 2;
                                                }
                                                trcounter3 = 0;
                                            }
                                        }
                                        trcounter2 = 0;
                                        trcounter3 = 0;
                                        turn3 = true;
                                        turn4 = true;
                                        turn5 = true;
                                        turn6 = true;
                                    }

                                }

                                trcounter1 = 0;

                                turn1 = true;
                                turn2 = true;
                                turn3 = true;
                                turn4 = true;
                                turn5 = true;
                                turn6 = true;
                                Console.ReadKey();
                                StoneCounterHuman = 0;
                                StoneCounterAI = 0;
                                for (int i = 0; i < a.GetLength(0); i++)
                                {
                                    for (int j = 0; j < a.GetLength(1); j++)
                                    {
                                        if (a[i, j] == 1) { StoneCounterHuman++; }
                                        if (a[i, j] == 2) { StoneCounterAI++; }
                                    }
                                }
                                RoundCounter++;
                                c++;

                            }
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Clear();
                            //Third Part
                            Console.WriteLine("   1 2 3 4 5 6 7 8  ");
                            Console.Write(" + - - - - - - - - +");
                            Console.WriteLine("Round   : " + RoundCounter);
                            Console.Write("1| ");

                            for (int i = 0; i < 1; i++)
                            {
                                for (int j = 0; j < a.GetLength(1); j++)
                                {
                                    if (a[i, j] == 0) { Console.Write(". "); }
                                    else if (a[i, j] == 1) { Console.Write("o "); }
                                    else if (a[i, j] == 2) { Console.Write("x "); }
                                }
                                Console.Write("|");
                            }
                            Console.WriteLine("Human   : " + StoneCounterHuman);

                            Console.Write("2| ");

                            for (int i = 1; i < 2; i++)
                            {
                                for (int j = 0; j < a.GetLength(1); j++)
                                {
                                    if (a[i, j] == 0) { Console.Write(". "); }
                                    else if (a[i, j] == 1) { Console.Write("o "); }
                                    else if (a[i, j] == 2) { Console.Write("x "); }
                                }
                                Console.Write("|");
                            }
                            Console.WriteLine("Computer: " + StoneCounterAI);
                            Console.Write("3| ");

                            for (int i = 2; i < 3; i++)
                            {
                                for (int j = 0; j < 2; j++)
                                {
                                    if (a[i, j] == 0) { Console.Write(". "); }
                                    else if (a[i, j] == 1) { Console.Write("o "); }
                                    else if (a[i, j] == 2) { Console.Write("x "); }
                                }

                            }

                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            for (int i = 2; i < 3; i++)
                            {
                                for (int j = 2; j < 5; j++)
                                {
                                    if (a[i, j] == 0) { Console.Write(". "); }
                                    else if (a[i, j] == 1) { Console.Write("o "); }
                                    else if (a[i, j] == 2) { Console.Write("x "); }
                                }

                            }
                            for (int i = 2; i < 3; i++)
                            {
                                for (int j = 5; j < 6; j++)
                                {
                                    if (a[i, j] == 0) { Console.Write("."); }
                                    else if (a[i, j] == 1) { Console.Write("o"); }
                                    else if (a[i, j] == 2) { Console.Write("x"); }
                                }

                            }
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write(" ");
                            for (int i = 2; i < 3; i++)
                            {
                                for (int j = 6; j < 8; j++)
                                {
                                    if (a[i, j] == 0) { Console.Write(". "); }
                                    else if (a[i, j] == 1) { Console.Write("o "); }
                                    else if (a[i, j] == 2) { Console.Write("x "); }
                                }

                            }
                            Console.WriteLine("|");
                            Console.Write("4| ");
                            for (int i = 3; i < 4; i++)
                            {
                                for (int j = 0; j < 2; j++)
                                {
                                    if (a[i, j] == 0) { Console.Write(". "); }
                                    else if (a[i, j] == 1) { Console.Write("o "); }
                                    else if (a[i, j] == 2) { Console.Write("x "); }
                                }

                            }
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            for (int i = 3; i < 4; i++)
                            {
                                for (int j = 2; j < 5; j++)
                                {
                                    if (a[i, j] == 0) { Console.Write(". "); }
                                    else if (a[i, j] == 1) { Console.Write("o "); }
                                    else if (a[i, j] == 2) { Console.Write("x "); }
                                }

                            }
                            for (int i = 3; i < 4; i++)
                            {
                                for (int j = 5; j < 6; j++)
                                {
                                    if (a[i, j] == 0) { Console.Write("."); }
                                    else if (a[i, j] == 1) { Console.Write("o"); }
                                    else if (a[i, j] == 2) { Console.Write("x"); }
                                }

                            }
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write(" ");
                            for (int i = 3; i < 4; i++)
                            {
                                for (int j = 6; j < 8; j++)
                                {
                                    if (a[i, j] == 0) { Console.Write(". "); }
                                    else if (a[i, j] == 1) { Console.Write("o "); }
                                    else if (a[i, j] == 2) { Console.Write("x "); }
                                }

                            }
                            Console.WriteLine("|");
                            Console.Write("5| ");
                            for (int i = 4; i < 5; i++)
                            {
                                for (int j = 0; j < 2; j++)
                                {
                                    if (a[i, j] == 0) { Console.Write(". "); }
                                    else if (a[i, j] == 1) { Console.Write("o "); }
                                    else if (a[i, j] == 2) { Console.Write("x "); }
                                }

                            }
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            for (int i = 4; i < 5; i++)
                            {
                                for (int j = 2; j < 5; j++)
                                {
                                    if (a[i, j] == 0) { Console.Write(". "); }
                                    else if (a[i, j] == 1) { Console.Write("o "); }
                                    else if (a[i, j] == 2) { Console.Write("x "); }
                                }

                            }
                            for (int i = 4; i < 5; i++)
                            {
                                for (int j = 5; j < 6; j++)
                                {
                                    if (a[i, j] == 0) { Console.Write("."); }
                                    else if (a[i, j] == 1) { Console.Write("o"); }
                                    else if (a[i, j] == 2) { Console.Write("x"); }
                                }

                            }
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write(" ");
                            for (int i = 4; i < 5; i++)
                            {
                                for (int j = 6; j < 8; j++)
                                {
                                    if (a[i, j] == 0) { Console.Write(". "); }
                                    else if (a[i, j] == 1) { Console.Write("o "); }
                                    else if (a[i, j] == 2) { Console.Write("x "); }
                                }

                            }

                            Console.WriteLine("|");
                            Console.Write("6| ");
                            for (int i = 5; i < 6; i++)
                            {
                                for (int j = 0; j < 2; j++)
                                {
                                    if (a[i, j] == 0) { Console.Write(". "); }
                                    else if (a[i, j] == 1) { Console.Write("o "); }
                                    else if (a[i, j] == 2) { Console.Write("x "); }
                                }

                            }
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            for (int i = 5; i < 6; i++)
                            {
                                for (int j = 2; j < 5; j++)
                                {
                                    if (a[i, j] == 0) { Console.Write(". "); }
                                    else if (a[i, j] == 1) { Console.Write("o "); }
                                    else if (a[i, j] == 2) { Console.Write("x "); }
                                }

                            }
                            for (int i = 5; i < 6; i++)
                            {
                                for (int j = 5; j < 6; j++)
                                {
                                    if (a[i, j] == 0) { Console.Write("."); }
                                    else if (a[i, j] == 1) { Console.Write("o"); }
                                    else if (a[i, j] == 2) { Console.Write("x"); }
                                }

                            }
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write(" ");
                            for (int i = 5; i < 6; i++)
                            {
                                for (int j = 6; j < 8; j++)
                                {
                                    if (a[i, j] == 0) { Console.Write(". "); }
                                    else if (a[i, j] == 1) { Console.Write("o "); }
                                    else if (a[i, j] == 2) { Console.Write("x "); }
                                }

                            }
                            Console.WriteLine("|");
                            Console.Write("7| ");
                            for (int i = 6; i < 7; i++)
                            {
                                for (int j = 0; j < a.GetLength(1); j++)
                                {
                                    if (a[i, j] == 0) { Console.Write(". "); }
                                    else if (a[i, j] == 1) { Console.Write("o "); }
                                    else if (a[i, j] == 2) { Console.Write("x "); }
                                }
                                Console.WriteLine("|");
                            }

                            Console.Write("8| ");

                            for (int i = 7; i < 8; i++)
                            {
                                for (int j = 0; j < a.GetLength(1); j++)
                                {
                                    if (a[i, j] == 0) { Console.Write(". "); }
                                    else if (a[i, j] == 1) { Console.Write("o "); }
                                    else if (a[i, j] == 2) { Console.Write("x "); }
                                }
                                Console.WriteLine("|");
                            }
                            Console.WriteLine(" + - - - - - - - - +");
                            Console.WriteLine();

                            if (StoneCounterHuman > StoneCounterAI)
                                Console.WriteLine("Winner is player");
                            else if (StoneCounterAI > StoneCounterHuman)
                                Console.WriteLine("Winner is computer");
                            else if (StoneCounterAI == StoneCounterHuman)
                                Console.WriteLine("Tie!");

                            Console.ReadLine();
                        } break;

                    case 3://For the Exit
                        return;
                    default:

                        Console.Clear();
                        Console.WriteLine("Wrong entry!");
                        Console.WriteLine("Returning to Menu...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
