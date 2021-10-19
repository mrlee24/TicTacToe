using System;
namespace SnakeGame
{
    public class Player
    {
        private char sign;

        public char Sign { get => sign; set => sign = value; }

        public Player(char playerSign)
        {
            Sign = playerSign;
        }

        public int ChooseField()
        {
            int fieldNumber = int.Parse(Console.ReadLine());
            return fieldNumber;
        }

        private bool CheckRowsForWin(GameBoard gameBoard)
        {
            for (int i = 0; i < GameBoard.BOARD_SIZE; i++)
            {
                if (CheckRowCol(gameBoard.Board[i, 0].GetFieldState(), gameBoard.Board[i, 1].GetFieldState(), gameBoard.Board[i, 2].GetFieldState()))
                    return true;
            }
            return false;
        }

        private bool CheckColumnsForWin(GameBoard gameBoard)
        {
            for (int i = 0; i < GameBoard.BOARD_SIZE; i++)
            {
                if (CheckRowCol(gameBoard.Board[0, i].GetFieldState(), gameBoard.Board[1, i].GetFieldState(), gameBoard.Board[2, i].GetFieldState()))
                    return true;
            }
            return false;
        }

        private bool CheckDiagonalsForWin(GameBoard gameBoard)
            => ((CheckRowCol(gameBoard.Board[0, 0].GetFieldState(), gameBoard.Board[1, 1].GetFieldState(), gameBoard.Board[2, 2].GetFieldState()) == true) || (CheckRowCol(gameBoard.Board[0, 2].GetFieldState(), gameBoard.Board[1, 1].GetFieldState(), gameBoard.Board[2, 0].GetFieldState()) == true));

        private bool CheckRowCol(FIELD c1, FIELD c2, FIELD c3)
            => (c1 != FIELD.FLD_EMPTY) && (c1 == c2) && (c2 == c3);

        public bool CheckWin(GameBoard gameBoard)
            => (CheckRowsForWin(gameBoard) || CheckColumnsForWin(gameBoard) || CheckDiagonalsForWin(gameBoard));
    }
}
