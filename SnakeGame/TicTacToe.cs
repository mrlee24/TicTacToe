using System;

namespace SnakeGame
{
    class TicTacToe
    {
        public TicTacToe()
        {}

        public void Play()
        {
            GameBoard gameBoard = new GameBoard();
            Player playerX = new Player('X');
            Player playerO = new Player('O');
            Player currentPlayer = playerX;
            int moveCounter = 0;
            bool play = true;

            while (play)
            {
                gameBoard.DrawBoard();
                Console.WriteLine("Player: {0} Enter the field in which you want to put the character: ", currentPlayer.Sign);

                try
                {
                    gameBoard.Mark(currentPlayer, playerX.ChooseField());
                    gameBoard.ClearBoard();
                    moveCounter++;
                    if (currentPlayer.CheckWin(gameBoard))
                    {
                        Console.WriteLine("Player: {0} won!", currentPlayer.Sign);
                        gameBoard.DrawBoard();
                        play = false;
                    }
                    else if (CheckDraw(moveCounter))
                    {
                        Console.WriteLine("DRAW");
                        gameBoard.DrawBoard();
                        play = false;
                    }
                    currentPlayer = PlayerTurn(currentPlayer, playerX, playerO);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input. Please enter number between 1-9!");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        private Player PlayerTurn(Player currentPlayer, Player playerX, Player playerO)
            => currentPlayer == playerX ? playerO : playerX;

        private bool CheckDraw(int turnCounter)
        {
            if (turnCounter == 9)
                return true;
            return false;
        }
    }
}