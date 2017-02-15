using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Clear();


            int G = 1, Gs = 1, CS = 0, PS = 0, G2 = 0, R = 1, l = 0;
            Console.WriteLine("WELCOME TO THE MİNİ.MASTER.MİND");
            Console.WriteLine("");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();
            Console.Clear();


            while (R < 11)//MAJOR LOOP
            {
                while (G2 < 1)//1.Middle Loop
                {
                    int x1, y1, a, b, t = 0, k = 0, sayi;

                    Console.WriteLine("Round: " + R);
                    Console.WriteLine("Game: " + G);
                    Console.WriteLine("Computer Score: " + CS);
                    Console.WriteLine("Player Score: " + PS);
                    Console.WriteLine("");
                    Console.WriteLine(@"(****/\/\./\/\./\/\****)");
                    Console.WriteLine("");
                    Random rnd = new Random();
                    x1 = rnd.Next(1, 4);
                    y1 = rnd.Next(1, 4);

                    while (t < 1)
                    {
                        if (x1 == y1)
                        {
                            y1 = rnd.Next(1, 4);
                        }
                        else { t = 1; }
                    }


                    while (k < 1)
                    {
                        Console.Write("Please enter a 2 digit number: ");
                        sayi = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("");
                        b = sayi % 10;
                        a = sayi / 10;

                        while (l < 1)
                        {
                            if (!((a == 1 || a == 2 || a == 3) && (b == 1 || b == 2 || b == 3))||((a==1 && b==1) || (a==2 && b==2) || ( a==3 && b==3)))
                            {
                                Console.WriteLine("Wrong Entry!!");
                                Console.WriteLine("");
                                Console.Write("Please enter a 2 digit number: ");
                                sayi = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("");
                                b = sayi % 10;
                                a = sayi / 10;
                            }
                            else { l = 1; }
                        }
                        l = 0;


                        if ((a == x1) && b == y1)
                        {
                            Console.WriteLine("--------------------");
                            Console.WriteLine("Your Guess" + "(" + Gs + "): " + a + b);
                            Console.WriteLine("My Feedback: +2 -0");
                            Console.WriteLine("--------------------");
                            Console.WriteLine("");
                            k = 1;

                            Console.WriteLine("YOU WİN");

                        }
                        else
                        {
                            if (((a != x1) && (b == y1)) || ((a == x1) && (b != y1)))
                            {
                                Console.WriteLine("--------------------");
                                Console.WriteLine("Your Guess" + "(" + Gs + "): " + a + b);
                                Console.WriteLine("My Feedback: +1 -0");
                                Console.WriteLine("--------------------");
                                Console.WriteLine("");
                            }
                            else if (((a != y1) && (b == x1)) || ((a == y1) && (b != x1)))
                            {
                                Console.WriteLine("--------------------");
                                Console.WriteLine("Your Guess" + "(" + Gs + "): " + a + b);
                                Console.WriteLine("My feedback: +0 -1");
                                Console.WriteLine("--------------------");
                                Console.WriteLine("");
                            }
                            else if ((a == y1) && (b == x1))
                            {
                                Console.WriteLine("--------------------");
                                Console.WriteLine("Your Guess" + "(" + Gs + "): " + a + b);
                                Console.WriteLine("My Feedback: +0 -2");
                                Console.WriteLine("--------------------");
                                Console.WriteLine("");
                            }

                            Gs = Gs + 1;

                        }
                    }
                    G = G + 1;
                    CS = CS + Gs;
                    G2 = 1;


                    Console.ReadKey();

                }//Closure of 1.Middle Loop
                while (G2 < 2)//2.Middle Loop 
                {
                    int x1, x2, y1, y2 = 0, a, b, m, k, t = 0,s=0;
                    Gs = 1;
                    Console.Clear();



                    Random rnd = new Random();
                    x1 = rnd.Next(1, 4);

                    y1 = rnd.Next(1, 4);

                    while (t < 1)
                    {
                        if (x1 == y1)
                        {
                            y1 = rnd.Next(1, 4);
                        }
                        else { t = 1; }
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Round: " + R);
                    Console.WriteLine("Game: " + G);
                    Console.WriteLine("Computer Score: " + CS);
                    Console.WriteLine("Player Score: " + PS);
                    Console.WriteLine("");
                    Console.WriteLine(@"(****/\/\./\/\./\/\****)");
                    Console.WriteLine("");

                    Console.WriteLine("My Guess: " + "(" + Gs + "):" + x1 + y1);
                    Console.WriteLine("--------------------");
                    t = 0;
                    k = x1;
                    m = y1;

                    for (; Gs <= 3; )//The Minor Loop
                    {
                        Console.WriteLine("Please enter your feedback: ");
                        Console.Write("+");
                        a = Convert.ToInt32(Console.ReadLine());
                        Console.Write("-");
                        b = Convert.ToInt32(Console.ReadLine());

                        while (l < 1)//If Human enter wrong entry
                        {
                            if (!((a == 1 || a == 2 || a == 0) && (b == 1 || b == 2 || b == 0)) || ((a==0 && b==0)||(a==1&&b==1)||((a==2)&&(b==2))))
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Wrong Entry!!");
                                Console.WriteLine("");
                                Console.WriteLine("Please enter your right feedback: ");
                                Console.Write("+");
                                a = Convert.ToInt32(Console.ReadLine());
                                Console.Write("-");
                                b = Convert.ToInt32(Console.ReadLine());


                            }
                            else { l = 1; }
                        }
                        l = 0;
                        if (s == 1)//İf loop comes here for the 2.times it will consider below;
                        {
                            while (l < 1)//If human makes cheating
                            {

                                if ((a == 0 && b == 2) || (a == 1 && b == 0))
                                {
                                    Console.WriteLine("You are cheating");
                                    Console.WriteLine("Please correct your mistake!");
                                    Console.Write("+");
                                    a = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("-");
                                    b = Convert.ToInt32(Console.ReadLine());

                                    while (l < 1)//If Human enter wrong entry while s/he is correcting cheat
                                    {
                                        if (!((a == 1 || a == 2 || a == 0) && (b == 1 || b == 2 || b == 0)) || ((a == 0 && b == 0) || (a == 1 && b == 1) || ((a == 2) && (b == 2))))
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("Wrong Entry!!");
                                            Console.WriteLine("");
                                            Console.WriteLine("Please enter your right feedback: ");
                                            Console.Write("+");
                                            a = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("-");
                                            b = Convert.ToInt32(Console.ReadLine());


                                        }
                                        else { l = 1; }
                                    }
                                    l = 0;
                                }
                                else { l = 1; }
                            }
                        }
                        else if (s == 2)//İf loop comes here for the 3.times it will consider below;
                        {
                            while (l < 1)//If human makes cheating
                            {

                                if ((a == 0 && b == 2) || (a == 1 && b == 0) || (a==0 && b==1))
                                {
                                    Console.WriteLine("You are cheating");
                                    Console.WriteLine("Please correct your mistake!");
                                    Console.Write("+");
                                    a = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("-");
                                    b = Convert.ToInt32(Console.ReadLine());

                                    while (l < 1)//If Human enter wrong entry while s/he is correcting cheat
                                    {
                                        if (!((a == 1 || a == 2 || a == 0) && (b == 1 || b == 2 || b == 0)) || ((a == 0 && b == 0) || (a == 1 && b == 1) || ((a == 2) && (b == 2))))
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("Wrong Entry!!");
                                            Console.WriteLine("");
                                            Console.WriteLine("Please enter your right feedback: ");
                                            Console.Write("+");
                                            a = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("-");
                                            b = Convert.ToInt32(Console.ReadLine());


                                        }
                                        else { l = 1; }
                                    }
                                    l = 0;
                                }
                                else { l = 1; }
                            }
                        }

                        if (a == 2 && b == 0)//1.possibility
                        {
                            Console.WriteLine("");
                            Console.WriteLine("I WIN");



                            PS = PS + Gs;
                            break;

                        }

                        else if (a == 1 && b == 0)//2.Possibility
                        {

                            x2 = rnd.Next(1, 4);

                            while (t < 1)
                            {
                                if ((x2 == y1 || x2 == x1)) { x2 = rnd.Next(1, 4); }
                                else { t = 1; }
                            }
                            t = 0;
                            x1 = x2;
                            Gs = Gs + 1;
                            Console.WriteLine("");
                            Console.WriteLine("--------------------");
                            Console.WriteLine("My Guess: " + "(" + Gs + "):" + x1 + y1);
                            Console.WriteLine("--------------------");
                            Console.WriteLine("Please enter your feedback:");
                            Console.Write("+");
                            a = Convert.ToInt32(Console.ReadLine());
                            Console.Write("-");
                            b = Convert.ToInt32(Console.ReadLine());

                            while (l < 1)//If Human enter wrong entry
                            {
                                if (!((a == 1 || a == 2 || a == 0) && (b == 1 || b == 2 || b == 0)) || ((a == 0 && b == 0) || (a == 1 && b == 1) || ((a == 2) && (b == 2))))
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("Wrong Entry!!");
                                    Console.WriteLine("");
                                    Console.WriteLine("Please enter your right feedback: ");
                                    Console.Write("+");
                                    a = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("-");
                                    b = Convert.ToInt32(Console.ReadLine());


                                }
                                else { l = 1; }
                            }
                            l = 0;
                            while (l < 1)//If human makes cheating
                            {

                                if ((a == 0 && b == 2) || (a == 1 && b == 0))
                                {
                                    Console.WriteLine("You are cheating");
                                    Console.WriteLine("Please correct your mistake!");
                                    Console.Write("+");
                                    a = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("-");
                                    b = Convert.ToInt32(Console.ReadLine());

                                    while (l < 1)//If Human enter wrong entry while s/he is correcting cheat
                                    {
                                        if (!((a == 1 || a == 2 || a == 0) && (b == 1 || b == 2 || b == 0)) || ((a == 0 && b == 0) || (a == 1 && b == 1) || ((a == 2) && (b == 2))))
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("Wrong Entry!!");
                                            Console.WriteLine("");
                                            Console.WriteLine("Please enter your right feedback: ");
                                            Console.Write("+");
                                            a = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("-");
                                            b = Convert.ToInt32(Console.ReadLine());


                                        }
                                        else { l = 1; }
                                    }
                                    l = 0;
                                }
                                else { l = 1; }
                            }


                            if (a == 0 && b == 1)//1.possibility of 2.possibility
                            {
                                x1 = k;
                                y2 = rnd.Next(1, 4);

                                while (t < 1)
                                {
                                    if (y2 == y1 || y2 == x1) { y2 = rnd.Next(1, 4); }
                                    else { t = 1; }
                                }
                                t = 0;
                                y1 = y2;
                                Gs = Gs + 1;
                                Console.WriteLine("");
                                Console.WriteLine("--------------------");
                                Console.WriteLine("My Guess: " + "(" + Gs + "):" + x1 + y1);
                                Console.WriteLine("--------------------");
                                Console.WriteLine("Please enter your feedback:");
                                Console.Write("+");
                                a = Convert.ToInt32(Console.ReadLine());
                                Console.Write("-");
                                b = Convert.ToInt32(Console.ReadLine());

                                while (l < 1)//If Human enter wrong entry
                                {
                                    if (!((a == 1 || a == 2 || a == 0) && (b == 1 || b == 2 || b == 0)) || ((a == 0 && b == 0) || (a == 1 && b == 1) || ((a == 2) && (b == 2))))
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Wrong Entry!!");
                                        Console.WriteLine("");
                                        Console.WriteLine("Please enter your right feedback: ");
                                        Console.Write("+");
                                        a = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("-");
                                        b = Convert.ToInt32(Console.ReadLine());


                                    }
                                    else { l = 1; }
                                }
                                l = 0;
                                while (l < 1)//If human makes cheats
                                {

                                    if ((a == 0 && b == 2) || (a == 1 && b == 0) || (a == 0 && b == 1))
                                    {
                                        Console.WriteLine("You are cheating");
                                        Console.WriteLine("Please correct your mistake!");
                                        Console.Write("+");
                                        a = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("-");
                                        b = Convert.ToInt32(Console.ReadLine());

                                        while (l < 1)//If Human enter wrong entry while s/he is correcting cheat
                                        {
                                            if (!((a == 1 || a == 2 || a == 0) && (b == 1 || b == 2 || b == 0)) || ((a == 0 && b == 0) || (a == 1 && b == 1) || ((a == 2) && (b == 2))))
                                            {
                                                Console.WriteLine("");
                                                Console.WriteLine("Wrong Entry!!");
                                                Console.WriteLine("");
                                                Console.WriteLine("Please enter your right feedback: ");
                                                Console.Write("+");
                                                a = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("-");
                                                b = Convert.ToInt32(Console.ReadLine());


                                            }
                                            else { l = 1; }
                                        }
                                        l = 0;
                                    }
                                    else { l = 1; }
                                }

                                Console.WriteLine("");
                                Console.WriteLine("I WIN");

                                PS = PS + Gs;
                                break;
                            }

                            else//2.Possibility of 2. Possibility
                            {
                                Console.WriteLine("");
                                Console.WriteLine("I WIN");

                                PS = PS + Gs;
                                break;
                            }
                        }

                        else//Contains 3. and 4. Possibilities
                        {

                            if (a == 0 && b == 1)//3.Possibility
                            {
                                if (Gs < 3)
                                {
                                    if (Gs < 2)//1.Possibility of 3. Possilibity
                                    {

                                        x1 = y1;

                                        y2 = rnd.Next(1, 4);
                                        while (t < 1)
                                        {
                                            if (y2 == k || y2 == m)
                                            {
                                                y2 = rnd.Next(1, 4);
                                            }
                                            else { t = 1; }
                                        }
                                        t = 0;
                                        y1 = y2;
                                    }
                                    else if (a == 0 || b == 1)//2.Possibility of 3. Possibility
                                    {
                                        x1 = y2;
                                        y1 = k;

                                    }
                                }
                                
                            }


                            else if (a == 0 && b == 2)//4.Possibility
                            {
                                x1 = m;
                                y1 = k;


                            }
                            Gs = Gs + 1;
                            Console.WriteLine("");
                            Console.WriteLine("--------------------");
                            Console.WriteLine("My Guess: " + "(" + Gs + "):" + x1 + y1);
                            Console.WriteLine("--------------------");
                            s = s+1;
                        }

                    }//End of The Minor Loop

                    G = 1;
                    G2 = G2 + 1;
                    Console.ReadKey();
                    Console.Clear();
                }//End of The 2.Middle Loop
                R = R + 1;
                G2 = 0;
            }//END OF THE MAJOR LOOP
            Console.WriteLine("And The Winner is....");
            if (PS > CS)
            {
                Console.WriteLine(+PS + "-" + CS);
                Console.WriteLine("PLAYER");
                Console.WriteLine("CONGRATULATİONS!");
            }
            else if (CS > PS)
            {
                Console.WriteLine(+CS + "-" + PS);
                Console.WriteLine("AI");
                Console.WriteLine("GAME OVER!");

            }
            Console.ReadKey();

        }
    }
}
