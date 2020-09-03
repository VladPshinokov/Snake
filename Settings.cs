using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public enum Direction 
    { 
        Up, 
        Down, 
        Left, 
        Right
    }

    class Settings
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static int Speed { get; set; }
        public static int Score { get; set; }
        public static int Points { get; set; }
        public static bool GameOver { get; set; }
        public static Direction direction { get; set; }

        public Settings()
        {
            Width = 40;
            Height = 40;
            Speed = 8;
            Points = 100;
            Score = 0;
            GameOver = false;
            direction = Direction.Down;
        }
    }
}
