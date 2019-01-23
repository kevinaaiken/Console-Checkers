using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers{
    class Program{
        //global variables
        static int turn_counter = 1;

        static void Main(string[] args){
            Console.BackgroundColor = ConsoleColor.DarkRed;
            //variables-----------------------------------------------------------------------
            bool game = true;
            string[,] ary_checkers = new string[8, 8];  //empty places
            string[,] ary_player1  = new string[8, 8];  //player1 cyan
            string[,] ary_player2  = new string[8, 8];  //player2 magenta

            //initalize arrays----------------------------------------------------------------
            //place player1's checkers
            for (int col = 7; col > 4; col --){
                int offset = col % 2;
                for (int row = offset; row < ary_player1.GetLength(1); row += 2){
                    ary_player1[col, row] = "@ ";
                }//end row
            }//end column
            //place player2's checkers
            for (int col = 0; col < 3; col ++){
                int offset = col % 2;
                for (int row = offset; row < ary_player2.GetLength(1); row += 2){
                    ary_player2[col, row] = " @";
                }//end row
            }//end column
            //fill empty spots
            for (int col = 0; col < ary_checkers.GetLength(0); col ++){
                for (int row = 0; row < ary_checkers.GetLength(1); row ++){
                    if (ary_player1[col, row] == null && ary_player2[col, row] == null){
                         ary_checkers[col, row] = "__";
                    }//end if(empty)
                }//end row
            }//end column

            //game loop-----------------------------------------------------------------------
            while (game){
                SetupColor(ConsoleColor.DarkYellow, ConsoleColor.Black);
                DrawBoard(ary_checkers, ary_player1, ary_player2);
                if(turn_counter % 2 == 1){
                    Console.WriteLine("\nPlayer 1's turn.");
                    TakeTurn(ary_player1);
                }else{
                    Console.WriteLine("\nPlayer 2's turn.");
                    TakeTurn(ary_player2);
                }//if(who's on first)
                CheckWin(game, ary_player1, ary_player2);
            }//end while playing

            //Reset variables-----------------------------------------------------------------
            game = true;
            turn_counter = 1;
            Console.ReadKey(true);
        }//main

        static string Prompt(string message) {
            Console.Write(message);
            return Console.ReadLine();
        }//end prompt function

        static void SetupColor (ConsoleColor front, ConsoleColor back) {
		    Console.ForegroundColor = front;
            Console.BackgroundColor = back;
		    //Console.Clear();
	    }//end setup color function

        static void DrawBoard (string[,] empty, string[,] player1, string[,] player2) {
           int side_nums = 8;
            for (int col = 0; col < empty.GetLength(0); col ++){
                Console.WriteLine("   -------------------------"); //3 spaces + 25 characters
                for (int row = 0; row < empty.GetLength(1); row ++){
                    if(row == 0){
                        Console.Write(side_nums + "  |");
                    }//display side numbers

                    if(player1[row, col] == "@ "){
                        SetupColor(ConsoleColor.Cyan, ConsoleColor.Black);
                        Console.Write(player1[row, col]);
                        SetupColor(ConsoleColor.DarkYellow, ConsoleColor.Red);
                        Console.Write("|");
                    }else if(player2[row, col] == " @"){
                        SetupColor(ConsoleColor.Magenta, ConsoleColor.Black);
                        Console.Write(player2[row, col]);
                        SetupColor(ConsoleColor.DarkYellow, ConsoleColor.Red);
                        Console.Write("|");
                    }else{
                        Console.Write(empty[col, row] + "|");
                    }//end if(display pieces w/color)
                }//end for row

                side_nums --;
                Console.Write("|\n");
            }//end for col
            Console.WriteLine("   -------------------------");
            Console.WriteLine("    A  B  C  D  E  F  G  H  ");
        }//end draw board function

        static void TakeTurn (string[,] player_turn){
            Console.ReadKey(true);
        }//end take turn function

        static bool CheckWin (bool game, string[,] p1_ary, string[,] p2_ary){
            int p1_pieces = 0;
            int p2_pieces = 0;
            game = true;
            for (int col = 0; col < p1_ary.GetLength(0); col ++){
                for (int row = 0; row < p1_ary.GetLength(1); row += 2){
                    if (p1_ary[col, row] == "@ " || p1_ary[col, row] == "@K"){
                        p1_pieces ++;
                    }//end if(p1 token)
                }//end row
            }//end column
            if (p1_pieces == 0){
                Console.WriteLine("p2 win!");
                game = false;
            }//end if (p2 win)
            for (int col = 0; col < p2_ary.GetLength(0); col ++){
                for (int row = 0; row < p2_ary.GetLength(1); row += 2){
                    if (p2_ary[col, row] == "@ " || p2_ary[col, row] == "@K"){
                        p2_pieces ++;
                    }//end if(p1 token)
                }//end row
            }//end column
            if (p2_pieces == 0){
                Console.WriteLine("p1 win!");
                game = false;
            }//end if(p1 win)
            return game;
        }//end check win function

    }//class
}//name
