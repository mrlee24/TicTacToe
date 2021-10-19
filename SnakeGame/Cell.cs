using System;
namespace SnakeGame
{
    public class Cell
    {
        FIELD fieldState = FIELD.FLD_EMPTY;

        public Cell()
            => fieldState = FIELD.FLD_EMPTY;

        public FIELD GetFieldState()
            => fieldState;

        public bool IsEmpty()
        {
            if (fieldState != FIELD.FLD_EMPTY)
                return false;
            return true;
        }

        public void MarkField(Player player)
        {
            if (IsEmpty())
            {
                if (player.Sign == 'X')
                    fieldState = FIELD.FLD_X;
                else
                    fieldState = FIELD.FLD_O;
            }
        }
    }
}
