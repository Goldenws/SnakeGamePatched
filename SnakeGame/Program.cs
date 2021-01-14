using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {

            int score = 0;
            Walls walls = new Walls(119, 29);
            walls.Draw();
            Point snakeTail = new Point(5, 5, 's');
            Snake snake = new Snake(snakeTail, 10, Direction.RIGHT);
            snake.Draw();
            FoodGenerator foodGenerator = new FoodGenerator(119, 29, '$');
            Point food = foodGenerator.GenerateFood();
            food.Draw();


            while (true)
            {
                if(walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodGenerator.GenerateFood();
                    food.Draw();
                   

                    Random rnd = new Random();
                    int num = rnd.Next(1, 3);
                    if(num == 1)
                    {
                        score = score + 2;
                    }
                    else
                    {
                        score--;
                    }
                }
                else
                {
                    snake.Move();
                }


                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKeys(key.Key);
                }

                Thread.Sleep(300);
               
            }

            string str_score = Convert.ToString(score);
            WriteGameOver(str_score);
            Console.ReadLine();



            

        }

        public static void WriteGameOver(string score)
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("========================", xOffset, yOffset++);
            WriteText("        GAME OVER        ", xOffset+1, yOffset++);
            yOffset++;
            WriteText($"You scored {score} points", xOffset+2, yOffset++);
            WriteText("", xOffset+1, yOffset++);
            WriteText("========================", xOffset, yOffset++);
        }
          
       public static void WriteText(String text, int xOffset,int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}
