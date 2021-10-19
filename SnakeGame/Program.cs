using System;
using System.Collections;
using System.Threading;

namespace SnakeGame
{
    class MainClass
    {
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            game.Play();

            Console.ReadKey();
        }
    }
}
