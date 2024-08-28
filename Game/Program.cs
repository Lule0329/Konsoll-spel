using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GlobalVar.Enemy1[0] = GlobalVar.Enemy1Pos.Next(5, 30);
            GlobalVar.Enemy1[1] = 5;

            GlobalVar.Enemy2[0] = GlobalVar.Enemy1Pos.Next(30, 60);
            GlobalVar.Enemy2[1] = 25;

            while (true)
            {
                PlayerMovemet();
                RenderPlayer();
                RenderEnemies();
                PlayerInteract();
            }
        }

        static void PlayerMovemet() 
        {
            if (Console.ReadKey().Key == ConsoleKey.LeftArrow)
            {
                if (GlobalVar.PlayerPosX <= 0)
                {
                    GlobalVar.PlayerPosX = 0;
                }
                else
                {
                    GlobalVar.PlayerPosX--;
                }
            }
            else if (Console.ReadKey().Key == ConsoleKey.RightArrow)
            {
                GlobalVar.PlayerPosX++;
            }

            if (Console.ReadKey().Key == ConsoleKey.UpArrow)
            {
                if (GlobalVar.PlayerPosY <= 0)
                {
                    GlobalVar.PlayerPosY = 0;
                }
                else
                {
                    GlobalVar.PlayerPosY--;
                }
            }
            else if (Console.ReadKey().Key == ConsoleKey.DownArrow)
            {
                GlobalVar.PlayerPosY++;
            }
        }
        
        static void RenderPlayer() // Ritar spelaren
        {
            Console.Clear();
            Console.SetCursorPosition(GlobalVar.PlayerPosX + 1, GlobalVar.PlayerPosY);
            Console.Write("0");
            Console.SetCursorPosition(GlobalVar.PlayerPosX, GlobalVar .PlayerPosY + 1);
            Console.Write("-#-");
            Console.SetCursorPosition(GlobalVar.PlayerPosX, GlobalVar .PlayerPosY + 2);
            Console.Write(" '' ");
        }

        static void RenderEnemies() // Ritar Fienden
        {
            Console.SetCursorPosition(GlobalVar.Enemy1[0], GlobalVar.Enemy1[1]);
            Console.Write("X");
            
            Console.SetCursorPosition(GlobalVar.Enemy2[0], GlobalVar.Enemy2[1]);
            Console.Write("Y");
        }

        static void PlayerInteract()
        {
            if (GlobalVar.PlayerPosX == GlobalVar.Enemy1[0] && GlobalVar.PlayerPosY == GlobalVar.Enemy1[1])
            {
                Environment.Exit(0);
            }
        }

        public class GlobalVar
        {
            public static int PlayerPosX;
            public static int PlayerPosY;

            // Enemy Variabler
            public static int[] Enemy1 = new int[2];
            public static int[] Enemy2 = new int[2];

            public static Random Enemy1Pos = new Random();
            public static Random Enemy2Pos = new Random();

            public static bool Enemy1Dead;
            public static bool Enemy2Dead;
        }
    }
}
