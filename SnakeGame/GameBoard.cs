using System;
namespace SnakeGame
{
    public class GameBoard
    {
        public const int BOARD_SIZE = 3;
        public Cell[,] Board;

        public GameBoard()
        {
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            Board = new Cell[BOARD_SIZE, BOARD_SIZE];
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                    Board[i, j] = new Cell();
            }
        }

        public void DrawBoard()
        {
            const int ASCII_CODE_0 = 48;
            int fieldNumber = 1;
            Console.WriteLine("-----");
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if (Board[i, j].IsEmpty())
                        Console.Write((char)(ASCII_CODE_0 + fieldNumber));
                    else
                        Console.Write((char)(Board[i, j].GetFieldState()));
                    fieldNumber++;

                    if (j < BOARD_SIZE - 1)
                        Console.Write("|");
                }
                Console.Write("\n");
            }
            Console.WriteLine("-----");
        }

        public void Mark(Player player, int fieldNumber)
        {
            int verticalY = (fieldNumber - 1) / 3;
            int horizontalX = (fieldNumber - 1) % 3;

            if (Board[verticalY, horizontalX].IsEmpty())
                Board[verticalY, horizontalX].MarkField(player);
            else
            {
                Console.WriteLine("This place is taken. Select the field again: ");
                Mark(player, player.ChooseField());
            }
        }

        public void ClearBoard()
            => Console.Clear();
    }
}
