using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjeScrb
{
    class Scrb
    {//Warning Res_Array[].Res_point should be the Res_Array[].Res_array and
        //Res_Array[].Res_array should be the Res_Array[].Res_point
        //There are unnecessary variables.
        static char[,] tbl = new char[15, 15];
        static string[] Scanned_words = new string[300];

        static ConsoleKeyInfo direction = new ConsoleKeyInfo();
        static bool flag = true;
        static int[] letters = new int[7];//For Player1
        static int[] letters2 = new int[7];//For Player2
        static char[] Returns = new char[7];
        static string[] Query_List = new string[10];
        static string[] Array_Query = new string[15];
        static int Round = 1;//Round
        static Reservoir[] Res_Array = new Reservoir[26];
        static Random rnd = new Random();
        static string answer;
        static bool frodo = true;

        static bool[] LetterFlag = new bool[7];
        static bool word_check = true;
        static bool letter_check = false;
        static bool horizontal_check;
        static bool vertical_check;
        static int score2 = 0;
        static int score3 = 0;
        static int a;//Array iz düşümü
        static int b;//Array iz düşümü
        static int x = 10;
        static int y = 16;
        static string new_word = "";
        static string Query_letter;
        static string Query_word = "";
        static int counter_word = 0;
        static int score = 0;
        static int Counter_ForScanned = 0;
        static int Query_counter = 0;

        static int Pass_Counter1 = 2;//For the Player1
        static int Pass_Counter2 = 2;//For the Player2

        static bool Flag_Pass1 = false;//For the Player1
        static bool Flag_Pass2 = false;//For the Player2

        static int[] Re_New = null;
        static public string[] dict = new string[33013];
        static int Counter_Key = 0;
        static int Counter_Query_3 = 0;
        static int score_player1 = 0;
        static int score_player2 = 0;
        struct Reservoir
        {
            public char Res_letter;
            public int Res_point;
            public int Res_number;
        }
        static void Main(string[] args)
        {
            Folder();
            Bag();
            
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
                
            while (flag == true)
            {

                Table_Numbers();
                Choice_Key();

                if (Pass_Counter1 == 0 && Pass_Counter2 == 0)
                {
                    Console.Clear();
                    Table_Numbers();
                    Console.SetCursorPosition(0, 20);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("GAME OVER!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    break;

                }

                while (frodo == true)//For the write words
                {
                    Console.Clear();
                    Table_Numbers();

                    Key();


                }
                Counter_Query_3 = 0;
                frodo = true;
                letter_check = false;
                Round++;
                score = 0;
                new_word = "";
                counter_word = 0;

                Console.Clear();
            }

            Console.ReadKey();
        }
        #region cizdirme
        static void Table_Numbers()
        {
            Console.Write("Letter points:   ");
            for (int i = 0; i < Res_Array.Length / 2; i++)
            {
                Console.Write(Res_Array[i].Res_letter + ":");
                Console.Write(Res_Array[i].Res_number + "  ");
            }
            Console.WriteLine();
            Console.Write("                 ");
            for (int i = Res_Array.Length / 2; i < Res_Array.Length; i++)
            {
                Console.Write(Res_Array[i].Res_letter + ":");
                Console.Write(Res_Array[i].Res_number + "  ");
            }
            Console.WriteLine();
            Table();
        }
        static void Table()
        {

            Console.WriteLine("+ - - - - - - - - - - - - - - - +");

            for (int i = 0; i < tbl.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < tbl.GetLength(1); j++)
                {
                    if (tbl[i, j] == '\0')
                    {
                        Console.Write(" .");
                    }
                    else
                    {

                        Console.Write(" " + tbl[i, j]);

                    }

                }
                Console.Write(" |");
                Console.WriteLine();
            }
            Console.WriteLine("+ - - - - - - - - - - - - - - - +");

            Table_RRQ();
        }
        static void Table_RRQ()
        {
            string Player;
            Console.SetCursorPosition(35, 3);
            if (Round % 2 == 0) { Player = "(Player 2)"; }
            else { Player = "(Player 1)"; }
            Console.Write("Round   : " + Round + "  " + Player);
            Console.SetCursorPosition(35, 5);
            Console.Write("Returns: ");
            for (int i = 0; i < Returns.Length; i++)
            {
                if (Returns[i] == '\0') { Console.Write("_" + " "); }
                else { Console.Write(Returns[i] + " "); }
            }
            Console.SetCursorPosition(35, 7);
            Console.Write("Query  : ");
            for (int i = 0; i < Array_Query.Length; i++)
            {
                if (Array_Query[i] == null) { Console.Write("_" + " "); }
                else { Console.Write(Array_Query[i] + " "); }
            }
            Console.SetCursorPosition(78, 7);
            Console.Write("Score: " + score_player1);

            Console.SetCursorPosition(78, 12);
            Console.Write("Score: " + score_player2);
            Table_Bag();
        }
        static void Table_Bag()
        {
            Console.SetCursorPosition(78, 3);
            Console.Write("Player 1:");
            Console.SetCursorPosition(78, 5);
            Console.Write("Bag :");

            Console.Write(Res_Array[letters[0]].Res_letter + " ");
            Console.Write(Res_Array[letters[1]].Res_letter + " ");
            Console.Write(Res_Array[letters[2]].Res_letter + " ");
            Console.Write(Res_Array[letters[3]].Res_letter + " ");
            Console.Write(Res_Array[letters[4]].Res_letter + " ");
            Console.Write(Res_Array[letters[5]].Res_letter + " ");
            Console.Write(Res_Array[letters[6]].Res_letter + " ");

            Console.SetCursorPosition(78, 8);
            Console.Write("Player 2:");
            Console.SetCursorPosition(78, 10);
            Console.Write("Bag :");

            Console.Write(Res_Array[letters2[0]].Res_letter + " ");
            Console.Write(Res_Array[letters2[1]].Res_letter + " ");
            Console.Write(Res_Array[letters2[2]].Res_letter + " ");
            Console.Write(Res_Array[letters2[3]].Res_letter + " ");
            Console.Write(Res_Array[letters2[4]].Res_letter + " ");
            Console.Write(Res_Array[letters2[5]].Res_letter + " ");
            Console.Write(Res_Array[letters2[6]].Res_letter + " ");
            Table_Querry_List();
        }
        static void Table_Querry_List()
        {
            int row = 9;
            
         
                for (int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(35, row);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(Query_List[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                    row++;
                }

                Query_List = new string[10];

                Table_Pass();
            
            
        }//Query 3.Step
        static void Table_Pass()
        {
            Console.SetCursorPosition(78, 15);
            Console.Write("Player 1-Left Pass: " + Pass_Counter1);
            Console.SetCursorPosition(78, 16);
            Console.Write("Player 2-Left Pass: " + Pass_Counter2);
            Table_Reservour_Number();
        }
        static void Table_Reservour_Number()
        {
            Console.SetCursorPosition(0, 25);
            Console.Write("Letter numbers:  ");
            for (int i = 0; i < Res_Array.Length / 2; i++)
            {
                Console.Write(Res_Array[i].Res_letter + ":");
                Console.Write(Res_Array[i].Res_point + "  ");
            }
            Console.WriteLine();
            Console.Write("                 ");
            for (int i = Res_Array.Length / 2; i < Res_Array.Length; i++)
            {
                Console.Write(Res_Array[i].Res_letter + ":");
                Console.Write(Res_Array[i].Res_point + "  ");
            }
            Console.WriteLine();


        }
        #endregion

        #region Query
        static void Input_Query()
        {
            bool flag_query = true;
            x = 7;
            y = 44;
            Query_word = "";
            while (flag_query == true)
            {
                direction = Console.ReadKey(true);

                if ((y + 2) < 73 && direction.Key == ConsoleKey.RightArrow)
                {

                    y = y + 2;

                    Console.SetCursorPosition(y, x);
                }
                else if ((y - 2) > 43 && direction.Key == ConsoleKey.LeftArrow)
                {

                    y = y - 2;

                    Console.SetCursorPosition(y, x);
                }
                else if (direction.Key == ConsoleKey.Tab)
                {
                    Query_counter = 0;
                    flag_query = false;
                    for (int i = 0; i < Array_Query.Length; i++)
                    {
                        if (Array_Query[i] != null)
                        {
                            Query_word = Query_word.Insert(Query_counter, Convert.ToString(Array_Query[i])).ToUpper();
                            Query_counter++;
                        }
                        if (i < 13)
                        {
                            if (Query_counter > 0 && Array_Query[i + 1] == null && Array_Query[i + 2] != null)
                            {

                                Console.WriteLine("Wrong Entry.");
                                Query_word = "";
                                Query_counter = 0;
                                break;
                            }

                        }

                    }
                    Query();
                    if (Query_List[0] == null)
                    {
                        Console.SetCursorPosition(0, 22);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Found Nothing..");
                        
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                        Console.Clear();
                        Table_Numbers();
                    }
                    else { Table_Querry_List(); }
                }
                #region Harf Alma
                else if (x == 7 && y == 44)
                {
                    Array_Query[0] = Convert.ToString(direction.KeyChar);
                    Table_RRQ();
                    y += 2;
                    Console.SetCursorPosition(y, x);
                }
                else if (x == 7 && y == 46)
                {
                    Array_Query[1] = Convert.ToString(direction.KeyChar);
                    Table_RRQ();
                    y += 2;
                    Console.SetCursorPosition(y, x);
                }
                else if (x == 7 && y == 48)
                {
                    Array_Query[2] = Convert.ToString(direction.KeyChar);
                    Table_RRQ();
                    y += 2;
                    Console.SetCursorPosition(y, x);
                }
                else if (x == 7 && y == 50)
                {
                    Array_Query[3] = Convert.ToString(direction.KeyChar);
                    Table_RRQ();
                    y += 2;
                    Console.SetCursorPosition(y, x);
                }
                else if (x == 7 && y == 52)
                {
                    Array_Query[4] = Convert.ToString(direction.KeyChar);
                    Table_RRQ();
                    y += 2;
                    Console.SetCursorPosition(y, x);
                }
                else if (x == 7 && y == 54)
                {
                    Array_Query[5] = Convert.ToString(direction.KeyChar);
                    Table_RRQ();
                    y += 2;
                    Console.SetCursorPosition(y, x);
                }
                else if (x == 7 && y == 56)
                {
                    Array_Query[6] = Convert.ToString(direction.KeyChar);
                    Table_RRQ();
                    y += 2;
                    Console.SetCursorPosition(y, x);
                }
                else if (x == 7 && y == 58)
                {
                    Array_Query[7] = Convert.ToString(direction.KeyChar);
                    Table_RRQ();
                    y += 2;
                    Console.SetCursorPosition(y, x);
                }
                else if (x == 7 && y == 60)
                {
                    Array_Query[8] = Convert.ToString(direction.KeyChar);
                    Table_RRQ();
                    y += 2;
                    Console.SetCursorPosition(y, x);
                }
                else if (x == 7 && y == 62)
                {
                    Array_Query[9] = Convert.ToString(direction.KeyChar);
                    Table_RRQ();
                    y += 2;
                    Console.SetCursorPosition(y, x);
                }
                else if (x == 7 && y == 64)
                {
                    Array_Query[10] = Convert.ToString(direction.KeyChar);
                    Table_RRQ();
                    y += 2;
                    Console.SetCursorPosition(y, x);
                }
                else if (x == 7 && y == 66)
                {
                    Array_Query[11] = Convert.ToString(direction.KeyChar);
                    Table_RRQ();
                    y += 2;
                    Console.SetCursorPosition(y, x);
                }
                else if (x == 7 && y == 68)
                {
                    Array_Query[12] = Convert.ToString(direction.KeyChar);
                    Table_RRQ();
                    y += 2;
                    Console.SetCursorPosition(y, x);
                }
                else if (x == 7 && y == 70)
                {
                    Array_Query[13] = Convert.ToString(direction.KeyChar);
                    Table_RRQ();
                    y += 2;
                    Console.SetCursorPosition(y, x);
                }
                else if (x == 7 && y == 72)
                {
                    Array_Query[14] = Convert.ToString(direction.KeyChar);
                    Table_RRQ();

                    Console.SetCursorPosition(y, x);
                }
                #endregion

            }


        }//Query 1.Step
        static void Query()
        {
            bool Query_Flag = true;
            Query_counter = 0;

            for (int i = 0; i < dict.Length; i++)
            {
                if (dict[i].Length == Query_word.Length)
                {
                    for (int j = 0; j < dict[i].Length; j++)
                    {
                        if (Query_word.Substring(j, 1) != ".")
                        {
                            if (dict[i].Substring(j, 1) != Query_word.Substring(j, 1))
                            {
                                Query_Flag = false;
                            }
                        }

                    }
                    if (Query_Flag == true)
                    {
                        Query_List[Query_counter] = dict[i];
                        Query_counter++;
                    }
                    else {
                        Query_Flag = true;
                    }


                }
                if (Query_List[9] != null) { break; }
            }



        }//Query 2.Step
        #endregion
        static void Choice_Key()
        {
            bool flag_choice = false;
            do
            {
                Console.SetCursorPosition(0, 19);
                Console.WriteLine("If you want to ");
                Console.Write("Querry, press -Q-");
                Console.Write("  ||  ");
                Console.Write("Write your word, press any -W-");
                Console.Write("  ||  ");
                Console.Write("Refill the Bag, press -E-");
                Console.Write("  ||  ");
                Console.WriteLine("Pass, press -P-");
                answer = Console.ReadLine().ToUpper();
                if (answer == "E")
                {
                    if (Round % 2 == 1)
                    {
                        Console.SetCursorPosition(83, 5);
                        x = 5;
                        y = 83;
                        Return();
                        flag_choice = false;
                        frodo = false;
                    }
                    if (Round % 2 == 0)
                    {
                        Console.SetCursorPosition(83, 10);
                        x = 10;
                        y = 83;
                        Return2();
                        flag_choice = false;
                        frodo = false;
                    }
                }
                else if (answer == "W")
                {
                    x = 10;
                    y = 16;
                    flag_choice = false;
                    Key();

                }

                else if (answer == "Q")
                {
                    if (Counter_Query_3 == 3 )
                    {
                        Console.SetCursorPosition(0, 22);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You Shall Not Query Anymore!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (Counter_Query_3 < 3)
                    {
                        Counter_Query_3++;
                        Console.SetCursorPosition(44, 7);
                        Input_Query();
                        flag_choice = true;
                        
                    }
                }

                else if (answer != "P" && answer != "W" && answer != "Q" && answer != "E")
                {
                    Console.SetCursorPosition(0, 21);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Wrong Entry!, Please try again");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    flag_choice = true;
                }
                if (answer == "P")
                {
                    if (Round % 2 == 1)
                    {
                        Pass_Counter1--;
                    }
                    else if (Round % 2 == 0)
                    {
                        Pass_Counter2--;
                    }
                    frodo = false;

                }
                else {
                    if (Round % 2 == 1)
                    {
                        Pass_Counter2 = 2;
                    }
                    else if (Round % 2 == 0)
                    {
                        Pass_Counter1 = 2;
                    }


                }
            } while (flag_choice == true);
        }//Tree
        static void Key()
        {



            while (flag == true)
            {

                Console.SetCursorPosition(y, x);
                a = x - 3;
                b = (y / 2) - 1;

                direction = Console.ReadKey(true);

                #region yonler ve silme
                if ((y + 2) < 31 && direction.Key == ConsoleKey.RightArrow)
                {

                    y = y + 2;

                    Console.SetCursorPosition(y, x);
                }
                else if ((y - 2) > 1 && direction.Key == ConsoleKey.LeftArrow)
                {

                    y = y - 2;

                    Console.SetCursorPosition(y, x);
                }
                else if ((x + 1) < 18 && direction.Key == ConsoleKey.DownArrow)
                {

                    x = x + 1;

                    Console.SetCursorPosition(y, x);
                }
                else if ((x - 1) > 2 && direction.Key == ConsoleKey.UpArrow)
                {

                    x = x - 1;

                    Console.SetCursorPosition(y, x);
                }


                else if (direction.Key == ConsoleKey.Backspace)
                {
                    counter_word--;
                    tbl[x - 3, (y / 2) - 1] = '\0';
                    flag = false;
                    frodo = true;
                }
                #endregion
                #region kelime kontrol
                else if (direction.Key == ConsoleKey.Tab)
                {
                    frodo = false;

                    Word_Maker();

                    x = 19;
                    y = 0;
                    Console.SetCursorPosition(y, x);


                    if (score > 0)//Gives output
                    {
                        if (Round % 2 == 1)
                        {
                            Console.SetCursorPosition(78, 7);
                            Console.WriteLine("Score: " + score_player1 + " + " + score + " = " + (score_player1 += score));
                            
                        }
                        else if (Round % 2 == 0)
                        {
                            Console.SetCursorPosition(78, 12);
                            Console.WriteLine("Score: " + score_player2 + " + " + score + " = " + (score_player2 += score));
                           
                        }
                        Console.SetCursorPosition(y, x);
                        Console.ReadKey();
                        frodo = false;
                        x = 10;
                        y = 16;

                        break;
                    }
                    else {//Gives output
                        score = 0;
                        Console.SetCursorPosition(0, 21);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Try Again Please");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                        x = 10;
                        y = 16;

                    }

                    letter_check = false;


                }
                #endregion

                else if (tbl[a, b] == '\0')
                {
                    Letter_Check_Bag();
                    flag = false;

                }
                else {
                    Console.SetCursorPosition(0, 19);
                    Console.WriteLine("Wrong Entry");

                }

            }
            flag = true;

        }

        static void Letter_Check_Bag()
        {
            bool flag_lettercheck = false;
            if (Round % 2 == 1)//Checks Player1's bag
            {
                for (int i = 0; i < letters.Length; i++)
                {
                    if (Char.ToUpper(direction.KeyChar) == Res_Array[letters[i]].Res_letter)
                    {
                        flag_lettercheck = true;
                        tbl[a, b] = char.ToUpper(direction.KeyChar);

                    }

                }
                if (flag_lettercheck == false)
                {
                    Console.SetCursorPosition(0, 24);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("You Shall Not Enter letter that isn't in the bag!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();

                }
                else { flag_lettercheck = false; }
            }

            else if (Round % 2 == 0)//Checks Player2's bag
            {
                for (int i = 0; i < letters2.Length; i++)
                {
                    if (Char.ToUpper(direction.KeyChar) == Res_Array[letters2[i]].Res_letter)
                    {
                        flag_lettercheck = true;
                        tbl[a, b] = char.ToUpper(direction.KeyChar);
                    }

                }
                if (flag_lettercheck == false)
                {
                    Console.SetCursorPosition(0, 19);
                    Console.Write("You Shall Not Enter letter that isn't in the bag");

                }
                else { flag_lettercheck = false; }
            }
            flag_lettercheck = false;

        }//Check if the letter is in the bag
        #region Reservoir_Letter_Counter
        static void Letter_Counter_Reservoir_Dec()
        {
            for (int i = 0; i < letters.Length; i++)
            {
                Res_Array[letters[i]].Res_point--;
            }
            for (int i = 0; i < letters2.Length; i++)
            {
                Res_Array[letters2[i]].Res_point--;
            }
        }//Decreasses Reservour For both player.
        static void Letter_Counter_Reservoir1_Dec()
        {
            for (int i = 0; i < letters.Length; i++)
            {
                Res_Array[letters[i]].Res_point--;
            }
        }//Decreasses Reservour For player1.
        static void Letter_Counter_Reservoir2_Dec()
        {
            for (int i = 0; i < letters2.Length; i++)
            {
                Res_Array[letters2[i]].Res_point--;
            }
        }//Decreasses Reservour for player2.
        static void Letter_Counter_Reservoir1_Inc()
        {
            for (int i = 0; i < Re_New.Length; i++)
            {
                Res_Array[letters[Re_New[i]]].Res_point++;
            }


        }//İncreases Reservour For player1.
        static void Letter_Counter_Reservoir2_Inc()
        {
            for (int i = 0; i < Re_New.Length; i++)
            {
                Res_Array[letters2[Re_New[i]]].Res_point++;
            }


        }//İncreases Reservour For player2.
        #endregion
        static void Bag()
        {
            bool flag2 = true;

            for (int i = 0; i < letters.Length; i++)//For Player1's Bag
            {
                flag2 = true;

                letters[i] = rnd.Next(0, 26);
                for (int j = 0; j < i; j++)
                {

                    while (flag2 == true)
                    {
                        if (letters[i] == letters[j])

                            letters[i] = rnd.Next(0, 26);

                        else { flag2 = false; }
                    }
                    flag2 = true;

                }

                for (int j = i + 1; j < letters.Length; j++)
                {

                    while (flag2 == true)
                    {
                        if (letters[i] == letters[j])

                            letters[i] = rnd.Next(0, 26);

                        else { flag2 = false; }
                    }
                    flag2 = true;

                }


            }
            flag2 = true;


            for (int i = 0; i < letters2.Length; i++)//For Player2's Bag
            {
                flag2 = true;

                letters2[i] = rnd.Next(0, 26);
                for (int j = 0; j < i; j++)
                {

                    while (flag2 == true)
                    {
                        if (letters2[i] == letters2[j])

                            letters2[i] = rnd.Next(0, 26);

                        else { flag2 = false; }
                    }
                    flag2 = true;

                }

                for (int j = i + 1; j < letters2.Length; j++)
                {

                    while (flag2 == true)
                    {
                        if (letters2[i] == letters2[j])

                            letters2[i] = rnd.Next(0, 26);

                        else { flag2 = false; }
                    }
                    flag2 = true;

                }

            }

            Letter_Counter_Reservoir_Dec();

        }//First step for the bag
        static void Return()
        {
            bool flag3 = true;

            while (flag3 == true)
            {
                direction = Console.ReadKey(true);

                if (y + 2 < 96 && direction.Key == ConsoleKey.RightArrow)
                {
                    y = y + 2;

                    Console.SetCursorPosition(y, x);
                }
                else if (y - 2 > 82 && direction.Key == ConsoleKey.LeftArrow)
                {
                    y = y - 2;

                    Console.SetCursorPosition(y, x);
                }

                else if (direction.Key == ConsoleKey.Enter)
                {

                    if (y == 83 && x == 5)

                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(Res_Array[letters[0]].Res_letter);
                        LetterFlag[0] = true;//For the understand which letter should refill
                        Console.SetCursorPosition(84, 5);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.SetCursorPosition(y, x);
                        Counter_Key++;
                    }
                    else if (y == 85 && x == 5)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(Res_Array[letters[1]].Res_letter);
                        LetterFlag[1] = true;
                        Console.SetCursorPosition(86, 5);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.SetCursorPosition(y, x);
                        Counter_Key++;
                    }
                    else if (y == 87 && x == 5)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(Res_Array[letters[2]].Res_letter);
                        LetterFlag[2] = true;
                        Console.SetCursorPosition(88, 5);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.SetCursorPosition(y, x);
                        Counter_Key++;
                    }
                    else if (y == 89 && x == 5)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(Res_Array[letters[3]].Res_letter);
                        LetterFlag[3] = true;
                        Console.SetCursorPosition(90, 5);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.SetCursorPosition(y, x);
                        Counter_Key++;
                    }
                    else if (y == 91 && x == 5)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(Res_Array[letters[4]].Res_letter);
                        LetterFlag[4] = true;
                        Console.SetCursorPosition(92, 5);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.SetCursorPosition(y, x);
                        Counter_Key++;
                    }
                    else if (y == 93 && x == 5)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(Res_Array[letters[5]].Res_letter);
                        LetterFlag[5] = true;
                        Console.SetCursorPosition(94, 5);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.SetCursorPosition(y, x);
                        Counter_Key++;
                    }
                    else if (y == 95 && x == 5)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(Res_Array[letters[6]].Res_letter);
                        LetterFlag[6] = true;
                        Console.SetCursorPosition(96, 5);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.SetCursorPosition(y, x);
                        Counter_Key++;
                    }

                }

                if (direction.Key == ConsoleKey.Tab)
                {
                    flag3 = false;

                }

            }
            Generate_Return();

        }//Second step. Marks the letters that will Regenerate
        static void Return2()
        {
            bool flag3 = true;

            while (flag3 == true)
            {
                direction = Console.ReadKey(true);

                if (y + 2 < 96 && direction.Key == ConsoleKey.RightArrow)
                {
                    y = y + 2;

                    Console.SetCursorPosition(y, x);
                }
                else if (y - 2 > 82 && direction.Key == ConsoleKey.LeftArrow)
                {
                    y = y - 2;

                    Console.SetCursorPosition(y, x);
                }

                else if (direction.Key == ConsoleKey.Enter)
                {

                    if (y == 83 && x == 10)

                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(Res_Array[letters2[0]].Res_letter);
                        LetterFlag[0] = true;//For the understand which letter should refill
                        Console.SetCursorPosition(84, x);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.SetCursorPosition(y, x);
                        Counter_Key++;
                    }
                    else if (y == 85 && x == 10)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(Res_Array[letters2[1]].Res_letter);
                        LetterFlag[1] = true;
                        Console.SetCursorPosition(86, x);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.SetCursorPosition(y, x);
                        Counter_Key++;
                    }
                    else if (y == 87 && x == 10)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(Res_Array[letters2[2]].Res_letter);
                        LetterFlag[2] = true;
                        Console.SetCursorPosition(88, x);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.SetCursorPosition(y, x);
                        Counter_Key++;
                    }
                    else if (y == 89 && x == 10)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(Res_Array[letters2[3]].Res_letter);
                        LetterFlag[3] = true;
                        Console.SetCursorPosition(90, x);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.SetCursorPosition(y, x);
                        Counter_Key++;
                    }
                    else if (y == 91 && x == 10)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(Res_Array[letters2[4]].Res_letter);
                        LetterFlag[4] = true;
                        Console.SetCursorPosition(92, x);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.SetCursorPosition(y, x);
                        Counter_Key++;
                    }
                    else if (y == 93 && x == 10)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(Res_Array[letters2[5]].Res_letter);
                        LetterFlag[5] = true;
                        Console.SetCursorPosition(94, x);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.SetCursorPosition(y, x);
                        Counter_Key++;
                    }
                    else if (y == 95 && x == 10)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(Res_Array[letters2[6]].Res_letter);
                        LetterFlag[6] = true;
                        Console.SetCursorPosition(96, x);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.SetCursorPosition(y, x);
                        Counter_Key++;
                    }

                }

                if (direction.Key == ConsoleKey.Tab)
                {
                    flag3 = false;

                }

            }
            Generate_Return2();

        }//Second step. Marks the letters that will Regenerate
        static void Generate_Return()
        {
            bool flag2 = true;
            Re_New = new int[Counter_Key];
            bool flag_forzero = true;
            for (int i = 0; i < Re_New.Length; i++)
            {
                if (LetterFlag[0] == true)
                {
                    Re_New[i] = 0;
                    LetterFlag[0] = false;
                }
                else if (LetterFlag[1] == true)
                {
                    Re_New[i] = 1;
                    LetterFlag[1] = false;
                }
                else if (LetterFlag[2] == true)
                {
                    Re_New[i] = 2;
                    LetterFlag[2] = false;
                }
                else if (LetterFlag[3] == true)
                {
                    Re_New[i] = 3;
                    LetterFlag[3] = false;
                }
                else if (LetterFlag[4] == true)
                {
                    Re_New[i] = 4;
                    LetterFlag[4] = false;
                }
                else if (LetterFlag[5] == true)
                {
                    Re_New[i] = 5;
                    LetterFlag[5] = false;
                }
                else if (LetterFlag[6] == true)
                {
                    Re_New[i] = 6;
                    LetterFlag[6] = false;
                }
            }

            Letter_Counter_Reservoir1_Inc();
            for (int i = 0; i < Re_New.Length; i++)//For The Return Table
            {
                Returns[i] = Res_Array[letters[i]].Res_letter;
            }

            for (int i = 0; i < Re_New.Length; i++)//For The ReGenerate
            {
                letters[Re_New[i]] = rnd.Next(0, 26);
                for (int j = 0; j < i; j++)
                {

                    while (flag2 == true)
                    {
                        while (flag_forzero == true)
                        {
                            if (letters[i] == letters[j])
                            {

                                letters[i] = rnd.Next(0, 26);
                            }

                            else { flag2 = false; }
                            if (Res_Array[letters[i]].Res_point != 0)
                            {
                                flag_forzero = false;

                            }
                            else
                            {
                                letters[i] = rnd.Next(0, 26);
                            }
                        }
                        flag_forzero = true;
                    }
                    flag2 = true;
                }


                for (int j = i + 1; j < letters.Length; j++)
                {

                    while (flag2 == true)
                    {
                        while (flag_forzero == true)
                        {

                            if (letters[i] == letters[j])
                            {

                                letters[i] = rnd.Next(0, 26);
                            }

                            else { flag2 = false; }
                            if (Res_Array[letters[i]].Res_point != 0)
                            {
                                flag_forzero = false;

                            }
                            else
                            {
                                letters[i] = rnd.Next(0, 26);
                            }

                        }
                        flag_forzero = true;

                    }
                    flag2 = true;
                }
                flag_forzero = true;
            }
            Letter_Counter_Reservoir1_Dec();
            Counter_Key = 0;
        }//Third step. Regenerate process
        static void Generate_Return2()
        {
            bool flag2 = true;
            Re_New = new int[Counter_Key];
            bool flag_forzero = true;
            for (int i = 0; i < Re_New.Length; i++)
            {
                if (LetterFlag[0] == true)
                {
                    Re_New[i] = 0;
                    LetterFlag[0] = false;
                }
                else if (LetterFlag[1] == true)
                {
                    Re_New[i] = 1;
                    LetterFlag[1] = false;
                }
                else if (LetterFlag[2] == true)
                {
                    Re_New[i] = 2;
                    LetterFlag[2] = false;
                }
                else if (LetterFlag[3] == true)
                {
                    Re_New[i] = 3;
                    LetterFlag[3] = false;
                }
                else if (LetterFlag[4] == true)
                {
                    Re_New[i] = 4;
                    LetterFlag[4] = false;
                }
                else if (LetterFlag[5] == true)
                {
                    Re_New[i] = 5;
                    LetterFlag[5] = false;
                }
                else if (LetterFlag[6] == true)
                {
                    Re_New[i] = 6;
                    LetterFlag[6] = false;
                }
            }

            Letter_Counter_Reservoir2_Inc();
            for (int i = 0; i < Re_New.Length; i++)//For The Return Table
            {
                Returns[i] = Res_Array[letters2[i]].Res_letter;
            }

            for (int i = 0; i < Re_New.Length; i++)//For The ReGenerate
            {
                letters2[Re_New[i]] = rnd.Next(0, 26);
                for (int j = 0; j < i; j++)
                {

                    while (flag2 == true)
                    {
                        while (flag_forzero == true)
                        {
                            if (letters2[i] == letters2[j])
                            {

                                letters2[i] = rnd.Next(0, 26);
                            }

                            else { flag2 = false; }
                            if (Res_Array[letters2[i]].Res_point != 0)
                            {
                                flag_forzero = false;

                            }
                            else
                            {
                                letters2[i] = rnd.Next(0, 26);
                            }
                        }
                        flag_forzero = true;
                    }
                    flag2 = true;
                }


                for (int j = i + 1; j < letters2.Length; j++)
                {

                    while (flag2 == true)
                    {
                        while (flag_forzero == true)
                        {

                            if (letters2[i] == letters2[j])
                            {

                                letters2[i] = rnd.Next(0, 26);
                            }

                            else { flag2 = false; }
                            if (Res_Array[letters2[i]].Res_point != 0)
                            {
                                flag_forzero = false;

                            }
                            else
                            {
                                letters2[i] = rnd.Next(0, 26);
                            }

                        }
                        flag_forzero = true;

                    }
                    flag2 = true;
                }
                flag_forzero = true;
            }
            Letter_Counter_Reservoir2_Dec();
            Counter_Key = 0;
        }//Third step. Regenerate process.For Player2
        static void Letter_Marker()
        {
            if (Round % 2 == 1)
            {
                for (int i = 0; i < letters.Length; i++)
                {
                    for (int j = 0; j < new_word.Length; j++)
                    {
                        if (new_word.Substring(j, 1) == Convert.ToString(Res_Array[letters[i]].Res_letter))
                        {
                            LetterFlag[i] = true;
                            Counter_Key++;
                        }
                    }

                }
                Generate_Return();
            }
            
            if (Round % 2 == 0)
            {
                for (int i = 0; i < letters2.Length; i++)
                {
                    for (int j = 0; j < new_word.Length; j++)
                    {
                        if (new_word.Substring(j, 1) == Convert.ToString(Res_Array[letters2[i]].Res_letter))
                        {
                            LetterFlag[i] = true;
                            Counter_Key++;
                        }
                    }

                }
                Generate_Return2();

            }

            }

        static void Score2(int m, int n)
        {
            for (int i = 0; i < 26; i++)
            {
                if (Convert.ToString(tbl[m, n]) == Convert.ToString(Res_Array[i].Res_letter))
                {
                    score2 = score2 + Res_Array[i].Res_number;
                }

            }
        }
        #region Kelime birleştirme eşleştirme
        
        static void Word_Maker()
        {
            counter_word = 0;
            for (int i = 0; i < tbl.GetLength(0); i++)
            {
                for (int j = 0; j < tbl.GetLength(1); j++)
                {
                    if (tbl[i, j] != '\0')
                    {

                        new_word = new_word.Insert(counter_word, Convert.ToString(tbl[i, j]));
                        counter_word++;
                        Score2(i, j);

                    }
                    if (j < 14)
                    {
                        if (counter_word > 0 && tbl[i, j + 1] == '\0')
                        {
                            Word_Matcher(new_word);
                            if (word_check == true)
                            {
                                Word_Searcher();
                                Counter_ForScanned++;

                            }
                            else {
                                score2 = 0;
                                counter_word = 0;
                                new_word = "";
                            }


                        }
                    }
                }
            }
            #region FVertical
            for (int i = 0; i < tbl.GetLength(0); i++)//For the Vertical
            {
                for (int j = 0; j < tbl.GetLength(1); j++)
                {
                    if (tbl[j, i] != '\0')
                    {

                        new_word = new_word.Insert(counter_word, Convert.ToString(tbl[j, i]));
                        counter_word++;

                        Score2(j, i);
                    }
                    if (j < 14)
                    {
                        if (counter_word > 0 && tbl[j + 1, i] == '\0')
                        {
                            Word_Matcher(new_word);
                            if (word_check == true)
                            {
                                Word_Searcher();
                                Counter_ForScanned++;

                            }
                            else {
                                score2 = 0;
                                new_word = "";
                            }

                            counter_word = 0;
                        }
                    }
                }
            }
            #endregion


        }//First Step
        static void Word_Searcher()
        {
            bool flag = false;
            for (int i = 0; i < Scanned_words.Length; i++)
            {
                if (Scanned_words[i] == new_word)
                {
                    flag = true;
                    new_word = "";
                    counter_word = 0;
                    Counter_ForScanned--;
                    score2 = 0;
                }
            }
            if (flag == false)
            {
                Letter_Marker();
                Scanned_words[Counter_ForScanned] = new_word;
                score = score + score2;
                score2 = 0;
                new_word = "";
            }





        }//Second Step
        static void Word_Matcher(string word)
        {

            word_check = false;
            for (int i = 0; i < dict.Length; i++)//Checks if the word is matched
            {
                if (dict[i] == word)
                {
                    word_check = true;

                }
            }


        }//Third Step

        #endregion
        public static void Folder()
        {
            StreamReader dictionary = File.OpenText("dictionary_1.txt");

            int i = 0;
            do
            {
                dict[i] = dictionary.ReadLine();
                i++;
            }
            while (!dictionary.EndOfStream);
            dictionary.Close();


            StreamReader letter_reservoir = File.OpenText("letter_reservoir_1.txt");
            for (i = 0; !letter_reservoir.EndOfStream; i++)
            {

                string Row = letter_reservoir.ReadLine();
                string[] Res_Words = Row.Split(' ');

                Res_Array[i].Res_letter = Convert.ToChar(Res_Words[0]);
                Res_Array[i].Res_number = Convert.ToInt32(Res_Words[1]);
                Res_Array[i].Res_point = Convert.ToInt32(Res_Words[2]);

            }
            letter_reservoir.Close();
        }




    }
}

