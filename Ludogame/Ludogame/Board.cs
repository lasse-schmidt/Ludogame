using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Ludogame
{
    class Board
    {
        private Pice[] brikker = new Pice[16];
        private Felt[] felt = new Felt[40];
        private Dice terning;
        public Board()
        {

            this.terning = new Dice();

            felt[0] = new Felt(2, 7);
            felt[1] = new Felt(3, 7);
            felt[2] = new Felt(4, 7);
            felt[3] = new Felt(5, 7);
            felt[4] = new Felt(5, 8);
            felt[5] = new Felt(5, 9);
            felt[6] = new Felt(5, 10);
            felt[7] = new Felt(5, 11);
            felt[8] = new Felt(6, 11);
            felt[9] = new Felt(7, 11);
            felt[10] = new Felt(7, 10);
            felt[11] = new Felt(7, 9);
            felt[12] = new Felt(7, 8);
            felt[13] = new Felt(7, 7);
            felt[14] = new Felt(8, 7);
            felt[15] = new Felt(9, 7);
            felt[16] = new Felt(10, 7);
            felt[17] = new Felt(11, 7);
            felt[18] = new Felt(11, 6);
            felt[19] = new Felt(11, 5);
            felt[20] = new Felt(10, 5);
            felt[21] = new Felt(9, 5);
            felt[22] = new Felt(8, 5);
            felt[23] = new Felt(7, 5);
            felt[24] = new Felt(7, 4);
            felt[25] = new Felt(7, 3);
            felt[26] = new Felt(7, 2);
            felt[27] = new Felt(7, 1);
            felt[28] = new Felt(6, 1);
            felt[29] = new Felt(5, 1);
            felt[30] = new Felt(5, 2);
            felt[31] = new Felt(5, 3);
            felt[32] = new Felt(5, 4);
            felt[33] = new Felt(5, 5);
            felt[34] = new Felt(4, 5);
            felt[35] = new Felt(3, 5);
            felt[36] = new Felt(2, 5);
            felt[37] = new Felt(1, 5);
            felt[38] = new Felt(1, 6);
            felt[39] = new Felt(1, 7);

            brikker[0] = new Pice("Red");
            brikker[1] = new Pice("Red");
            brikker[2] = new Pice("Red");
            brikker[3] = new Pice("Red");
            brikker[4] = new Pice("Green");
            brikker[5] = new Pice("Green");
            brikker[6] = new Pice("Green");
            brikker[7] = new Pice("Green");
            brikker[8] = new Pice("Yellow");
            brikker[9] = new Pice("Yellow");
            brikker[10] = new Pice("Yellow");
            brikker[11] = new Pice("Yellow");
            brikker[12] = new Pice("Blue");
            brikker[13] = new Pice("Blue");
            brikker[14] = new Pice("Blue");
            brikker[15] = new Pice("Blue");

            WriteLine("Angiv antal spillere, 2-4");
            int playerAmount = int.Parse(ReadLine());

            string[] players = new string[] { "Red", "Green", "Yellow", "Blue" };
            int a = 0;
             while (true)
            {
                a++; 
                for (int o = 0; o < playerAmount; o++)
                {
                    doPlayer(players[o], a);
                }
            }
            
        }

        public void doPlayer(string colour, int a)
        {
            ReadKey();
            int tk = terning.kast();
            WriteLine($"Round {a} Move colour {colour} dice: {tk}  ");
            bool flytUd = false;
            if (tk == 6)
            {
                if (colour == "Red")
                {
                    flytUd = this.putRedInGame();
                }
                if (colour == "Green")
                {
                    flytUd = this.putGreenInGame();
                }
                if (colour == "Yellow")
                {
                    flytUd = this.putYellowInGame();
                }
                if (colour == "Blue")
                {
                    flytUd = this.putBlueInGame();
                }
            }
            if (!flytUd)
            {
                if (!this.movePieces(tk, colour))
                {
                    WriteLine($"Could neither move " + colour + " piece or set in game!");
                }
            }
            this.status(colour);
        }

        public void status(string colour)
        {
            if (colour == "Red")
            {
                this.piecesStatusRed();
            }
            if (colour == "Green")
            {
                this.piecesStatusGreen();
            }
            if (colour == "Yellow")
            {
                this.piecesStatusYellow();
            }
            if (colour == "Blue")
            {
                this.piecesStatusBlue();
            }
        }

        public void piecesStatusRed()
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Status på rød");
            for (int n = 0; n < 4; n++)
            {
                WriteLine(this.brikker[n]);
            }
            ResetColor();
            WriteLine();
        }

        public void piecesStatusGreen()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Status på grøn");
            for (int n = 4; n < 8; n++)
            {
                WriteLine(this.brikker[n]);
            }
            ResetColor();   
            WriteLine();
        }

        public void piecesStatusYellow()
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("Status på gul");
            for (int n = 8; n < 12; n++)
            {
                WriteLine(this.brikker[n]);
            }
            ResetColor();
            WriteLine();
        }

        public void piecesStatusBlue()
        {
            ForegroundColor = ConsoleColor.Blue;
            WriteLine("Status på blå");
            for (int n = 12; n < 16; n++)
            {
                WriteLine(this.brikker[n]);
            }
            ResetColor();
            WriteLine();
        }

        public bool movePieces(int eyes, string colour)
        {
            for (int i = 0; i < 16; i++)
            {
                if (brikker[i].getTilstand() == "Ingame" && brikker[i].color == colour)
                {
                    if (this.brikkerOnPos(this.brikker[i].position + eyes) == 0 || brikker[i].color == colour)
                    {
                        WriteLine($"Moves piece: {eyes}");
                        this.brikker[i].move(eyes);
                        return true;
                    } else
                    {
                        if(this.brikkerOnPos(this.brikker[i].position + eyes) < 0 && brikker[i].color != colour)
                        {
                            brikker[i].setTilstand("Home");
                            WriteLine("Return to start");
                        }

                        this.brikker[i].move(eyes);
                        WriteLine("Cannot move piece. Field occupied!!");
                    }
                }
            }
            return false;
        }


        public bool putRedInGame()
        {
            for (int i = 0; i < 4; i++)
            {
                if (this.brikker[i].getTilstand() == "Home")
                {
                    WriteLine("Puts red in the game!");
                    this.brikker[i].setTilstand("Ingame");
                    return true;
                }
            }
            return false;
        }
        public bool putGreenInGame()
        {
            for (int i = 4; i < 8; i++)
            {
                if (this.brikker[i].getTilstand() == "Home")
                {
                    WriteLine("Puts Green in the game!");
                    this.brikker[i].setTilstand("Ingame");
                    return true;
                }
            }
            return false;
        }
        public bool putYellowInGame()
        {
            for (int i = 8; i < 12; i++)
            {
                if (this.brikker[i].getTilstand() == "Home")
                {
                    WriteLine("Puts Yellow in the game!");
                    this.brikker[i].setTilstand("Ingame");
                    return true;
                }
            }
            return false;
        }
        public bool putBlueInGame()
        {
            for (int i = 12; i < 16; i++)
            {
                if (this.brikker[i].getTilstand() == "Home")
                {
                    WriteLine("Puts Blue in the game!");
                    this.brikker[i].setTilstand("Ingame");
                    return true;
                }
            }
            return false;
        }

        public int brikkerOnPos(int pos)
        {
            int antalBrikker = 0;
            foreach (Pice p in this.brikker) {
                if (p.position == pos)
                    antalBrikker++;
            }
            return antalBrikker;
        }

        public void returnToStart(string colour)
        {

        }
    }
}