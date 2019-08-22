using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Ludogame
{
    class Pice
    {
        public string tilstand { get; set; }// Hjemme "home", I spil (på motorvejen) "ingame", I slutspil "endgame", Færdig (i mål) "goal"
        public string color;
        public int position; // Aktuelle position
        public int startPosition;
        public int slutPosition;


        public Pice(string color)
        {
            this.color = color; 
            this.setTilstand("Home");

            switch (color)
            {
                case "Red":
                    this.position = 0;
                    this.startPosition = 0;
                    this.slutPosition = 38;
                    break;
                case "Green":
                    this.position = 10;
                    this.startPosition = 10;
                    this.slutPosition = 48;
                    break;
                case "Yellow":
                    this.position = 20;
                    this.startPosition = 20;
                    this.slutPosition = 58;
                    break;
                case "Blue":
                    this.position = 30;
                    this.startPosition = 30;
                    this.slutPosition = 68;
                    break;
            }
            
        }
        public void move(int steps)
        {
            if(this.color == "Red") {
                this.position += steps;
                WriteLine("Ny position");
                if(this.position > this.slutPosition)
                {
                    this.setTilstand("Endgame"); 
                    WriteLine("Spillet er slut");
                }
            }

            if (this.color == "Green")
            {
                this.position += steps;
                WriteLine("Ny position");
                if (this.position > this.slutPosition)
                {
                    this.setTilstand("Endgame");
                    WriteLine("Spillet er slut");
                }
            }

            if (this.color == "Yellow")
            {
                this.position += steps;
                WriteLine("Ny position");
                if (this.position > this.slutPosition)
                {
                    this.setTilstand("Endgame");
                    WriteLine("Spillet er slut");
                }
            }

            if (this.color == "Blue")
            {
                this.position += steps;
                WriteLine("Ny position");
                if (this.position > this.slutPosition)
                {
                    this.setTilstand("Endgame");
                    WriteLine("Spillet er slut");
                }
            }

        }
        public void setTilstand(string tilstand)
        {
            switch (tilstand)
            {
                case "Home":
                    this.tilstand = "Home";
                    break;
                case "Ingame":
                    this.tilstand = "Ingame";
                    break;
                case "Endgame":
                    this.tilstand = "Endgame";
                    break;
                case "Goal":
                    this.tilstand = "Goal";
                    break;
            }
        }
        public string getTilstand()
        {
            return this.tilstand;
        }

        public override string ToString()
        {
            return $"[tilstand:{this.tilstand}, pos:{this.position}, color: {this.color}]";
        }
    }
}
